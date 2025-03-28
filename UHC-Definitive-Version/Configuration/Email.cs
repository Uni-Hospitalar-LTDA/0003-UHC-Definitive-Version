﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using UHC3_Definitive_Version.Customization;

namespace UHC3_Definitive_Version.Configuration
{
    public class Email
    {

        //Lista de atributos do e-mail
        public static List<EmailAttributes> _attributes = new List<EmailAttributes>();
        public static void getMailCredentials()
        {
            //Microsoft 1
            _attributes.Add(new EmailAttributes()
            {
                service = "Gmail"
                ,
                popPort = 995
                ,
                popServer = "pop.gmail.com"
                ,
                smtpPort = 587
                ,
                smtpServer = "smtp.gmail.com"
                ,
                imapPort = 993
                ,
                imapServer = "---"
                ,
                useSsl = true
                ,
                username = "inteligence@unihospitalar.com.br"
                ,
                password = "!@#asd253"
            });
        }

        public static void old_SendEmail(List<string> toAddresses, string ccAddress, string subject, string bodyContent, List<string> attachments)
        {
            var credentials = _attributes[0]; // assuming you want to use the first credentials

            var fromAddress = new MailAddress(credentials.username, "Intelligence Bot: A machine Learning do Grupo UNI");
            var toAddress = new MailAddress(toAddresses[0], null); // assuming you want to send to the first address

            var smtp = new SmtpClient
            {
                Host = credentials.smtpServer,
                Port = credentials.smtpPort,
                EnableSsl = credentials.useSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, credentials.password)
            };

            string logoUrl = "https://i.ibb.co/8DzK5VP/Logo-Uni-PNG.png"; // URL of the logo
                                                                          // Processa o conteúdo do corpo do e-mail
            string processedBodyContent = Regex.Replace(bodyContent, @"(?<word>\b[A-Z0-9]+\b|\b\d{1,2}/\d{1,2}/\d{2,4}\b)", match =>
            {
                // Se a palavra corresponder ao padrão, envolve-a em tags <strong>
                return $"<strong>{match.Groups["word"].Value}</strong>";
            });

            // Substitui quebras de linha por <br/>
            processedBodyContent = processedBodyContent.Replace("\n", "<br/>");

            string body = $@"
<html>
<head>
    <style>
        body {{
            background-color: #ffffff;
            color: #333333;
            font-family: Arial, sans-serif;
        }}
        .container {{
            max-width: 80%;
            margin: auto;
            background-color: #f2f2f2;
            padding: 20px;
            border-top: 15px solid #800020;
            border-bottom: 15px solid #800020;
        }}
        .logo {{
            display: block;
            margin: auto;
            max-width: 400px; /* limit the width of the logo */
            width: 100%;
            height: auto;
            padding: 20px 0;
        }}
        .content {{
            color: #333333;
            text-align: justify;
        }}
        h1 {{
            color: #800020;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <img class='logo' src='{logoUrl}' alt='Logo'>
        <div class='content'>
            <h1>{subject}</h1>
            <p>{processedBodyContent}</p>
        </div>
    </div>
</body>
</html>";




            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                // add additional to addresses
                for (int i = 1; i < toAddresses.Count; i++)
                {
                    message.To.Add(toAddresses[i]);
                }

                // add cc address
                message.CC.Add(ccAddress);

                // add attachments
                foreach (var attachment in attachments)
                {
                    message.Attachments.Add(new Attachment(attachment));
                }

                smtp.Send(message);
            }
        }


