
//º”‘ÿ≤Àµ•
function GetModel(pid, callback) {
    if (pid === undefined) {
        pid = "";
        $.post("/Home/GetModel", { pid: pid }, function (result) {
            for (var i = 0; i < result.length; i++) {
                var listr = "";
                GetModel(result[i].id, function (da) {
                    listr = da;
                });
                var str = `
                <li>
                    <a href="#tit` + result[i].id + `" data-toggle="collapse" class="collapsed" aria-expanded="false"><i class="glyphicon glyphicon-th-large"></i> 
                        <span>`+ result[i].name + `</span> 
                        <i class="icon-submenu lnr lnr-chevron-left"></i>
                                <div id="tit`+ result[i].id + `" class="collapse" aria-expanded="false" style="height: 0px;">
                                    <ul class="nav">
                                        `+ listr + `
                                    </ul>
                                </div>
                    </a>
                </li>`;

                $("#headul").append(str);

            }
        });
    } else {
        $.ajax({
            url: "/Home/GetModel",
            data: { pid: pid },
            dataType: "json",
            type: "post",
            async: false
        }).done(function (data) {
            var li = "";
            for (var s = 0; s < data.length; s++) {
                li += "<li><a href=''>" + data[s].name + "</a></li>";
            }
            callback(li);
        });
    }
}


$(function () {
    $("#headul").ready(function () {
        GetModel();
    });

    $.post("/Home/GetSession", { key: "username" }, function (result) {
        $("#username").text(result.nickname).prev().attr("src", result.portraitUrl);
    });


    //var data, options;

    //// headline charts
    //data = {
    //    labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
    //    series: [
    //        [23, 29, 24, 40, 25, 24, 35],
    //        [14, 25, 18, 34, 29, 38, 44]
    //    ]
    //};

    //options = {
    //    height: 300,
    //    showArea: true,
    //    showLine: false,
    //    showPoint: false,
    //    fullWidth: true,
    //    axisX: {
    //        showGrid: false
    //    },
    //    lineSmooth: false
    //};

    //new Chartist.Line('#headline-chart', data, options);


    // visits trend charts
    /*	data = {
            labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            series: [{
                name: 'series-real',
                data: [200, 380, 350, 320, 410, 450, 570, 400, 555, 620, 750, 900],
            }, {
                name: 'series-projection',
                data: [240, 350, 360, 380, 400, 450, 480, 523, 555, 600, 700, 800],
            }]
        };
 
        options = {
            fullWidth: true,
            lineSmooth: false,
            height: "270px",
            low: 0,
            high: 'auto',
            series: {
                'series-projection': {
                    showArea: true,
                    showPoint: false,
                    showLine: false
                },
            },
            axisX: {
                showGrid: false,
 
            },
            axisY: {
                showGrid: false,
                onlyInteger: true,
                offset: 0,
            },
            chartPadding: {
                left: 20,
                right: 20
            }
        };
 
        new Chartist.Line('#visits-trends-chart', data, options);
 
*/
    /*// visits chart
    data = {
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
        series: [
            [6384, 6342, 5437, 2764, 3958, 5068, 7654]
        ]
    };
 
    options = {
        height: 300,
        axisX: {
            showGrid: false
        },
    };
 
    new Chartist.Bar('#visits-chart', data, options);
 
 
	
    */



});
