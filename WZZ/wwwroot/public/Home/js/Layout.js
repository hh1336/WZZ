
$(document).on("click", "ul.nav li", function (e) {
    if ($(this).attr("controller") === "Home") return;
    e.preventDefault();
    var controller = $(this).attr("controller");
    var url = "/" + controller + "/Index";
    $.post(url, {}, function (html) {
        $("#content").html(html);
    });
});
