/***********************************
/* 创建人：wyq
/* 修改日期：2013-5-6
/* 左侧菜单折叠效果和选中效果
***********************************/

$(function () {
    $("#_" + select).addClass("current");
    $(".side-bx-bd").each(function (index, dom) {
        $(dom).find("li:last").css("background", "none"); ;
    });
    $(".side-bx-bd li a").click(function () {
        //给菜单添加选中效果
        $(".side-bx-bd li a").removeClass("current");
        $(this).addClass("current");
        select = $(this).attr("id").substring(1);
    });
    $("div .side-bx-title").click(function () {
        //给菜单添加点击标题出现折叠效果
        var box = $(this).parent();
        var content = $(this).next();
        if (box.attr('class').indexOf("side-bx-toggled") > -1) {
            box.removeClass("side-bx-toggled");
            content.css("display", "block");
        }
        else {
            box.addClass("side-bx-toggled");
            content.css("display", "none");

        }
    });
});