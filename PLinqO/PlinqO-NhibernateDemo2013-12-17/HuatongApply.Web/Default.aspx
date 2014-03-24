<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HuaTongSystem.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" class="panel-fit">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/App_Themes/Global/Styles/Reset.css")%>" />
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/Scripts/megamenu/css/gray/graymegamenucss.css")%>" />
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/Scripts/side-menu/css/gray/side-menu.css")%>" />
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/Scripts/jquery-core-easyui/themes/default/easyui.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/Scripts/jquery-core-easyui/themes/icon.css") %>" />
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/App_Themes/Gray/Styles/Gray.css")%>" />
    <style type="text/css">
        .a_selected
        {
            color: #fff;
            text-decoration: none;
            display: block;
            width: 174px;
            float: left;
            font-size: 12px;
            padding-left: 25px;
            background-color: red;
            font-family: 微软雅黑;
            font-size: 13px;
        }
    </style>
</head>
<body>
    <noscript>
        <div class="easy_script">
            <img src="<%=Page.ResolveUrl("~/App_Themes/Global/Images/noscript.gif") %>" alt='抱歉，请开启脚本支持！' />
        </div>
    </noscript>
    <div class="head_container clearfix">
        <div class="menu_green_head clearfix">
            <div class="menu_green_head_font">
                中国华通业务管理系统
            </div>
            <div id="megamenu_titlelink" class="menu_green_titlelink">
                <ul class="menu_green_titlelink_ul ">
                    <li><a href="#" class="menu_green_titlelink_ullinks">快捷菜单</a> </li>
                    <li><a href="#" class="menu_green_titlelink_ullinks">系统通知</a> </li>
                    <li><a href="#" class="menu_green_titlelink_ullinks">应用中心</a> </li>
                    <li><a href="#" class="menu_green_titlelink_ullinks">控制面板</a> </li>
                    <li><a href="#" class="menu_green_titlelink_ullinks">回收站</a> </li>
                    <li><a href="#" class="menu_green_titlelink_ullinks">桌面</a> </li>
                    <li style="background: none;"><a href="#" class="menu_green_titlelink_ullinks_select">
                        admin</a> <a href="#" class="menu_green_titlelink_ullinks">[设置]</a> <a href="#" class="menu_green_titlelink_ullinks">
                            [退出]</a> </li>
                </ul>
            </div>
        </div>
        <div id="megamenu_container" class="menu_green" style="display: block;">
            <ul id="menu" class="megamenu">
                <li>
                    <div class="clearfix">
                        <a href="#" id="ticket" style="border-left: 1px solid #3fb4ef;" class="drop" ref="Views/Menu/TicketManage.htm" onclick="menuClick(ticket_line,'#ticket')">
                            <span>中港车票</span></a></div>
                    <div class="drop3columns dropcontent">
                        <div class="col_3">
                            <h5>
                                线路管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="ticket_line" href="#" ref="Views/Ticket/TicketRoute/TicketRouteList.htm"
                                    onclick="menuClick(this,'#ticket')">线路列表</a></li>
                                <li><a id="ticket_on" href="#" ref="Views/Ticket/TicketOnPoint/TicketOnPointList.htm"
                                    onclick="menuClick(this,'#ticket')">上车点列表</a></li>
                                <li><a id="ticket_on_area" href="#" ref="Views/Ticket/OnPointArea/OnPointAreaList.htm"
                                    onclick="menuClick(this,'#ticket')">上车区域列表</a></li>
                                <li><a id="ticket_off" href="#" ref="Views/Ticket/TicketOffPoint/TicketOffPointList.htm"
                                    onclick="menuClick(this,'#ticket')">下车点列表</a></li>
                                <li><a id="ticket_off_area" href="#" ref="Views/Ticket/OffPointArea/OffPointAreaList.htm"
                                    onclick="menuClick(this,'#ticket')">下车区域列表</a></li>
                                <li><a id="ticket_price" href="#" ref="Views/Ticket/HolidayPrice/HolidayPriceList.htm"
                                    onclick="menuClick(this,'#ticket')">线路假日价格</a></li>
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                班次管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="ticket_shift" href="#" ref="Views/Ticket/BanCi/BanCiList.htm" onclick="menuClick(this,'#ticket')">
                                    班次列表</a></li>
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                快捷设置</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="ticket_quick" href="#" ref="Views/Ticket/OneStepBuyTicket/OneStepBuyTicketList.htm"
                                    onclick="menuClick(this,'#ticket')">一步购票</a></li>
                                <li><a id="ticket_checkline" href="#" ref="Views/Ticket/CheckLine/CheckLineList.htm"
                                    onclick="menuClick(this,'#ticket')">验票线路</a></li>
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                提成管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="ticket_station_royalty" href="#" ref="Views/Ticket/StationRoyalty/StationRoyaltyList.htm"
                                    onclick="menuClick(this,'#ticket')">站点提成</a></li>
                                <li><a id="ticket_agentTicketLine" href="#" ref="Views/Ticket/AgentTicketLine/AgentTicketLineList.htm"
                                    onclick="menuClick(this,'#ticket')">代理线路管理</a></li>
                            </ul>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="clearfix">
                        <a href="#" id="car" class="drop" ref="Views/Menu/CarManage.htm" onclick="menuClick(car_line,'#car')">
                            <span>中港包车</span></a></div>
                    <div class="drop3columns dropcontent">
                        <div class="col_3">
                            <h5>
                                线路管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="car_line" href="#" ref="Views/Carrental/CarrentalRoute/CarrentalRouteList.htm"
                                    onclick="menuClick(this,'#car')">线路列表</a></li>
                                <li style="width: 94px;"><a id="car_area" href="#" ref="Views/Order/OrderList.htm"
                                    onclick="menuClick(this,'#car')">区域列表</a></li>
                                <li style="width: 82px;"><a id="car_on" href="#" onclick="menuClick(this,'#car')">上车点列表</a></li>
                                <li><a id="car_off" href="#" onclick="menuClick(this,'#car')">下车点列表</a></li>
                                <li style="width: 94px;"><a id="car_off_area" href="#" ref="Views/Ticket/OffPointArea/OffPointAreaList.htm"
                                    onclick="menuClick(this,'#car')">下车点区域列表</a></li>
                                <li style="width: 82px;"><a id="car_price" href="#" onclick="menuClick(this,'#car')">
                                    线路假日价格</a></li>
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                快捷设置</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="car_quick" href="#" onclick="menuClick(this,'#car')">一键包车</a></li>
                            </ul>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="clearfix">
                        <a href="#" id="free" class="drop" ref="Views/Menu/FreeManage.htm" onclick="menuClick(free_combo,'#free')">
                            <span>自由行套餐</span></a></div>
                    <div class="drop3columns dropcontent">
                        <div class="col_3">
                            <h5>
                                套餐管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="free_combo" href="#" ref="Views/Product/ProductList.htm" onclick="menuClick(this,'#free')">
                                    套餐列表</a></li>
                            </ul>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="clearfix">
                        <a href="#" id="order" class="drop" ref="Views/Menu/OrderManage.htm" onclick="menuClick(order_ticket,'#order')">
                            <span>订单管理</span></a></div>
                    <div class="drop3columns dropcontent">
                        <div class="col_3">
                            <h5>
                                产品订单</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="order_ticket" href="#" ref="Views/Order/TicketOrder/TicketOrderList.htm" onclick="menuClick(this,'#order')">
                                    车票订单列表</a></li>
                                <li><a id="order_car" href="#" ref="Views/Order/OrderList.htm" onclick="menuClick(this,'#order')">
                                    包车订单列表</a></li>
                                <li><a id="order_free" href="#" onclick="menuClick(this,'#order')">自由行订单列表</a></li>
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                挂账订单</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="order_credit" href="#" ref="Views/Product/ProductList.htm" onclick="menuClick(this,'#order')">
                                    挂账单列表</a></li>
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                行李票订单</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="order_package" href="#" ref="Views/Order/BagTicketList.htm" onclick="menuClick(this,'#order')">
                                    行李票订单列表</a></li>
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                订单出票</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="order_oticket" href="#" ref="Views/Product/ProductList.htm" onclick="menuClick(this,'#order')">
                                    出票列表</a></li>
                            </ul>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="clearfix">
                        <a href="#" id="statistics" class="drop" ref="Views/Menu/ApplyManage.htm" onclick="menuClick(stati_ticket_fc,'#statistics')">
                            <span>统计报表</span></a></div>
                    <div class="drop3columns dropcontent">
                        <div class="col_3">
                            <h5>
                                发车单管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="stati_ticket_fc" href="#" ref="Views/Report/DepartureSingle/DepartureSingleList.htm" onclick="menuClick(this,'#statistics')">
                                    车票发车单列表</a></li>
                                <li><a id="stati_car_fc" href="#" ref="Views/Product/ProductList.htm" onclick="menuClick(this,'#statistics')">
                                    包车发车单列表</a></li>
                                <li><a id="stati_fc_list" href="#" ref="Views/Product/ProductList.htm" onclick="menuClick(this,'#statistics')">
                                    发车单汇总列表</a></li>
                            </ul>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="clearfix">
                        <a href="#" id="applys" class="drop" ref="Views/Menu/ApplyManage.htm" onclick="menuClick(applyrecords,'#applys')">
                         <span>成本管理</span></a>
                        </div>
                        <div class="drop3columns dropcontent">
                        <div class="col_3">
                            <h5>
                                报销管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="A2" href="#" ref="Views/Cost/Reimbursement/Items/ApplyItemsList.htm" onclick="menuClick(this,'#applys')">
                                    报销项目列表</a></li>
                                <li><a id="A3" href="#" ref="Views/Cost/Reimbursement/Records/ApplyRecordList.htm" onclick="menuClick(this,'#applys')">
                                    报销记录列表</a></li>
                                <li><a id="A4" href="#" ref="Views/Cost/Reimbursement/Audit/ApplyAuitList.htm" onclick="menuClick(this,'#applys')">
                                    报销审核列表</a></li>
                            </ul>
                        </div>
                    </div>
                </li>
                <li>
                    <div class="clearfix">
                        <a href="#"><span>进销存</span></a></div>
                </li>
                <li>
                    <div class="clearfix">
                        <a href="#"><span>网站配置</span></a></div>
                </li>
                <li>
                    <div class="clearfix">
                        <a href="#" id="system" class="drop" ref="Views/Menu/AdminManage.htm" onclick="menuClick(system_user,'#system')">
                            <span>系统配置</span></a></div>
                    <div class="drop3columns dropcontent">
                        <div class="col_3">
                            <h5>
                                系统管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="system_user" href="#" ref="Views/Product/ProductList.htm" onclick="menuClick(this,'#system')">
                                    用户管理</a></li>
                                <li><a id="system_role" href="#" ref="Views/Admin/Role/RoleList.htm" onclick="menuClick(this,'#system')">
                                    角色管理</a></li>
                                <li><a id="system_right" href="#" ref="Views/Admin/Right/RightList.htm" onclick="menuClick(this,'#system')">
                                    权限管理</a></li>
                                <li><a id="system_organization" href="#" ref="Views/Admin/Organization/OrganizationList.htm"
                                    onclick="menuClick(this,'#system')">部门管理</a></li>
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                站点管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="system_station" href="#" ref="Views/Admin/Station/StationList.htm" onclick="menuClick(this,'#system')">
                                    站点管理</a></li>
                                 <li><a id="A1" href="#" ref="Views/Admin/Machine/MachineList.htm" onclick="menuClick(this,'#system')">
                                    触摸机管理</a></li>
                                    
                            </ul>
                        </div>
                        <div class="col_3">
                            <h5>
                                会员管理</h5>
                        </div>
                        <div class="col_3">
                            <ul>
                                <li><a id="system_vip" href="#" ref="Views/Admin/Member/MemberList.htm" onclick="menuClick(this,'#system')">
                                    会员管理</a></li>
                            </ul>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <div id="layout" class="easyui-layout" style="width: 100%">
        <!--页头-->
        <!--导航菜单-->
        <div id="west" data-options="region:'west',split:true,title:''" class="side" style="width: 200px;">
        </div>
        <!--主内容-->
        <div id="center" data-options="region:'center',title:''">
        </div>
        <!--高级搜索-->
        <div data-options="region:'east',split:false,collapsed:true,title:'高级搜索'" style="width: 150px;
            padding: 10px;">
            east region</div>
    </div>
<%--    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery.min.js") %>"></script>--%>
<%--    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-core-easyui/jquery.easyui.min.js") %>"></script>--%>
<%--    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-template/handlebars.js") %>"></script>--%>
<%--    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-core-easyui/easyloader.js") %>"></script>--%>
<%--    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-common-easyui/easyui.config.js") %>"></script>--%>
<%--    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/megamenu/menu.js") %>"></script>--%>
    
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery.min.js") %>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-core-easyui/jquery.easyui.min.js") %>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-template/handlebars.js") %>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-core-easyui/easyloader.js") %>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-common-easyui/easyui.config.js") %>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/jquery-common-easyui/easyui.public.js") %>"></script>
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/Scripts/megamenu/menu.js") %>"></script>
</body>
</html>