        public static async Task<string> SendEmailWithExcelAttachment(List<string> toAddresses, string ccAddress, string subject, string bodyContent, List<string> itens, string bottom_message, string logo,
        List<Archive> additionalAttachments, bool withSheet = false)
        {
            string logoUrl = string.Empty;
            try
            {
                /** Get Logo link **/
                logoUrl = logo;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao obter URL do logo: " + ex.Message);
            }

            string processedBodyContent = string.Empty;
            string processedBottomContent = string.Empty;

            try
            {
                // Processa o conteúdo do corpo do e-mail
                processedBodyContent = Regex.Replace(bodyContent, @"(?<word>\b[A-Z0-9]+\b|\b\d{1,2}/\d{1,2}/\d{2,4}\b)", match =>
                {
                    return $"<strong>{match.Groups["word"].Value}</strong>";
                });

                processedBottomContent = Regex.Replace(bottom_message, @"(?<word>\b[A-Z0-9]+\b|\b\d{1,2}/\d{1,2}/\d{2,4}\b)", match =>
                {
                    return $"<strong>{match.Groups["word"].Value}</strong>";
                });

                // Substitui quebras de linha por <br/>
                processedBodyContent = processedBodyContent.Replace("\n", "<br/>");
                processedBottomContent = processedBottomContent.Replace("\n", "<br/>");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao processar o conteúdo do corpo do e-mail: " + ex.Message);
            }

            string body = string.Empty;
            try
            {
                body = $@"
                    <html>
                    <body style='font-family: Arial, sans-serif; background-color: #f5f5f5;'>
                        <div style='max-width: 80%; margin: auto; padding: 20px; border-top: 15px solid #661922; border-bottom: 15px solid #661922; background: linear-gradient(to bottom, #e5e5e5, #f5f5f5); box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);'>
                            <img src='{logoUrl}' alt='Logo' style='display: block; margin: 0 auto; max-width: 200px; width: 100%; height: auto; padding: 20px 0;'>
                            <div style='color: #333333; text-align: justify;'>
                                <h1 style='color: #bb001d; font-size: 24px; margin-bottom: 20px;'>{subject}</h1>
                                <p style='font-size: 14px; color: black; margin-bottom: 20px;'>{processedBodyContent}</p>
                                {GenerateHtmlWithDataTableAndList(itens)}
                                <p style='font-size: 14px; color: black; margin-bottom: 20px;'>{"A tecnologia é uma ferramenta que pode ser usada para o bem ou para o mal. Cabe a nós usá-la com sabedoria."}</p>
                                <div style='text-align: center;'>
                                    <p><strong>{processedBottomContent}</strong></p>
                                </div>
                            </div>
                        </div>
                    </body>
                    </html>";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar o corpo do e-mail: " + ex.Message);
            }

