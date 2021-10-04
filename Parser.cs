using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCPW2
{
    class Parser
    {
        public async Task<List<ParsedProduct>> ParseLink(string link)
        {
            if (!CheckInternetConnection(link)) return null;

            List<ParsedProduct> products = new List<ParsedProduct>();

            // Cheking link for correctness
            if (!ValidateLink(link))
            {
                MessageBox.Show("Error: Link is not valid or empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            IConfiguration config = Configuration.Default.WithDefaultLoader();

            // Loading page HTML code
            IDocument document = await BrowsingContext.New(config).OpenAsync(link);

            // Selecting data with selectors
            IHtmlCollection<IElement> parsedPrices = document.QuerySelectorAll("td.model-hot-prices-td [id^=price], [class$=ib] span:first-child, [class$=model-hot-prices-not-avail]");
            IHtmlCollection<IElement> parsedNames = document.QuerySelectorAll("td.model-short-info table span.u");
            List<int> parsedPrices = new List<int>();

            foreach (IElement IElement in parsedPrices)
            {
                // Removing all non-digits;
                IElement.TextContent = RemoveSpace(IElement.Text());
            }

                }
                else if (documentTemp.QuerySelector("[id^=price]") != null)
                {
                    temp = IElement.QuerySelector("[id^=price]").TextContent.ToString();
                    temp = RemoveSpace(temp);
                }
                else if (documentTemp.QuerySelector("[class$=model-hot-prices-not-avail]") != null)
                {
                    temp = "0";
                }
                parsedPrices.Add(int.Parse(temp));
            }

            // Adding data to list of produtcs
            for (int i = 0; i < parsedNames.Length && i < parsedPrices.Count; i++)
            {

                products.Add(new ParsedProduct(parsedNames[i].Text(), parsedPrices[i]));

            }

            return products;
        }

        private string RemoveSpace(string input)
        {
            string result = null;
            for (int z = 0; z < input.Length; z++)
            {
                if (input[z].IsDigit())
                {
                    result += input[z];
                }
            }
            return result;
        }

        private bool ValidateLink(string link)
        {
            return Uri.TryCreate(link, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private static bool CheckInternetConnection(string link)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                request.KeepAlive = false;
                request.Timeout = 10000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
