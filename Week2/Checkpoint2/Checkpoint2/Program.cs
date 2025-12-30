// Assignment: Checkpoint2 Product list
// Teacher: ernst.ras1@lexutb.se
// Pupil: fredrik@chronqvist.com

//using System.Xml.Linq;
//using static System.Net.Mime.MediaTypeNames;
using Checkpoint2;

ProductList productList = new ProductList();


while (true)
{
    ProgramInput programInput = new ProgramInput();
    programInput.AddProduct(productList);
    productList.ListProducts();
    bool endApplication = programInput.InputChoice(productList);
    if (endApplication)
    {
        break;
    }
}