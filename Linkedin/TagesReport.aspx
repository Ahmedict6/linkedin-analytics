<%@ Page Title="linkedin |Tag Report" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TagReport.aspx.cs" Inherits="CustomerPortal.TagReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <div class="row align-items-end">
                    <div class="col-lg-8">
                        <div class="page-header-title">
                            <div class="d-inline">
                                <h4>Tag Report</h4>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="page-header-breadcrumb">
                            <ul class="breadcrumb-title">
                                <li class="breadcrumb-item">
                                    <a href="index-1.htm"><i class="feather icon-home"></i></a>
                                </li>
                                <li class="breadcrumb-item"><a href="ShowData.aspx">Tag Report</a>
                                </li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="page-body">
                <div class="row">


                    <div class="col-md-12" runat="server" id="DivNoData">
                        <div class="card table-card">
                            <div class="card-header">
                                <h3 class="sub-title text-c-lite-green">No Data Found</h3>
                            </div>

                            <div class="card-body text-center">
                                <h1 class="text-info">There is no data to show !</h1>
                            </div>
                        </div>
                    </div>

                </div>
                <asp:DataList ID="dlPdfs" DataKeyField="TagId" Width="100%" runat="server" RepeatLayout="Flow" OnPreRender="dlPdfs_PreRender">

                    <ItemTemplate>
                        <div class="row">

                            <div class="col-md-12">
                                <div class="card table-card">
                                    <div class="card-header">
                                        <h3 class="sub-title text-c-lite-green">Tag : <b><%# Eval("TagName") %> </h3>
                                        <div class="card-header-right " style="margin-top: -18px;">
                                        </div>
                                    </div>
                                    <div class="card-block">
                                        <div class="table-responsive">


                                            <asp:Chart ID="Chart1" runat="server" CssClass="block" Width="1000px">

                                                <Series>
                                                </Series>

                                                <ChartAreas>

                                                    <asp:ChartArea Name="ChartArea1">
                                                    </asp:ChartArea>

                                                </ChartAreas>

                                            </asp:Chart>
                                            </center>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>



            </div>

            <%-- /* <div class="page-body">
                <div class="row">

                    
                            <div class="col-md-12" runat="server" id="DivNoData">
                                <div class="card table-card">
                                    <div class="card-header">
                                        <h3 class="sub-title text-c-lite-green">No Data Found</h3>
                                           </div>
                                     
                                    <div class="card-body text-center">
                                        <h1 class="text-info">There is no data to show !</h1>
                                        </div>
                                </div>  
                                </div>
                    <asp:DataList ID="dlPdfs" DataKeyField="PdfFileId" Width="100%" runat="server" RepeatLayout="Flow" OnPreRender="dlPdfs_PreRender">

                        <ItemTemplate>
                            <div class="col-md-12">
                                <div class="card table-card">
                                    <div class="card-header">
                                        <h3 class="sub-title text-c-lite-green">File : <b><%# Eval("FileName") %> </b>| Uplode Time : <b><%# Eval("UplodeTime") %>        </b></h3>
                                        <div class="card-header-right " style="margin-top: -18px;">

                                            <asp:Button runat="server" ID="btnDelete" CssClass="btn  btn-danger btn-sm btn-round" Text="Delete" OnClientClick="return confirm('Are You sure You want to Delete This File ?')" OnClick="btnDelete_Click" />
                                        </div>
                                    </div>
                                    <div class="card-block">
                                        <div class="table-responsive">

                                            <center>
                                                <asp:GridView  ID="gvrData" CssClass="table  table-bordered table-hover" Width="95%" AutoGenerateColumns="false" runat="server">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="HCPCS Code" DataField="HCPCS_Code" NullDisplayText="--" />
                                                        <asp:BoundField HeaderText="DOS START" DataField="DOS_START" NullDisplayText="--" />
                                                        <asp:BoundField HeaderText="Supplier Name" DataField="Supplier_Name" NullDisplayText="--" />
                                                        <asp:BoundField HeaderText="Supplier Phone" DataField="Supplier_Phone_number" NullDisplayText="--" />

                                                
                                                        <asp:CheckBoxField HeaderText="Allowed" DataField="Allowed" />
                                                    </Columns>
                                                    <HeaderStyle CssClass="text-amazon text-c-blue  border" />
                                                </asp:GridView>
                                                </center>

                                            <hr />
                                            <center>
                                            <asp:Chart ID="Chart1" runat="server" CssClass="block"  Width="1000px">

                                                <Series>
                                                </Series>

                                                <ChartAreas>

                                                    <asp:ChartArea Name="ChartArea1">
                                                    </asp:ChartArea>

                                                </ChartAreas>

                                            </asp:Chart>
                                                </center>

                                        </div>
                                    </div>
                                </div>
                        </ItemTemplate>
                    </asp:DataList>



                </div>
             
            </div>           */ --%> 
            </div>
                 </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
