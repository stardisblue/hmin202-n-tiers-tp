using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://stardis.blue/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Today : System.Web.Services.WebService
{
    public Today () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string getDayOfMonth() {
        return DateTime.Today.Day.ToString();
    }
    
}