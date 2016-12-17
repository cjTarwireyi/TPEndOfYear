using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusineesLogic.domain;

/// <summary>
/// Summary description for AccountDTO
/// </summary>
public class AccountDTO
{
    public int accountNumber { get; set;}
    public CustomerDTO customer { get; set; }

    public AccountDTO() { }
    public AccountDTO(AccountBuilder account)
    {
        this.accountNumber = account.accountNumber;
        this.customer = account.customer;
    }

    public class AccountBuilder
    {
        public int accountNumber;
        public CustomerDTO customer;

        public AccountBuilder buildID(int accountNumber)
        {
            this.accountNumber = accountNumber;
            return this;
        }
        public AccountBuilder buildCustomer(CustomerDTO customer)
        {
            this.customer = customer;
            return this;
        }

        public AccountBuilder copy(AccountDTO account)
        {
            this.accountNumber = account.accountNumber;
            this.customer = account.customer;
            return this;
        }

        public AccountDTO build()
        {
            return new AccountDTO(this);
        } 
    }


}