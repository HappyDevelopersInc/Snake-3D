using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;


    // Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
    public class IAPManager : MonoBehaviour, IStoreListener
    {
   public  static IAPManager Instance { get; set; }
        private static IStoreController m_StoreController;          // The Unity Purchasing system.
        private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

        public static string Product150Credits = "150credits";
        public static string Product500Credits = "500credits";
        public static string Product1200Credits = "1200credits";
        public static string kProductIDNonConsumable = "nonconsumable";
        public static string kProductIDSubscription = "subscription";

    private void Awake()
    {
        Instance = this;
    }
    void Start()
        {
            // If we haven't set up the Unity Purchasing reference
            if (m_StoreController == null)
            {
                // Begin to configure our connection to Purchasing
                InitializePurchasing();
            }
        }

        public void InitializePurchasing()
        {
            // If we have already connected to Purchasing ...
            if (IsInitialized())
            {
                // ... we are done here.
                return;
            }

            // Create a builder, first passing in a suite of Unity provided stores.
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            builder.AddProduct(Product150Credits, ProductType.Consumable);
            builder.AddProduct(Product500Credits, ProductType.Consumable);
            builder.AddProduct(Product1200Credits, ProductType.Consumable);

            // Kick off the remainder of the set-up with an asynchrounous call, passing the configuration 
            // and this class' instance. Expect a response either in OnInitialized or OnInitializeFailed.
            UnityPurchasing.Initialize(this, builder);
        }


        private bool IsInitialized()
        {
            // Only say we are initialized if both the Purchasing references are set.
            return m_StoreController != null && m_StoreExtensionProvider != null;
        }


        public void Buy150Credits()
        {
     
            BuyProductID(Product150Credits);
        }

        public void Buy500Credits()
        {

            BuyProductID(Product500Credits);
        }
        public void Buy1200Credits()
        {

            BuyProductID(Product1200Credits);
        }

        private void BuyProductID(string productId)
        {
            // If Purchasing has been initialized ...
            if (IsInitialized())
            {
                // ... look up the Product reference with the general product identifier and the Purchasing 
                // system's products collection.
                Product product = m_StoreController.products.WithID(productId);

                // If the look up found a product for this device's store and that product is ready to be sold ... 
                if (product != null && product.availableToPurchase)
                {
                    Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                    // ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
                    // asynchronously.
                    m_StoreController.InitiatePurchase(product);
                }
                // Otherwise ...
                else
                {
                    // ... report the product look-up failure situation  
                    Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
                }
            }
            // Otherwise ...
            else
            {
                // ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
                // retrying initiailization.
                Debug.Log("BuyProductID FAIL. Not initialized.");
            }
        }

        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            // Purchasing has succeeded initializing. Collect our Purchasing references.
            Debug.Log("OnInitialized: PASS");

            // Overall Purchasing system, configured with products for this application.
            m_StoreController = controller;
            // Store specific subsystem, for accessing device-specific store features.
            m_StoreExtensionProvider = extensions;
        }
        public void OnInitializeFailed(InitializationFailureReason error)
        {
            // Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
            Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
        }


        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            // A consumable product has been purchased by this user.
            if (String.Equals(args.purchasedProduct.definition.id, Product150Credits, StringComparison.Ordinal))
            {
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits") + 150);
            Debug.Log("Youv'e just bought 150 credits!");
            }
            // Or ... a non-consumable product has been purchased by this user.
            else if (String.Equals(args.purchasedProduct.definition.id, Product500Credits, StringComparison.Ordinal))
            {
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits") + 500);
            Debug.Log("Youv'e just bought 500 credits!");
            }
            // Or ... a subscription product has been purchased by this user.
            else if (String.Equals(args.purchasedProduct.definition.id, Product1200Credits, StringComparison.Ordinal))
            {
            PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits") + 1200);
            Debug.Log("Youv'e just bought 1200 credits!");
            }
            // Or ... an unknown product has been purchased by this user. Fill in additional products here....
            else
            {
                Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
            }
            return PurchaseProcessingResult.Complete;
        }


        public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            // A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
            // this reason with the user to guide their troubleshooting actions.
            Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
        }
    }

