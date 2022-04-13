<%@ Page Title=" linkedin |Users" Language="C#" MasterPageFile="~/Main.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="PDFS_For_letsgettoit2019.RegisterUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">

         .WordWrap {
                    width:100%;
                    word-break:break-all;
                }

        .mgrid td, th {
            padding: 5px;
            text-align: center;
            vertical-align:inherit;
            
        }

        

        .pagination-ys {F
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }



            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <div class="row align-items-end">
                    <div class="col-lg-8">
                        <div class="page-header-title">
                            <div class="d-inline">
                                <h4>Register User</h4>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="page-header-breadcrumb">
                            <ul class="breadcrumb-title">
                                <li class="breadcrumb-item">
                                    <a href="index-1.htm"><i class="feather icon-home"></i></a>
                                </li>
                                <li class="breadcrumb-item"><a href="#!">Register User</a>
                                </li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="page-body">
                <div class="card">
                    <div class="card-block">
                        <h3 class="sub-title">Add User</h3>
                        <div class="row">
                            <div class="col-md-10">

                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                       <b> Gender</b>
                                    </div>
                                    <div class="col-md-10">
                                        <div class="form-radio">
                                            <form>
                                                <div class="radio radio-inline">
                                                    <label>
                                                        <asp:RadioButton ID="rdMale" Checked="true" runat="server" GroupName="Gender" />
                                                        
                                                        <i class="helper"></i>Male
                                                                           
                                                    </label>
                                                </div>
                                                <div class="radio radio-inline">
                                                    <label>
                                                        <asp:RadioButton ID="rdFemale" runat="server" GroupName="Gender" />
                                                        <i class="helper"></i>Female
                                                                           
                                                    </label>
                                                </div>
                                                
                                            </form>
                                        </div>
                                    </div>
                                </div>
