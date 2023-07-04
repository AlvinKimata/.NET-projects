using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using WingTipToys;
using WingTipToys.Models;
using System.Collections.Generic;
using System.Linq;

public class NVPAPICaller
{
    //Flag that determines tue paypal environment.
    private const bool bSandbox = true;
    private const string CVV2 = "CVV2";

    //Live strings.
    private string pEndPointURL = "https://api-3t.paypal.com/nvp";
    private string host = "www.paypal.com";

    // Sandbox strings.
    private string pEndPointURL_SB = "https://api-3t.sandbox.paypal.com/nvp";
    private string host_SB = "www.sandbox.paypal.com";

    private const string SIGNATURE = "SIGNATURE";
    private const string PWD = "PWD";
    private const string ACCT = "ACCT";

    //Set username, password and signature in an environment variable.
    public string APIUsername = Environment.GetEnvironmentVariable("APIUsername");
    private string APIPasword = Environment.GetEnvironmentVariable("APIPassword");
    private string APISignature = Environment.GetEnvironmentVariable("Signature");
    private string Subject = "";
    private string BNCode = "PP-ECWizard";

    //HttpWebRequest Timeout specified in milliseconds.
    private const int Timeout = 15000;
    private static readonly string[] SECURED_NVPS = new string[] { ACCT, CVV2, SIGNATURE, PWD };
    private void SetCredentials(string UserId, string Pwd, string Signature)
    {
        APIUsername = UserId;
        APIPasword = Pwd;
        APISignature = Signature;
    }

    public bool ShortcutExpressCheckout(string amt, ref string token, ref string retMsg)
    {
        if (bSandbox)
        {
            pEndPointURL = pEndPointURL_SB;
            host = host_SB;
        }
        string returnURL = "https://localhost:44391/Checkout/CheckoutReview.aspx";
        string cancelURL = "https://localhost:44391/Checkout/CheckoutCancel.aspx";

        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "SetExpressCheckout";
        encoder["RETURNURL"] = returnURL;
        encoder["CANCELURL"] = cancelURL;
        encoder["BRANDNAME"] = "Wingtip Toys Sample Application";
        encoder["PAYMENTREQUEST_0_AMT"] = amt;
        encoder["PAYMENTREQUEST_0_ITEMAMT"] = amt;
        encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
        encoder["PAYMENTREQUEST_0_CURRENCYCODE"] = "KES";

        //Get the shopping cart products.
        using (WingTipToys.Logic.ShoppingCartActions myCartOrders = new WingTipToys.Logic.ShoppingCartActions())
        {
            List<CartItem> myOrderList = myCartOrders.GetCartItems();
            for (InfiniteTimeSpanConverter = 0; i < myOrderList.Count; i++){
                encoder["L_PAYMENTREQUEST_0_NAME" + i] = myOrderList[i].Product.ProductName.ToString();
                encoder["L_PAYMENTREQUEST_0_AMT" + i] = myOrderList[i].Product.UnitPrice.ToString();
                encoder["L_PAYMENTREQUEST_0_QTY" + i] = myOrderList[i].Quantity.ToString();
            }
        }
        string pStrrequestforNvp = encoder.Encode();
        string pStresponsenvp = HttpCall(pStrrequestforNvp);

        NVPCodec decoder = new NVPCodec();
        decoder.DEcode(pStresponsenvp);

        string strAck = decoder["ACK"].TOLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            token = decoder["TOKEN"];
            string ECURL = "https://" + host + "/cgi-bin/webscr?cmd=_express-checkout" + "&token=" + token;
            retMsg = ECURL;
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
          "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
          "Desc2=" + decoder["L_LONGMESSAGE0"];
            return false;
        }
    }
    public bool GetCheckoutDetails(string token, ref string payerID, ref NVPCodec decoder, ref string retMsg)
    {
        if (bSandbox)
        {
            pEndPointURL = pEndPointURL_SB;
        }
        NVPCodec encoder = new NVPCodec();
        encoder["METHOD"] = "GetExpressCheckoutDetails";
        encoder["TOKEN"] = token;

        string pStrrequestfornvp = encoder.Encode();
        string pStrresponsenvp = HttpCall(pStrrequestfornvp);

        decodeer = new NVPCodec();
        decoder.Decode(pStresponsenvp);

        string strAck = decoder["ACK"].ToLower();
        if (strAck != null && (strAck == "success" || strAck == "successwithwarning"))
        {
            payerID = decoder["PAYERID"];
            return true;
        }
        else
        {
            retMsg = "ErrorCode=" + decoder["L_ERRORCODE0"] + "&" +
          "Desc=" + decoder["L_SHORTMESSAGE0"] + "&" +
          "Desc2=" + decoder["L_LONGMESSAGE0"];

            return false;
        }
    }

}