(function () {
    "use strict";

    function shouldHideOnError(img) {
        // Default policy: hide broken images unless explicitly opted out.
        var policy = img.getAttribute("data-hide-on-error");
        return policy === null || policy.toLowerCase() !== "false";
    }

    function hideBrokenImage(img) {
        if (!shouldHideOnError(img)) {
            return;
        }

        img.style.display = "none";
        img.setAttribute("aria-hidden", "true");
    }

    function onResourceError(event) {
        var target = event && event.target;
        if (!(target instanceof HTMLImageElement)) {
            return;
        }

        hideBrokenImage(target);
    }

    // Capture phase is required because "error" does not bubble.
    document.addEventListener("error", onResourceError, true);
})();