<br />
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                        <b>First Name</b>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtFirstName" runat="server" Width="30%" Style="float: left" CssClass="form-control"></asp:TextBox>
                                        &nbsp;&nbsp;
                        <span style="color: red">*
                        <asp:RequiredFieldValidator ID="rf1" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name Required!"></asp:RequiredFieldValidator></span>
                                    </div>
                                </div>
                                <br />
                                 <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                        <b>Middle Name</b>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtMiddleName" runat="server" Width="30%" Style="float: left" CssClass="form-control"></asp:TextBox>
                                        &nbsp;&nbsp;
                    <%--    <span style="color: red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMiddleName" ErrorMessage="Middle Name Required!"></asp:RequiredFieldValidator></span>
                    --%>                </div>
                                </div>
                                <br />
                                 <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                        <b>Last Name</b>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtLastName" runat="server" Width="30%" Style="float: left" CssClass="form-control"></asp:TextBox>
                                        &nbsp;&nbsp;
                       <%-- <span style="color: red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name Required!"></asp:RequiredFieldValidator></span>
                       --%>             </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                        <b>Email</b>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="30%" Style="float: left" CssClass="form-control"></asp:TextBox>
                                        &nbsp;&nbsp;
                        <span style="color: red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Required!"></asp:RequiredFieldValidator></span>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                        <b>Phone Number</b>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtPhoneNo" runat="server" Width="30%" Style="float: left" CssClass="form-control"></asp:TextBox>
                                        &nbsp;&nbsp;
                       <%-- <span style="color: red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhoneNo"  ErrorMessage="Phone Number Required!"></asp:RequiredFieldValidator></span>
                      --%>              </div>
                                </div>
                                <br />
                                <%--<div class="row">
                                    <div class="col-md-2">
                                      <b>  Birth Date</b>
                                    </div>
                                     <div class="col-md-10">
                                       <asp:TextBox ID="txtBirthDate" Width="30%"   Style="float: left" runat="server" TextMode="Date"  CssClass="form-control"></asp:TextBox>
                                             <%--<ajaxToolkit:CalendarExtender ID="txtBirthDate_calenderextension" runat="server" Enabled="True" Format="dd/MM/yyyy"  TargetControlID="txtBirthDate"></ajaxToolkit:CalendarExtender>
                                          <ajaxToolkit:MaskedEditExtender ID="txtBirthDate_maskededitextender" runat="server" CultureDateFormat="dd/MM/yyyy" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtBirthDate"></ajaxToolkit:MaskedEditExtender>
                                           &nbsp;&nbsp;
                         <span style="color: red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBirthDate"  ErrorMessage="Birth Date Required!"></asp:RequiredFieldValidator></span>
                                                             
                                                        </div>
                                </div>--%>
                                <br />
                                 <div class="row">
                                    <div class="col-md-2">
                                      <b>Password</b>
                                    </div>
                                     <div class="col-md-10">
                                       <asp:TextBox ID="txtMartialStatus" Width="30%"  Style="float: left" runat="server"  CssClass="form-control"></asp:TextBox>
                                           &nbsp;&nbsp;
                        <span style="color: red">*
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMartialStatus"  ErrorMessage="Martial Status Required!"></asp:RequiredFieldValidator></span>
                                                             
                                                            </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                      <b>City/Country</b>
                                    </div>
                                     <div class="col-md-10">
                                       <asp:TextBox ID="txtLocation" placeholder="e.g: Toronto, Canada" Width="30%"  Style="float: left" runat="server"  CssClass="form-control"></asp:TextBox>
                                                
                                                            </div>
                                </div>
                                <br />

                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                        <b>User Type</b>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:ObjectDataSource ID="odsCustomertypes" runat="server" TypeName="BLL.clsUser" SelectMethod="GetUserTypes"></asp:ObjectDataSource>
                                        <asp:DropDownList ID="ddlCustomerType" CssClass="form-control" runat="server" Style="width: auto; float: left" AppendDataBoundItems="true" DataTextField="UserTypeName" DataValueField="UserTypeId" DataSourceID="odsCustomertypes">
                                            <asp:ListItem Selected="True" Text="[Select]" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                        <span style="color: red">*
                        <asp:CompareValidator ID="comparevalidator" runat="server" ValueToCompare="0" Operator="NotEqual" ControlToValidate="ddlCustomerType" ErrorMessage="Type Required!"></asp:CompareValidator></span>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                        <b>Photo</b>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="form-control" Style="width: 30%; float: left" />
                                        &nbsp;&nbsp;
                      <%--  <span style="color: red">*
                        </span>--%>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                    </div>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-mat btn-primary" OnClick="btnSave_Click" />
                                        &nbsp;&nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="false" CssClass="btn btn-mat btn-inverse" OnClick="btnClear_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                    </div>
                                    <div class="col-md-10">
                                        Feedback:<asp:Label ID="lblFeedback" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                    </div>
                                    <div class="col-md-10">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" style="position: absolute;">
                                            <ProgressTemplate>
                                                <asp:Image ID="updateProgress" runat="server"
                                                    ImageUrl="Images/coda-ajax-loader.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                </div>
                                  <div class="col-md-2">
                                <asp:Image ID="imgPhoto" runat="server" Height="180px"
                                    ImageUrl="~/Images/NoImageFound.jpg" Width="150px" BorderStyle="Solid"
                                    BorderWidth="2px" />
                            </div>
                        </div>


                                <br />


                                <div class="row">
                                    
                                    <div class="col-md-12">
                                        <center>
                                        <asp:GridView ID="gvUser" runat="server" AllowPaging="true" PageSize="5" OnSelectedIndexChanged="gvUser_SelectedIndexChanged" AutoGenerateColumns="false" DataKeyNames="UserId" CssClass="table table-styling mgrid WordWrap">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnDelete" CausesValidation="false" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-danger btn-outline-danger" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="10%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Photo">
                                                    <ItemTemplate>
                                                        <img src="LoadCustomerImage.aspx?id=<%# Eval("UserId").ToString() %>" height="60px" width="60px" />
                                                    </ItemTemplate>



                                                    <ItemStyle Width="10%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Full_Name" HeaderText="Name" NullDisplayText="--" />
                                                <asp:BoundField DataField="Email" HeaderText="Email" NullDisplayText="--" />
                                                <asp:BoundField DataField="PhoneNo" HeaderText="Phone No." NullDisplayText="--" />
                                                <asp:BoundField DataField="Gender" HeaderText="Gender" NullDisplayText="--" />
                                               

                                                <asp:BoundField DataField="UserTypeName" HeaderText="Type" NullDisplayText="--" />
                                                <asp:TemplateField >
                                                    <ItemTemplate>
                                                        <div class="checkbox-fade fade-in-primary d-">
                                                            <label style="width:10px">
                                                                <asp:CheckBox ID="chkIsActive" CausesValidation="false"  runat="server" Checked='<%#Eval("IsActive") %>' OnCheckedChanged="chkIsActive_CheckedChanged" />
                                                                <span class="cr">
                                                                    <i class="cr-icon icofont icofont-ui-check txt-primary"></i>
                                                                </span>

                                                            </label>
                                                        </div>



                                                    </ItemTemplate>

                                                    <HeaderTemplate>Active</HeaderTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ControlStyle-CssClass="btn btn-success btn-outline-success" ShowSelectButton="True">
                                                    <HeaderStyle Width="10%" />

                                                </asp:CommandField>
                                            </Columns>
                                            <HeaderStyle CssClass="table-primary" />
                                            <PagerStyle CssClass="pagination-ys" />
                                            <PagerSettings Mode="NextPrevious" NextPageText="Next" PreviousPageText="Prev" PageButtonCount="6" Position="Bottom" />
                                            <SelectedRowStyle BackColor="SeaShell" />
                                        </asp:GridView>
                                            </center>
                                    </div>
                                </div>



                            
                          











                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
