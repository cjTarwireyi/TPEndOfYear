using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusineesLogic.domain;

/// <summary>
/// Summary description for CustomerFactory
/// </summary>
public class CustomerFactory
{
    public static CustomerDTO getCustomer(int number,List<string> customerDetails)
    {
        return new CustomerDTO.CustomerBuilder()
        .custName(customerDetails[0])
        .custSurname(customerDetails[1])
        .custCellNumber(customerDetails[2])
        .custAddress(customerDetails[3],customerDetails[4],customerDetails[5])
        .custEmail(customerDetails[6])
        .accountCreatedDate(customerDetails[7])
        .build();
    }
}