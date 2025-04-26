window.navigationHelper = {
    initialize: function () {
        document.addEventListener("DOMContentLoaded", function () {
            document.querySelectorAll("a").forEach(anchor => {
                anchor.addEventListener("click", function (event) {
                    if (!anchor.hasAttribute("data-no-animation")) {
                        event.preventDefault();
                        navigationHelper.startSlideOut(() => {
                            window.location.href = anchor.getAttribute("href");
                        });
                    }
                });
            });
        });

        window.addEventListener("popstate", function () {
            navigationHelper.startSlideOut(() => history.back());
        });

        window.addEventListener("beforeunload", function () {
            navigationHelper.addSlideOutClass();
        });
    },

    startSlideOut: function (callback) {
        let element = document.querySelector('.content-container');
        if (element) {
            element.classList.add('slide-out');
            setTimeout(callback, 300);
        } else {
            callback();
        }
    },

    addSlideOutClass: function () {
        let element = document.querySelector('.content-container');
        if (element) {
            element.classList.add('slide-out');
        }
    }
};