// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class Common {
    static GetSession(key, callback) {
        $.ajax({
            url: "/Home/GetSessionValue",
            type: "post",
            dataType: "json",
            data: { key: key },
            async: false
        }).done(function (value) {
            callback(value);
        });
    }
    static SetSession(key, val) {
        $.post("/Home/SetSession", { key: key, value: val });
    }


}

