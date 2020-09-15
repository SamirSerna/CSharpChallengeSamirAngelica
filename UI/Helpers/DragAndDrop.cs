using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BusinessSolution.Helpers
{
    public class DragAndDrop
    {
        public Actions actions;

        public void MoveAnElement(IWebElement _source, IWebElement _target, Actions actions)
        {
            actions.DragAndDrop(_source, _target).Build().Perform();              
        }
    }
}
