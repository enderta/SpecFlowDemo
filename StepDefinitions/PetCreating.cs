[Binding]
public class PetStoreSteps
{
    [Given(@"I have the following pet data:")]
    public void GivenIHaveTheFollowingPetData(Table table)
    {
        string name = table.Rows[0]["name"];
        string category1 = table.Rows[0]["category"];
        string status = table.Rows[0]["status"];
        //int statusCode = int.Parse(dataTable[0]["statusCode"].ToString());
        Dictionary<string, object> bdy = new Dictionary<string, object>();
        bdy.Add("id", 0);

        //serialize the body to json by using gson
        Dictionary<string, object> requestBody = new Dictionary<string, object>();
        requestBody.Add("id", 0);

        Dictionary<string, object> category = new Dictionary<string, object>();
        category.Add("id", 0);
        category.Add("name", category1);
        requestBody.Add("category", category);

        requestBody.Add("name", name);

        List<string> photoUrls = new List<string>();
        photoUrls.Add("string");
        requestBody.Add("photoUrls", photoUrls);

        List<Dictionary<string, object>> tags = new List<Dictionary<string, object>>();
        Dictionary<string, object> tag = new Dictionary<string, object>();
        tag.Add("id", 0);
        tag.Add("name", "string");
        tags.Add(tag);
        requestBody.Add("tags", tags);

        requestBody.Add("status", status);








    }

    [When(@"I send a POST request to ""/pet"" with the provided pet data")]
    public void WhenISendAPostRequestToPetWithTheProvidedPetData()
    {
      

    }

    [Then(@"the response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int statusCode)
    {
        // Code to assert the response status code
    }

    [Then(@"the response should contain the created pet details")]
    public void ThenTheResponseShouldContainTheCreatedPetDetails()
    {
        // Code to assert the response contains the created pet details
    }
}