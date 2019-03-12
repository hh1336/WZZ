
$(document).on("click", "ul.navlist li", function (e) {
    if ($(this).attr("controller") === "Home") return;
    e.preventDefault();
    var controller = $(this).attr("controller");
    $.post("/" + controller + "/Index", {}, function (html) {
        $("#container").html(html);
    });
});
