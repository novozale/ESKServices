Public Class RestAuthorizationManager
    Inherits ServiceAuthorizationManager

    Dim connString As String = "Data Source=.;server=sqlcls;Initial Catalog=ScaDataDB;User ID=sa;Password=sqladmin"
    Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean
        '//////////////////////////////////////////////////////////////////////////////////////////
        '//
        '// проверка логина и пароля
        '//
        '//////////////////////////////////////////////////////////////////////////////////////////
        Dim accessAllowed = False
        Dim svcCredentials
        Dim MySQLStr As String
        Dim ds As New DataSet()
        Dim MyLogin As String
        Dim MyPassword As String

        Dim authHeader = WebOperationContext.Current.IncomingRequest.Headers("Authorization")
        If ((authHeader <> Nothing) And (authHeader <> String.Empty)) Then
            '---получение логина и пароля---------------------
            svcCredentials = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(authHeader.Substring(6))).Split(":")
            System.Web.HttpContext.Current.Session("CustomerLogin") = svcCredentials(0)
            MyLogin = svcCredentials(0)
            MyPassword = GetHashStr(svcCredentials(1))

            '---проверка логина и пароля----------------------
            Try
                MySQLStr = "dbo.spp_Services_GetLoginPasswords"
                Using MyConn As SqlConnection = New SqlConnection(connString)
                    Try
                        Using cmd As SqlCommand = New SqlCommand(MySQLStr, MyConn)
                            cmd.CommandType = CommandType.StoredProcedure
                            cmd.CommandTimeout = 1800
                            cmd.Parameters.AddWithValue("@MyLogin", MyLogin)
                            cmd.Parameters.AddWithValue("@MyMD5Password", MyPassword)
                            Using da As New SqlDataAdapter()
                                da.SelectCommand = cmd
                                da.Fill(ds)
                                If ds.Tables(0).Rows.Count <> 0 Then
                                    accessAllowed = True
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        EventLog.WriteEntry("ESKServices", "CheckLoginPassword --1--> " & ex.Message)
                    Finally
                        MyConn.Close()
                    End Try
                End Using
            Catch ex As Exception
                EventLog.WriteEntry("ESKServices", "CheckLoginPassword --2--> " & ex.Message)
            End Try

            Return accessAllowed
        Else
            Return accessAllowed
        End If
    End Function

    Private Function GetHashStr(MyStr As String) As String
        '////////////////////////////////////////////////////////////////////////////////
        '//
        '// Получение строки MD5 для строки - параметра
        '//
        '////////////////////////////////////////////////////////////////////////////////
        Using md5Hash As MD5 = MD5.Create()


            Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(MyStr))
            Dim sBuilder As New StringBuilder()
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i
            GetHashStr = sBuilder.ToString
        End Using
    End Function
End Class
