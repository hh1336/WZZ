function loadwebinfo() {
    $.post("/Home/GetWebInfo", { id: 1 }, function (result) {
        $("#phone").text(result.phone);
        var imgdiv = $(".logimg");
        $(imgdiv).each(function (index, dom) {
            $(dom).attr("src", "http://localhost:62320" + result.imgurl);
        });
        $(".footersubheading").text(result.subheading);
    });
}
$(document).on("click", "ul.nav li", function (e) {
    if ($(this).attr("controller") === "Home") return;
    e.preventDefault();
    var controller = $(this).attr("controller");
    var url = "/" + controller + "/Index";
    $.post(url, {}, function (html) {
        $("#content").html(html);
    });
});
$(function () {
    loadwebinfo();
});