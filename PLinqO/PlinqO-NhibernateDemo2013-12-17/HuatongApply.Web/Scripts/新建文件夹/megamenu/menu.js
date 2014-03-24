/***********************************
/* 创建人：xwf
/* 修改人：xwf,wsl
/* 修改日期：2013-5-23,2013-6-19
/* 大菜单效果和左侧切换选择效果,加了桌面跳转到起始页功能
/* 依赖：easyloader.js,easyui.config.js
***********************************/
var referenceModules = $.merge(['sidemenu'], easyloader.defaultReferenceModules);
var select, oldId;  //级联选中
using(referenceModules, function () {
    $('#home').load("Views/FirstPage/FirstPage.htm"); //加载起始页
    //桌面单击效果
    $("#desktop").click(function () {
        oldId = null;
        $("#home,#west,#center").toggle();
    });
    $('#sidemenuTemplate').load("Scripts/side-menu/SideMenuTemplate.htm", function () {
        ajaxCRUD({
            url: '/WebServices/AdminWebService/UserWebService/UserWebService.asmx/GetUserRights',
            success: function (data) {
                //左侧导航
                var source = $("#sideMenu-template").html();
                template = Handlebars.compile(source);

                for (var i = 0; i < data.length; i++) {
                    var c = { menu: data[i].RightBoList };
                    var menu = i;
                    if (data[i].Code == 'SY') {
                        menu = 100;
                        $("#system").after('<li><a id="' + data[i].Code + '" class="menu_green_titlelink_ullinks" style=\"cursor:pointer\" onclick="systemClick()" ref="' + data[i].Url + '">控制面板</a></li>');
                    }
                    if (data[i].Code == 'SY' || data[i].Code == 'WEBSITE') data.splice(i, data.length);
                    $("#left_menu").append('<div class="left_menu' + menu + '">' + template(c) + '</div>');

                }
                //顶部导航
                var context = { menu: data };
                source = $("#topMenu-template").html();
                var template = Handlebars.compile(source);
                $("#megamenu").append(template(context));

                $('#megamenu').megaMenuCompleteSet({
                    menu_speed_show: 0, // Time (in milliseconds) to show a drop down
                    menu_speed_hide: 0, // Time (in milliseconds) to hide a drop down
                    menu_speed_delay: 0, // Time (in milliseconds) before showing a drop down
                    menu_effect: 'hover_slide', // Drop down effect, choose between 'hover_fade', 'hover_slide', etc.
                    menu_click_outside: 1, // Clicks outside the drop down close it (1 = true, 0 = false)
                    menu_show_onload: 0 // Drop down to show on page load (type the number of the drop down, 0 for none)

                });

                //添加菜单标题样式
                $("#megamenu .drop3columns").find(".col_3:last ul").addClass("botmnone");
                $(".drop3columns .col_3 a").click(function () {
                    $(".dropcontent").hide();
                });
            }
        });
    });
});

function menuClick(obj, isTop) {
    if (oldId == null) {
        $('#home').hide();
        $('#west,#center').show();
    }
    var $this = $(obj);
    var id = $this.parents("div").parents("li").val(); //获取选中的大菜单内容
    if (oldId != id) {
        $("#megamenu .selectLink").removeClass("selectLink"); //移除大菜单选中样式
        $this.parents("li").find(".drop").addClass("selectLink"); //大菜单选中样式
        var html = $("#left_menu .left_menu" + id).html();
        $('#west').html(html);
        oldId = id;
    }

    if (isTop == 1) {//点击顶级菜单默认获取底下第一个元素来选中
        select = $this.parent().next().find("li:eq(0) a").attr("id");
    } else {
        select = $this.attr("id");
    }

    $("#_" + select).click();
}

function systemClick() {
    if (oldId == 100) return;
    if (oldId == null) {
        $('#home').hide();
        $('#west,#center').show();
    } else {
        $("#megamenu .selectLink").removeClass("selectLink"); //移除大菜单选中样式
    }
    var html = $("#left_menu .left_menu100").html();
    $('#west').html(html);
    select = $("#left_menu .left_menu100 .first ul a:eq(0)").attr("id");
    $("#" + select).click();
    oldId = 100;
}


