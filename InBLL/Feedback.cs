using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
 
namespace BLL
{
    /// <summary>
    /// Summary description for Feedback
    /// </summary>
    public class Feedback
    {

        public static string InsertSuccessfull()
        {
            return "Data Added Successfully!";
        }

        public static string SendSuccesfully()
        {
            return "The E-mail Message Had Been Sent Successfully!";
        }
        public static string SendFailed()
        {
            return "The E-mail Message Had not Been Sent!";
        }
        public static string InsertException()
        {
            return "Error: Data Has not Been Added!";
        }

        public static string InsertExceptionUnique()
        {
            return "Error:Similar Data Already Exists!";
        }

        public static string UpdateSuccessfull()
        {
            return "Data Updated Successfully!";
        }

        public static string UpdateException()
        {
            return "Error: Data Has not Been Updated!";
        }

        public static string NoPolicy()
        {
            return "You don't have permission To do This operation!";
        }

        public static string UpdateExceptionUnique()
        {
            return "Error: Data Has not Been Updated, Similar Data Already Exists!";
        }


        public static string DeleteSuccessfull()
        {
            return "Data Deleted Successfully!";
        }


        public static string DeleteException()
        {
            return "Error: Data Has not Been Deleted!";
        }

        public static string DocumentUploaded()
        {
            return "Document Uploaded";
        }

        public static string SelectPDFFile()
        {
            return "select PDF File.";
        }

        public static string SelectFile()
        {
            return "select File.";
        }

        public static string FileRemoved()
        {
            return "File removed.";
        }

        public static string SetPolicyForUser()
        {
            return "Please set policy for this user!";
        }

        public static string SuccessfullySaved()
        {
            return "Successfully Saved.";
        }

        public static string FailedToSave()
        {
            return "Failed to save, please try again!";
        }

        public static string FileUploaded()
        {
            return "File Uploaded";

        }

        public static string DeleteException(string relatedData)
        {
            return "Error: Data Has not Been Deleted, Some Related Data Should be Deleted First(" + relatedData + ")!";
        }

        public static string NoDataFound()
        {
            return "No Data Found!";
        }

        public static string NoPermission()
        {
            return "Sorry ! You Dont have Permission";
        }

        public static string IncorrectUsernameOrPassword()
        {
            return "Incorrect username or password ";
        }

        public static string PersonnelDoesNotHaveAccessToAnyModule()
        {
            return "This Personnel does not have Access to any Module";

        }

        public static string NoPolicies()
        {
            return "No Policies on this module";
        }

        public static string PersonnelWithOutUserAccount()
        {
            return "This Personnel does not have User Account";
        }

        public static string StatusUpdateSuccessfull()
        {
            return "Your Status Updated Sucessfully!";
        }

        public static string SetPolicy()
        {
            return "Please Set User Policy!";
        }

        public static string UploadException()
        {
            return "Error: File Has not Been Uploaded!";
        }

        public static string UploadRetry()
        {
            return "Error: File Has not Been Uploaded,Try Again!";
        }

        public static string confirmedExpetion()
        {
            return "Error: Data Has not Been confirmed!";
        }

        public static string NoData()
        {
            return "There's no data to show!";
        }

        public static string OperationFailed()
        {
            return "Error: Operation failed!";
        }

        public static string OperationSuccessfully()
        {
            return "Operation done successfully";
        }


        public static string PaymentDone()
        {
            return " Payment Done";
        }

        public static string PaymentException()
        {
            return "Error! Payment Not Done"; 
        }

        public static string ExceptionRequestPaid()
        {
            return "Request is Paid, Can not Manage or Update this Lab Request";
        }

        public static string DeleteExceptionPK()
        {
            return "Cant Delete This, Its Used Somewhere Else";
        }

        // Malay
        
        public static string TransferCompletedSuccessfully()
        {
            return "Transfer Completed Successfully ";
        }

        public static string TransferException()
        {
            return "Error: Transfer is Not Completed";
        }

        // Milind  

        public static string TransactionComplete()
        {
            return "Transaction Completed Successfully ";
        }

        public static string TransactionException()
        {
            return "Error: Transaction is Not Completed";
        }

        public static string ItemOutOfStock()
        {
            return "Your Quantity is greater than Stock you have!";
        }

        public static string QuantityCantBe0()
        {
            return "Quantity Cant Be 0";
        }

        //Bhumika 

        public static string OperatinCantBeEdit()
        {
            return "The invoice operation can not be updated, because the invoice is already canceled";
        }

        public static string CancelSuccesfully()
        {
            return "Operation is canceled succesfully";
        }
        public static string CancelException()
        {
            return "Error: Operation is not canceled";
        }

        public static string DataAlreadyExist()
        {
            return "Error: Data already exist!";
        }

        public static string RemoveSuccessfully()
        {
            return "The tyre is removed Successfully";
        }

        public static string DriverAlreadyHasTruck()
        {
            return "This Driver is already selected in another truck";
        }

        public static string NotificationExpired()
        {
            return "This Notification alert has been expired! Please update the notification";
        }

        public static string PhotoExtensionNotAllowed()
        {
            return "Photo extension is not allowed";
        }

        public static string PhotoSizeExceedingAllowedSize()
        {
            return "Photo exceeds the allowed size";
        }

        public static string PhotoRequired()
        {
            return "Photo is required!";
        }

        public static string LoginFailed()
        {
            return "Login Failed: Please check your username or password!";
        }
    }
}