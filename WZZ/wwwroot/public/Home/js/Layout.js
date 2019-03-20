function loadwebinfo() {
    $.post("/Home/GetWebInfo", { id: 1 }, function (result) {
        $("#phone").text(result.phone);
        var imgdiv = $(".logimg");
        $(imgdiv).each(function (index, dom) {
            $(dom).attr("src", "http://localhost:62320" + result.imgurl);
        });
        $(".footersubheading").text(result.subheading);
    });
    $.post("/Home/GetModel", { id: 13 }, function (result) {
        var li = ``;
        for (var i = 0; i < result.length; i++) {
            if (i > 5) {
                continue;
            }
            li += `<li onclick="ModalArticle(` + result[i].id +`)">
                            <i class="fa `+ result[i].icon + `" aria-hidden="true"></i>
                            <span>`+ result[i].name +`</span>
                        </li>`;
        }
        $(".topicon").html(li);
    });
}

function ModalArticle(id) {
    $.post("/Home/GetModelArc", { id: id }, function (result) {
        $("#content").html(result);
    });
}

function SelectArticle(id) {
    window.open("/Home/SelectArticle?id=" + id, "_blank");
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