using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using PetaPoco;

namespace MixERP.Net.Api.Transactions
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Customer Receipts.
    /// </summary>
    [RoutePrefix("api/v1.5/transactions/customer-receipt")]
    public class CustomerReceiptController : ApiController
    {
        /// <summary>
        ///     The CustomerReceipt data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Transactions.Data.CustomerReceipt CustomerReceiptContext;

        public CustomerReceiptController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.CustomerReceiptContext = new MixERP.Net.Schemas.Transactions.Data.CustomerReceipt
            {
                Catalog = this.Catalog,
                LoginId = this.LoginId
            };
        }

        public long LoginId { get; }
        public int UserId { get; private set; }
        public int OfficeId { get; private set; }
        public string Catalog { get; }

        /// <summary>
        ///     Counts the number of customer receipts.
        /// </summary>
        /// <returns>Returns the count of the customer receipts.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        public long Count()
        {
            try
            {
                return this.CustomerReceiptContext.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Returns an instance of customer receipt.
        /// </summary>
        /// <param name="receiptId">Enter ReceiptId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{receiptId}")]
        public MixERP.Net.Entities.Transactions.CustomerReceipt Get(long receiptId)
        {
            try
            {
                return this.CustomerReceiptContext.Get(receiptId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 customer receipts on each page, sorted by the property ReceiptId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        public IEnumerable<MixERP.Net.Entities.Transactions.CustomerReceipt> GetPagedResult()
        {
            try
            {
                return this.CustomerReceiptContext.GetPagedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 customer receipts on each page, sorted by the property ReceiptId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Transactions.CustomerReceipt> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.CustomerReceiptContext.GetPagedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Displayfields is a lightweight key/value collection of customer receipts.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of customer receipts.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.CustomerReceiptContext.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds your instance of Account class.
        /// </summary>
        /// <param name="customerReceipt">Your instance of customer receipts class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{customerReceipt}")]
        public void Add(MixERP.Net.Entities.Transactions.CustomerReceipt customerReceipt)
        {
            if (customerReceipt == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.CustomerReceiptContext.Add(customerReceipt);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Edits existing record with your instance of Account class.
        /// </summary>
        /// <param name="customerReceipt">Your instance of Account class to edit.</param>
        /// <param name="receiptId">Enter the value for ReceiptId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{receiptId}/{customerReceipt}")]
        public void Edit(long receiptId, MixERP.Net.Entities.Transactions.CustomerReceipt customerReceipt)
        {
            if (customerReceipt == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.CustomerReceiptContext.Update(customerReceipt, receiptId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Deletes an existing instance of Account class via ReceiptId.
        /// </summary>
        /// <param name="receiptId">Enter the value for ReceiptId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{receiptId}")]
        public void Delete(long receiptId)
        {
            try
            {
                this.CustomerReceiptContext.Delete(receiptId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}