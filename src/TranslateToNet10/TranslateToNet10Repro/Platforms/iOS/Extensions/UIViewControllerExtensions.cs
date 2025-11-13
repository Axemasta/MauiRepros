using UIKit;

namespace TranslateToNet10Repro;

public static class UIViewControllerExtensions
{
    public static void SetModalInPresentation(this UIViewController viewController, bool modalInPresentation)
    {
        if (!UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
        {
            return;
        }

        viewController.ModalInPresentation = modalInPresentation;

        if (viewController.ParentViewController is not null)
        {
            viewController.ParentViewController.SetModalInPresentation(modalInPresentation);
        }
    }
}