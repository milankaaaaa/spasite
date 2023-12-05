using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace spasite.Components
{
    internal class Navigation
    {
        private Frame mainFrame;

        public Navigation(Frame mainFrame)
        {
            this.mainFrame = mainFrame;
        }
        public void NavigateToPage(Page page)
        {
            mainFrame.Navigate(page);
        }
        public void GoBack()
        {
            if (mainFrame.CanGoBack)
            {
                mainFrame.GoBack();
            }
        }
        public void GoForward()
        {
            if (mainFrame.CanGoForward) ;
            {
                mainFrame.GoForward();
            }
        }
        public void Refresh()
        {
            mainFrame.Refresh();
        }
    } 
}  