//加载列表
var loadTrue = true;
function loadListPage(obj) {
    if (loadTrue) {
        loadTrue = false;
        $.ajax({
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            url: 'WebServices/AdminWebService/UserWebService/UserWebService.asmx/LoginRequired',
            data: "",
            success: function (data) {
                //验证用户是否登录,未登录跳转到登录页.
                if (data.d) {
                    $("[id^=dlg]").each(function () {
                        if ($(this).parent().hasClass('window') && $(this).hasClass('panel-body')) {
                            $(this).dialog('destroy');
                        }
                    });
                    //关闭高级搜索
                    var eastPanel = $('#layout').layout('panel', 'east');
                    if (eastPanel.length > 0) {
                        $('#layout').layout('remove', 'east');
                    }

                    //加载列表
                    $('#layout').layout('panel', 'center').panel({
                        href: $(obj).attr("ref"),
                        onLoad: function () {
                            var code = $(obj).attr("id").substr(1);
                            ajaxCRUD({
                                async: false,
                                url: 'WebServices/AdminWebService/RightWebService/RightWebService.asmx/GetRightByCode',
                                data: "{code:'" + code + "'}",
                                success: function (d) {
                                    //加载工具栏权限
                                    var template = Handlebars.compile("{{#linkbtn Rows}}{{/linkbtn}}");
                                    $("#toolbar").find("#operatebtns").append(template(d));
                                    setTimeout(function () { $("#formTemplate").find("#dlg-buttons").empty().append(dilBtn); $(".easyui-linkbutton").linkbutton(); }, 1000);


                                    $(".easyui-linkbutton").linkbutton();
                                    loadTrue = true;
                                }
                            });
                        }
                    });
                } else {
                    window.location.href = "/login.aspx";
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                window.location.href = "/login.aspx";
            }
        });
    }
}
var dilBtn;
Handlebars.registerHelper('linkbtn', function (items) {
    var out = '';
    for (var i = 0; i < items.length; i++) {
        if (items[i].Name == "新增" || items[i].Name == "编辑") {
            var btn1 = btnType(items[i].Name);
            dilBtn = '<a class="easyui-linkbutton" id="submit"  onclick="sure(this)">确定</a> <a class="easyui-linkbutton" onclick="closeFormDialog();">取消</a>';
        }
        var btn = btnType(items[i].Name);
        out += '<a class="easyui-linkbutton" iconcls="' + btn.i + '" plain="true" onclick="' + btn.c + ';">' + btn.n + '</a>';
    }
    return out;
});

function sure(obj) {
    if (!formValidate('ff')) {
        return;
    }
    $(obj).parent().prepend('<b id="note">提交中...</b>');
    $('#submit').hide();
    saveData();
    $('#submit').show();
    $('#note').remove();
}

function btnType(name) {
    var btn = [];
    btn.push({ "n": "新增", "c": "addData()", "i": "icon-add" });
    btn.push({ "n": "编辑", "c": "editData()", "i": "icon-edit" });
    btn.push({ "n": "删除", "c": "deleteDatas()", "i": "icon-remove" });
    btn.push({ "n": "查看", "c": "viewData()", "i": "icon_view" });
    btn.push({ "n": "退票", "c": "refund()", "i": "icon-no" });
    btn.push({ "n": "退单", "c": "cancelTicket()", "i": "icon-no" });
    btn.push({ "n": "核票", "c": "checkTicket()", "i": "icon_audit" });
    btn.push({ "n": "禁用", "c": "disableDatas()", "i": "icon_disable" });
    btn.push({ "n": "启用", "c": "enableDatas()", "i": "icon_start" });
    btn.push({ "n": "修改密码", "c": "changePsw()", "i": "icon_lock" });
    btn.push({ "n": "调整价格", "c": "adjustPrice()", "i": "icon_modify" });
    btn.push({ "n": "销帐", "c": "collect()", "i": "icon_modify" });
    btn.push({ "n": "出票", "c": "outTicket()", "i": "icon_audit" });
    btn.push({ "n": "未出票", "c": "noOutTicket()", "i": "icon_audit" });
    btn.push({ "n": "折扣", "c": "discount()", "i": "icon-edit" });
    btn.push({ "n": "充值", "c": "reChargeForMember()", "i": "icon_recharge" });
    btn.push({ "n": "导出", "c": "exportExcel()", "i": "icon_export" });
    btn.push({ "n": "结案", "c": "closeAccident()", "i": "icon-no" });
    btn.push({ "n": "打印", "c": "print()", "i": "icon-add" });
    btn.push({ "n": "导入Excel数据", "c": "uploadExcel()", "i": "icon-add" });
    btn.push({ "n": "审核", "c": "Audit()", "i": "icon-edit" });
    var tt = null;
    for (var i = 0; i < btn.length; i++) {
        if (btn[i].n == name) {
            tt = btn[i];
            break;
        }
    }
    return tt;
}