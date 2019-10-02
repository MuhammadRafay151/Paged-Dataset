using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PagedDataSet
//This library has been developed by Muhammad Rafay
//Github url:https://github.com/MuhammadRafay151....
{/// <summary>
/// convert dataset to paged dataset
/// </summary>
    public class PagedDataSet
    {//formula to calculate total pages 
        //i have divided total row by per page this will tell us the number of pages for the current dataset the value getting after division tell that you can send atmost n numbers of row to the current page
        private double? TotalPages { get; set; }
        /// <summary>
        ///Return dataset containing data for the page number which will be passed as argument
        /// </summary>
        /// <param name="dataSet">Pass filled data set to convert in pages</param>
        /// <param name="PerPage">Rows per page</param>
        /// <param name="PageNo">Page Number you want to get</param>
        /// <returns>Dataset containing data for the page number which will be passed as argument</returns>
        /// <exception cref="IncorrectPageNoException"></exception>
        ///  <exception cref="EmptyDataSetException"></exception>
        public DataSet GetPage(DataSet dataSet, int PerPage, int? PageNo)
        {
            
            if (PageNo.HasValue && PageNo.Value > 0)
            {
                
                int limit = PageNo.Value * PerPage;
                
                int Start = (limit - PerPage);
                //eg 12/2=6 this tells that 12rows can take 6 pages if you set 2 rows per page so if we multiply 2 by 6 then its 12 again ceiling function is for odd number of rows so that we get nearest greater integer for pages.
                TotalPages = Math.Ceiling((double)dataSet.Tables[0].Rows.Count / PerPage);
                System.Data.DataSet ds1 = new System.Data.DataSet();
                ds1 = dataSet.Clone();


                for (int i = Start; i < limit; i++)
                {
                    try
                    {
                        ds1.Tables[0].ImportRow(dataSet.Tables[0].Rows[i]);
                    }
                    catch (IndexOutOfRangeException) { }
                   
                }
                return ds1;
            }
            else
            {

                throw new IncorrectPageNoException();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Throw acception if this is called before getpage()</exception>
        public Double GetTotalPages()
        {
            if (TotalPages != null)
            {
                return TotalPages.Value;
            }
            else
            {
                throw new ArgumentException("No Dataset Found");
            }
        }
        
    }
}
