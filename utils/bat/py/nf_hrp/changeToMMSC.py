# coding uft-8
import re

file_name = 'D:\\NF\\CS\\hrp.Web\\Web.config'
fp = open(file_name, 'r')
alllines = fp.readlines()
fp.close()
fp = open(file_name, 'w')
for eachline in alllines:
    a = eachline
    if a.find('<!--') > -1:
        a = re.sub(
            '<!--<add name="ylsbgl_bs" connectionString="Data Source=nf251;User ID=mmsc;password=yygl;Unicode=True" providerName="System.Data.OracleClient" />-->',
            '<add name="ylsbgl_bs" connectionString="Data Source=nf251;User ID=mmsc;password=yygl;Unicode=True" providerName="System.Data.OracleClient" />',
            a)
    if a.find('<!--') == -1:
        a = re.sub(
            '<add name="ylsbgl_bs" connectionString="Data Source=orcl;User ID=nf_hrp;password=yygl;Unicode=True" providerName="System.Data.OracleClient" />',
            '<!--<add name="ylsbgl_bs" connectionString="Data Source=orcl;User ID=nf_hrp;password=yygl;Unicode=True" providerName="System.Data.OracleClient" />-->',
            a)
        a = re.sub(
            '<add name="ylsbgl_bs" connectionString="Data Source=nf251;User ID=nf_ylsbgl;password=yygl;Unicode=True" providerName="System.Data.OracleClient" />',
            '<!--<add name="ylsbgl_bs" connectionString="Data Source=nf251;User ID=nf_ylsbgl;password=yygl;Unicode=True" providerName="System.Data.OracleClient" />-->',
            a)
    fp.writelines(a)
fp.close()
