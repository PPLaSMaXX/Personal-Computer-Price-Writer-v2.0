using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
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

            // Selecting all products in list
            IHtmlCollection<IElement> parsedProducts = document.QuerySelectorAll(".list-item--goods a[id^=product]");


            foreach (IHtmlAnchorElement productLink in parsedProducts)
            {
                // Loading product page HTML code
                IDocument productDocument = await BrowsingContext.New(config).OpenAsync(productLink.Href);

                // Selecting data with selectors
                IHtmlCollection<IElement> ICategory = productDocument.QuerySelectorAll(".t2");
                IHtmlCollection<IElement> IPrice = productDocument.QuerySelectorAll(".desc-big-price span:first-child");
                IHtmlCollection<IElement> IName = productDocument.QuerySelectorAll(".t2 b");

                // Getting category from HTML
                string category = Regex.Match(ICategory[0].InnerHtml, @"^([\w\-]+)").Value;

                products.Add( new ParsedProduct(category, RemoveSpace(IPrice[0].TextContent), IName[0].TextContent));
            }

            return products;
        }

        private string RemoveSpace(string input)
        {
            string result = null;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].IsDigit())
                {
                    result += input[i];
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
