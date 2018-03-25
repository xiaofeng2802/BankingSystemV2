﻿using BankingSystem.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Business
{
    public class CurrenciesTestAPI
    {
        private List<string> SupportedCurrencies = new List<string>() { "THB", "USD" };

        public Task<CurrenciesResponse> RequestCurrenciesAsyn(string inputCurrency)
        {
            return new Task<CurrenciesResponse>(() => {

                if (!SupportedCurrencies.Any(a => a == inputCurrency))
                {
                    throw new Exception("Unsupported currencies.");
                }

                CurrenciesResponse result = new CurrenciesResponse()
                {
                    BaseCurrency = inputCurrency
                };

                if (inputCurrency == "THB")
                {
                    result.Rates.Add("USD", 0.032);
                }
                else if (inputCurrency == "USD")
                {
                    result.Rates.Add("USD", 31.21);
                }

                return result;
            });
        }

    }
}