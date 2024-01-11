' ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в контекстном меню, чтобы изменить имя класса "ESKServices" в коде, системе контроля версий и файле конфигурации.
' ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ESKServices.svc или ESKServices.svc.vb в обозревателе решений и начните отладку.
Public Class ESKServices
    Implements IESKServices
    Dim connString As String = "Data Source=.;server=sqlcls;Initial Catalog=ScaDataDB;User ID=sa;Password=sqladmin"
    Dim testConnString As String = "Data Source=.;server=spbdvl2;Initial Catalog=ScaDataDB;User ID=sa;Password=sqladmin"

    Private Function IsAuthorised(MyLogin As String, MyService As String) As Boolean
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Проверка - есть ли у данного пользователя право на использование сервиса
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MySQLStr As String
        Dim ds As New DataSet()
        Dim MyAuth As Boolean = False

        Try
            MySQLStr = "dbo.spp_Services_GetAuthInfo"
            Using MyConn As SqlConnection = New SqlConnection(connString)
                Try
                    Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.CommandTimeout = 1800
                        cmd.Parameters.AddWithValue("@MyLogin", MyLogin)
                        cmd.Parameters.AddWithValue("@MyService", MyService)
                        Using da As New SqlDataAdapter()
                            da.SelectCommand = cmd
                            da.Fill(ds)
                            If ds.Tables(0).Rows.Count <> 0 Then
                                MyAuth = True
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    EventLog.WriteEntry("ESKServices", "IsAuthorised --1--> " & ex.Message)
                Finally
                    MyConn.Close()
                End Try
            End Using
        Catch ex As Exception
            EventLog.WriteEntry("ESKServices", "IsAuthorised --2--> " & ex.Message)
        End Try
        Return MyAuth
    End Function

    Public Function GetItemsJson(id As String) As List(Of IESKServices.GetItemsParametersRet) Implements IESKServices.GetItemsJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение информации о товарах в формате Json
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetItemsParametersRet
        Dim MyList As List(Of IESKServices.GetItemsParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetItemsJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetItems"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyClientCode", MyLogin)
                            cmd.Parameters.AddWithValue("@MyItemCode", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetItemsParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetItemsParametersRet
                                MyStr.ItemCode = rdr.GetValue(0)
                                MyStr.ItemName = rdr.GetValue(1)
                                MyStr.ManufacturerCode = rdr.GetValue(2)
                                MyStr.ManufacturerName = rdr.GetValue(3)
                                MyStr.ManufacturerItemCode = rdr.GetValue(4)
                                MyStr.DiscountType = rdr.GetValue(5)
                                MyStr.Discount = rdr.GetValue(6)
                                MyStr.Price = rdr.GetValue(7)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetItemsJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetItemsJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetItemsXml(id As String) As List(Of IESKServices.GetItemsParametersRet) Implements IESKServices.GetItemsXml
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение информации о товарах в формате Xml
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetItemsParametersRet
        Dim MyList As List(Of IESKServices.GetItemsParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetItemsJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetItems"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyClientCode", MyLogin)
                            cmd.Parameters.AddWithValue("@MyItemCode", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetItemsParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetItemsParametersRet
                                MyStr.ItemCode = rdr.GetValue(0)
                                MyStr.ItemName = rdr.GetValue(1)
                                MyStr.ManufacturerCode = rdr.GetValue(2)
                                MyStr.ManufacturerName = rdr.GetValue(3)
                                MyStr.ManufacturerItemCode = rdr.GetValue(4)
                                MyStr.DiscountType = rdr.GetValue(5)
                                MyStr.Discount = rdr.GetValue(6)
                                MyStr.Price = rdr.GetValue(7)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetItemsXml --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetItemsXml --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetOrders0TypeCommonJson(id As String) As List(Of IESKServices.GetOrders0TypeCommonParametersRet) Implements IESKServices.GetOrders0TypeCommonJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение общей информации о заказе 0 типа
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetOrders0TypeCommonParametersRet
        Dim MyList As List(Of IESKServices.GetOrders0TypeCommonParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetOrders0TypeCommonJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetOrders0TypeCommon"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetOrders0TypeCommonParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetOrders0TypeCommonParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)
                                MyStr.OrderNum = rdr.GetValue(2)
                                MyStr.OrderDate = rdr.GetValue(3)
                                MyStr.CustomerCode = rdr.GetValue(4)
                                MyStr.CustomerName = rdr.GetValue(5)
                                MyStr.SalesmanCode = rdr.GetValue(6)
                                MyStr.SalesmanName = rdr.GetValue(7)
                                MyStr.IsCredit = rdr.GetValue(8)
                                MyStr.CreditSumm = rdr.GetValue(9)
                                MyStr.CreditDays = rdr.GetValue(10)
                                MyStr.StartAgreementDate = rdr.GetValue(11)
                                MyStr.FinAgreementDate = rdr.GetValue(12)
                                MyStr.OrderSumm = rdr.GetValue(13)
                                MyStr.OrderSummNoVAT = rdr.GetValue(14)
                                MyStr.OrderMarginPerCent = rdr.GetValue(15)
                                MyStr.DeliveryCost = rdr.GetValue(16)
                                MyStr.Margin1Level = rdr.GetValue(17)
                                MyStr.Margin2Level = rdr.GetValue(18)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetOrders0TypeCommonJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetOrders0TypeCommonJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetOrdersAdvancesJson(id As String) As List(Of IESKServices.GetOrdersAdvancesParametersRet) Implements IESKServices.GetOrdersAdvancesJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение списка авансов по заказу
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetOrdersAdvancesParametersRet
        Dim MyList As List(Of IESKServices.GetOrdersAdvancesParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetOrdersAdvancesJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetOrdersAdvances"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetOrdersAdvancesParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetOrdersAdvancesParametersRet
                                MyStr.AdvanceDate = rdr.GetValue(0)
                                MyStr.AdvanceSumm = rdr.GetValue(1)
                                MyStr.AdvanceCurr = rdr.GetValue(2)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetOrdersAdvancesJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetOrdersAdvancesJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetCreditInfoJson(id As String) As List(Of IESKServices.GetCreditInfoParametersRet) Implements IESKServices.GetCreditInfoJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение суммы отгруженного и неоплаченного
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetCreditInfoParametersRet
        Dim MyList As List(Of IESKServices.GetCreditInfoParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetCreditInfoJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetCreditInfo"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyCustomerNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetCreditInfoParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetCreditInfoParametersRet
                                MyStr.CreditUsedSumm = rdr.GetValue(0)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetCreditInfoJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetCreditInfoJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetOwedInvoicesJson(id As String) As List(Of IESKServices.GetOwedInvoicesParametersRet) Implements IESKServices.GetOwedInvoicesJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение списка задолженных СФ по клиенту
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetOwedInvoicesParametersRet
        Dim MyList As List(Of IESKServices.GetOwedInvoicesParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetOwedInvoicesJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetOwedInvoices"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyCustomerNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetOwedInvoicesParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetOwedInvoicesParametersRet
                                MyStr.InvoiceNum = rdr.GetValue(0)
                                MyStr.InvoiceDate = rdr.GetValue(1)
                                MyStr.InvoiceDueDate = rdr.GetValue(2)
                                MyStr.InvoiceOwedSumm = rdr.GetValue(3)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetOwedInvoicesJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetOwedInvoicesJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetOrderNShDetailJson(id As String) As List(Of IESKServices.GetOrderHShDetailParametersRet) Implements IESKServices.GetOrderNShDetailJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение списка задолженных СФ по клиенту
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetOrderHShDetailParametersRet
        Dim MyList As List(Of IESKServices.GetOrderHShDetailParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetOrderNShDetailJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetOrderNShDetail"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetOrderHShDetailParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetOrderHShDetailParametersRet
                                MyStr.StringNum = rdr.GetValue(0)
                                MyStr.ItemCode = rdr.GetValue(1)
                                MyStr.ItemName = rdr.GetValue(2)
                                MyStr.ItemQTY = rdr.GetValue(3)
                                MyStr.ItemPrice = rdr.GetValue(4)
                                MyStr.ItemCalcPriCost = rdr.GetValue(5)
                                MyStr.ItemPriCost = rdr.GetValue(6)
                                MyStr.ItemCalcMargin = rdr.GetValue(7)
                                MyStr.ItemMargin = rdr.GetValue(8)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetOrderNShDetailJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetOrderNShDetailJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetScaUserRightsJson(id As String) As List(Of IESKServices.GetScaUserRightsParametersRet) Implements IESKServices.GetScaUserRightsJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение информации о правах пользователя
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetScaUserRightsParametersRet
        Dim MyList As List(Of IESKServices.GetScaUserRightsParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetScaUserRightsJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetScaUserRights"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyUserLogin", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetScaUserRightsParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetScaUserRightsParametersRet
                                MyStr.MarginLevel = rdr.GetValue(0)
                                MyStr.TransferOverLimit = rdr.GetValue(1)
                                MyStr.ShipmentsOverLimit = rdr.GetValue(2)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetScaUserRightsJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetScaUserRightsJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetTransferTo1TypeRezJson(id As String, Userid As String,
        Comment As String) As List(Of IESKServices.GetTransferTo1TypeRezParametersRet) Implements IESKServices.GetTransferTo1TypeRezJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// выдача разрешения на перевод заказа в 1 тип
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetTransferTo1TypeRezParametersRet
        Dim MyList As List(Of IESKServices.GetTransferTo1TypeRezParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetTransferTo1TypeRezJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetTransferTo1TypeRez"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)
                            cmd.Parameters.AddWithValue("@MyUser", Userid)
                            cmd.Parameters.AddWithValue("@MyComment", Comment)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetTransferTo1TypeRezParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetTransferTo1TypeRezParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetTransferTo1TypeRezJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetTransferTo1TypeRezJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetOrdersn0TypeCommonJson(id As String) As List(Of IESKServices.GetOrdersn0TypeCommonParametersRet) Implements IESKServices.GetOrdersn0TypeCommonJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение общей информации о заказе не 0 типа
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetOrdersn0TypeCommonParametersRet
        Dim MyList As List(Of IESKServices.GetOrdersn0TypeCommonParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetOrdersn0TypeCommonJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetOrdersn0TypeCommon"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetOrdersn0TypeCommonParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetOrdersn0TypeCommonParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)
                                MyStr.OrderNum = rdr.GetValue(2)
                                MyStr.OrderDate = rdr.GetValue(3)
                                MyStr.CustomerCode = rdr.GetValue(4)
                                MyStr.CustomerName = rdr.GetValue(5)
                                MyStr.SalesmanCode = rdr.GetValue(6)
                                MyStr.SalesmanName = rdr.GetValue(7)
                                MyStr.IsCredit = rdr.GetValue(8)
                                MyStr.CreditSumm = rdr.GetValue(9)
                                MyStr.CreditDays = rdr.GetValue(10)
                                MyStr.StartAgreementDate = rdr.GetValue(11)
                                MyStr.FinAgreementDate = rdr.GetValue(12)
                                MyStr.OrderSumm = rdr.GetValue(13)
                                MyStr.OrderSummNoVAT = rdr.GetValue(14)
                                MyStr.OrderMarginPerCent = rdr.GetValue(15)
                                MyStr.OrderfMarginPerCent = rdr.GetValue(16)
                                MyStr.DeliveryCost = rdr.GetValue(17)
                                MyStr.Margin1Level = rdr.GetValue(18)
                                MyStr.Margin2Level = rdr.GetValue(19)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetOrdersn0TypeCommonJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetOrdersn0TypeCommonJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetAllowanceShipmentRezJson(id As String, Userid As String,
        Comment As String) As List(Of IESKServices.GetAllowanceShipmentRezParametersRet) Implements IESKServices.GetAllowanceShipmentRezJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// выдача разрешения на отгрузку заказа
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetAllowanceShipmentRezParametersRet
        Dim MyList As List(Of IESKServices.GetAllowanceShipmentRezParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetAllowanceShipmentRezJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetAllowanceShipmentRez"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)
                            cmd.Parameters.AddWithValue("@MyUser", Userid)
                            cmd.Parameters.AddWithValue("@MyComment", Comment)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetAllowanceShipmentRezParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetAllowanceShipmentRezParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetAllowanceShipmentRezJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetAllowanceShipmentRezJson --2--> " & ex.Message)
            End Try
        Else
        End If
    End Function

    Public Function GetOrderListForCollectionJson(id As String) As List(Of IESKServices.GetOrderListForCollectionParametersRet) Implements IESKServices.GetOrderListForCollectionJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение списка заказов на подборку конкретным сотрудником
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetOrderListForCollectionParametersRet
        Dim MyList As List(Of IESKServices.GetOrderListForCollectionParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetOrderListForCollectionJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetOrderListForCollection"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyLogin", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetOrderListForCollectionParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetOrderListForCollectionParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)
                                MyStr.RecordID = rdr.GetValue(2)
                                MyStr.OrderNum = rdr.GetValue(3)
                                MyStr.RequestedDate = rdr.GetValue(4)
                                MyStr.Customer = rdr.GetValue(5)
                                MyStr.Delivery = rdr.GetValue(6)
                                MyStr.WHNum = rdr.GetValue(7)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetOrderListForCollectionJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetOrderListForCollectionJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetOrderForAssemblingJson(id As String) As List(Of IESKServices.GetOrderForAssemblingParametersRet) Implements IESKServices.GetOrderForAssemblingJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение списка товаров в заказе для подборки
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetOrderForAssemblingParametersRet
        Dim MyList As List(Of IESKServices.GetOrderForAssemblingParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetOrderForAssemblingJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetOrderForAssembling"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@OrderNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetOrderForAssemblingParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetOrderForAssemblingParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)
                                MyStr.StrNum = rdr.GetValue(2)
                                MyStr.ItemCode = rdr.GetValue(3)
                                MyStr.ItemName = rdr.GetValue(4)
                                MyStr.ItemType = rdr.GetValue(5)
                                MyStr.IsCabel = rdr.GetValue(6)
                                MyStr.RequestedCabelParts = rdr.GetValue(7)
                                MyStr.RequestedQTY = rdr.GetValue(8)
                                MyStr.AssembledQTY = rdr.GetValue(9)
                                MyStr.ToAssembleQTY = rdr.GetValue(10)
                                MyStr.MarkToWrite = rdr.GetValue(11)
                                MyStr.ItemCell = rdr.GetValue(12)
                                MyStr.BarCode = rdr.GetValue(13)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetOrderForAssemblingJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetOrderForAssemblingJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetPartionsForAssemblingJson(id As String, whid As String,
                                                 orderid As String) As List(Of IESKServices.GetPartionsForAssemblingParametersRet) Implements IESKServices.GetPartionsForAssemblingJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение списка партий (кабельная продукция) для подборки
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetPartionsForAssemblingParametersRet
        Dim MyList As List(Of IESKServices.GetPartionsForAssemblingParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetPartionsForAssemblingJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetPartionsForAssembling"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyItem", id)
                            cmd.Parameters.AddWithValue("@MyWHNum", whid)
                            cmd.Parameters.AddWithValue("@MyOrderNum", orderid)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetPartionsForAssemblingParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetPartionsForAssemblingParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)
                                MyStr.PartionID = rdr.GetValue(2)
                                MyStr.AvlQTY = rdr.GetValue(3)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetPartionsForAssemblingJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetPartionsForAssemblingJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetShipmentFromPartionRezJson(ByVal id As String, ByVal WHid As String,
                                       ByVal ItemId As String, ByVal StrId As String,
                                       ByVal PartitionId As String, ByVal QTY As String) As List(Of IESKServices.GetShipmentFromPartionRezParametersRet) Implements IESKServices.GetShipmentFromPartionRezJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Занесение информации по отгрузке из одной партии (кабельная продукция)
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetShipmentFromPartionRezParametersRet
        Dim MyList As List(Of IESKServices.GetShipmentFromPartionRezParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetShipmentFromPartionRezJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetShipmentFromPartionRez"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)
                            cmd.Parameters.AddWithValue("@MyWHNum", whid)
                            cmd.Parameters.AddWithValue("@MyItemCode", ItemId)
                            cmd.Parameters.AddWithValue("@MyStrNum", StrId)
                            cmd.Parameters.AddWithValue("@MyPartitionNum", PartitionId)
                            cmd.Parameters.AddWithValue("@MyQTY", CDbl(Replace(QTY, ".", ",")))

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetShipmentFromPartionRezParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetShipmentFromPartionRezParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetShipmentFromPartionRezJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetShipmentFromPartionRezJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetShipmentFromItemRezJson(ByVal id As String, ByVal WHid As String,
                                       ByVal ItemId As String, ByVal StrId As String,
                                       ByVal QTY As String) As List(Of IESKServices.GetShipmentFromItemRezParametersRet) Implements IESKServices.GetShipmentFromItemRezJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Занесение информации по отгрузке одного продукта (не кабельная продукция)
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetShipmentFromItemRezParametersRet
        Dim MyList As List(Of IESKServices.GetShipmentFromItemRezParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetShipmentFromItemRezJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetShipmentFromItemRez"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)
                            cmd.Parameters.AddWithValue("@MyWHNum", WHid)
                            cmd.Parameters.AddWithValue("@MyItemCode", ItemId)
                            cmd.Parameters.AddWithValue("@MyStrNum", StrId)
                            cmd.Parameters.AddWithValue("@MyQTY", CDbl(Replace(QTY, ".", ",")))

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetShipmentFromItemRezParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetShipmentFromItemRezParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetShipmentFromItemRezJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetShipmentFromItemRezJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetOrderShCloseRezJson(ByVal id As String) As List(Of IESKServices.GetOrderShCloseRezParametersRet) Implements IESKServices.GetOrderShCloseRezJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Закрытие подборки заказа
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetOrderShCloseRezParametersRet
        Dim MyList As List(Of IESKServices.GetOrderShCloseRezParametersRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetOrderShCloseRezJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetOrderShCloseRez"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetOrderShCloseRezParametersRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetOrderShCloseRezParametersRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetOrderShCloseRezJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetOrderShCloseRezJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetAllowedEditOrderListForCollectionJson() As List(Of IESKServices.GetAllowedEditOrderListForCollectionJsonRet) Implements IESKServices.GetAllowedEditOrderListForCollectionJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение списка с выданным разрешением на редактирование
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetAllowedEditOrderListForCollectionJsonRet
        Dim MyList As List(Of IESKServices.GetAllowedEditOrderListForCollectionJsonRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetAllowedEditOrderListForCollectionJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetAllowedEditOrderListForCollectionJson"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetAllowedEditOrderListForCollectionJsonRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetAllowedEditOrderListForCollectionJsonRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)
                                MyStr.OrderN = rdr.GetValue(2)
                                MyStr.Salesman = rdr.GetValue(3)
                                MyStr.AllowanceDate = rdr.GetValue(4)
                                MyStr.AllowanceReason = rdr.GetValue(5)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetAllowedEditOrderListForCollectionJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetAllowedEditOrderListForCollectionJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function


    Public Function GetNonZeroOrderListForCollectionJson() As List(Of IESKServices.GetNonZeroOrderListForCollectionJsonRet) Implements IESKServices.GetNonZeroOrderListForCollectionJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение списка заказов не 0 типа без выданного разрешением на редактирование
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetNonZeroOrderListForCollectionJsonRet
        Dim MyList As List(Of IESKServices.GetNonZeroOrderListForCollectionJsonRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetNonZeroOrderListForCollectionJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetNonZeroOrderListForCollectionJson"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetNonZeroOrderListForCollectionJsonRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetNonZeroOrderListForCollectionJsonRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)
                                MyStr.OrderN = rdr.GetValue(2)
                                MyStr.OrderType = rdr.GetValue(3)
                                MyStr.Customer = rdr.GetValue(4)
                                MyStr.OrderSumm = rdr.GetValue(5)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetNonZeroOrderListForCollectionJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetNonZeroOrderListForCollectionJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetEditAllowanceRezJson(id As String,
        Comment As String) As List(Of IESKServices.GetEditAllowanceRezJsonRet) Implements IESKServices.GetEditAllowanceRezJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// выдача разрешения на редактирование заказа не 0 типа
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetEditAllowanceRezJsonRet
        Dim MyList As List(Of IESKServices.GetEditAllowanceRezJsonRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetEditAllowanceRezJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetEditAllowanceRezJson"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)
                            cmd.Parameters.AddWithValue("@MyComment", Comment)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetEditAllowanceRezJsonRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetEditAllowanceRezJsonRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetEditAllowanceRezJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetEditAllowanceRezJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function

    Public Function GetDeleteAllowanceRezJson(id As String) As List(Of IESKServices.GetDeleteAllowanceRezJsonRet) Implements IESKServices.GetDeleteAllowanceRezJson
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// Удаление разрешения на редактирование заказа не 0 типа
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim MyLogin As String
        Dim MyService As String
        Dim MySQLStr As String
        Dim MyStr As IESKServices.GetDeleteAllowanceRezJsonRet
        Dim MyList As List(Of IESKServices.GetDeleteAllowanceRezJsonRet)
        Dim rdr As SqlDataReader

        MyLogin = System.Web.HttpContext.Current.Session("CustomerLogin")
        MyService = "GetDeleteAllowanceRezJson"

        If IsAuthorised(MyLogin, MyService) Then
            '------------в случае авторизации - получение запрошенных данных
            Try
                MySQLStr = "dbo.spp_Services_GetDeleteAllowanceRezJson"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    '---для отладки
                    'Using MyConn As SqlConnection = New SqlConnection(testConnString)
                    Try
                        MyConn.Open()
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyOrderNum", id)

                            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                            MyList = New List(Of IESKServices.GetDeleteAllowanceRezJsonRet)()

                            While (rdr.Read())
                                MyStr = New IESKServices.GetDeleteAllowanceRezJsonRet
                                MyStr.ErrorNum = rdr.GetValue(0)
                                MyStr.ErrorValue = rdr.GetValue(1)

                                MyList.Add(MyStr)
                            End While

                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "GetDeleteAllowanceRezJson --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
                Return MyList
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "GetDeleteAllowanceRezJson --2--> " & ex.Message)
            End Try
        Else

        End If
    End Function
End Class