            foreach (var credentials in _attributes)
            {
                try
                {
                    var fromAddress = new MailAddress(credentials.username, "Intelligence Bot: A machine Learning do Grupo UNI");
                    var toAddress = new MailAddress(toAddresses[0], null);

                    var smtp = new SmtpClient
                    {
                        Host = credentials.smtpServer,
                        Port = credentials.smtpPort,
                        EnableSsl = credentials.useSsl,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, credentials.password)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    })
                    {
                        // add additional to addresses
                        for (int i = 1; i < toAddresses.Count; i++)
                        {
                            message.To.Add(toAddresses[i]);
                        }

                        // add cc address
                        message.CC.Add(ccAddress);



                        long totalAttachmentSize = 0;

                        if (withSheet)
                        {
                            var groupedAttachments = additionalAttachments
                                .Where(a => a.format.Contains("E"))
                                .GroupBy(a => a.Id);

                            foreach (var group in groupedAttachments)
                            {
                                var memoryStream = new MemoryStream(Exportacao.toByteExcelFromArchives(group.ToList()));
                                totalAttachmentSize += memoryStream.Length;

                                // Reseta o cursor do stream antes de anexar
                                memoryStream.Position = 0;

                                string titleReport = group.First().titleReport;  // Aqui pegamos o titleReport do primeiro item do grupo.
                                string fileName = $"{titleReport.substituirCaracteresEspeciais()}_{group.Key}.xlsx";
                                message.Attachments.Add(new Attachment(memoryStream, fileName));
                            }
                        }

                        //add additional attachments
                        if (additionalAttachments != null)
                        {
                            foreach (var attachment in additionalAttachments)
                            {
                                MemoryStream stream = null;
                                if (attachment.format.Contains("X"))
                                {
                                    var xmlFilePath = Exportacao.toXmlWithPath(attachment.data, attachment.description);
                                    stream = new MemoryStream(File.ReadAllBytes(xmlFilePath));
                                    totalAttachmentSize += stream.Length;

                                    // Reseta o cursor do stream antes de anexar
                                    stream.Position = 0;
                                    message.Attachments.Add(new Attachment(stream, $"{attachment.description}.xml"));
                                }
                                if (attachment.format.Contains("J"))
                                {
                                    var jsonFilePath = Exportacao.toJsonWithPath(attachment.data, attachment.description);
                                    stream = new MemoryStream(File.ReadAllBytes(jsonFilePath));
                                    totalAttachmentSize += stream.Length;

                                    // Reseta o cursor do stream antes de anexar
                                    stream.Position = 0;
                                    message.Attachments.Add(new Attachment(stream, $"{attachment.description}.json"));
                                }
                                if (!withSheet && attachment.format.Contains("E"))
                                {
                                    stream = new MemoryStream(Exportacao.toByteExcelFromArchive(attachment));
                                    totalAttachmentSize += stream.Length;

                                    // Reseta o cursor do stream antes de anexar
                                    stream.Position = 0;
                                    message.Attachments.Add(new Attachment(stream, $"{attachment.description}.xlsx"));
                                }
                            }
                        }

                        const long fiftyMB = 50L * 1024 * 1024;
                        if (totalAttachmentSize > fiftyMB)
                        {
                            return "Erro: A soma dos tamanhos dos anexos excede 50 MB.";
                        }
                        try
                        {
                            await smtp.SendMailAsync(message);
                            foreach (var i in toAddresses)
                                Console.WriteLine("email enviado para " + i);
                            return "Notificado";
                        }
                        catch (SmtpException ex)
                        {
                            Console.WriteLine($"Falha de SMTP com as credenciais {credentials.service}- {credentials.username}: " + ex.Message);
                        }
                    }
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine($"Falha de SMTP com as credenciais {credentials.service}- {credentials.username}: " + ex.Message);
                }
            }

            return "Falha de SMTP: Todas as tentativas com diferentes credenciais falharam.";
        }
        public static string GenerateHtmlWithDataTableAndList(List<string> itemList)
        {
            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.Append("<div style='margin-top: 20px; margin-bottom: 20px;'>");

            // Título da lista
            htmlBuilder.Append("<p style='font-size: 14px; color: black; font-weight: bold;'>Os anexos deste e-mail são:</p>");

            htmlBuilder.Append("<ul style='list-style-type: disc; margin-left: 20px;'>");

            foreach (string item in itemList)
            {
                htmlBuilder.Append("<li style='font-size: 12px;'><strong>").Append(item).Append("</strong></li>");
            }

            htmlBuilder.Append("</ul>");
            htmlBuilder.Append("</div>");

            return htmlBuilder.ToString();
        }
        public static string ConvertDataTableToHtml(DataTable dt)
        {
            string html = null;
            if (dt != null)
            {
                html = "<table style='border: solid 1px #DDD; width: 100%;'>";
                //add header row
                html += "<tr style='background-color: #f2f2f2;'>";

                for (int i = 0; i < dt.Columns.Count; i++)
                    html += $"<th style='padding: 10px; border: solid 1px #DDD; color: #800020;'>{dt.Columns[i].ColumnName}</th>";
                html += "</tr>";
                //add rows
                decimal total = 0m;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "<tr>";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        object cellData = dt.Rows[i][j];
                        if (cellData is DateTime)
                        {
                            html += $"<td style='padding: 10px; border: solid 1px #DDD;'>{((DateTime)cellData).ToString("dd-MM-yyyy")}</td>";
                        }
                        else if (cellData is decimal)
                        {
                            decimal cellValue = (decimal)cellData;
                            total += cellValue;
                            html += $"<td style='padding: 10px; border: solid 1px #DDD; text-align: right;'>{cellValue.ToString("C")}</td>";
                        }
                        else
                        {
                            html += $"<td style='padding: 10px; border: solid 1px #DDD;'>{cellData.ToString()}</td>";
                        }
                    }
                    html += "</tr>";
                }
                //add total row
                html += "<tr>";
                html += $"<td colspan='{(dt.Columns.Count - 1)}' style='padding: 10px; border: solid 1px #DDD; text-align: right;'><strong>Total:</strong></td>";
                html += $"<td style='padding: 10px; border: solid 1px #DDD; text-align: right;'><strong>{total.ToString("C")}</strong></td>";
                html += "</tr>";
                html += "</table>";
            }
            return html;
        }
    }
}
