using System;

using MacroScope;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class BoschSP
    {
        [TestMethod]
        public void TestSelectStatementQueryNr12()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar, rostartdt, 120) as dat, 
    convert(nvarchar, rostartdt, 120) as tme,
    convert(nvarchar(250), 'de vorige sessie is niet correct afgesloten, de starttijd kan niet aangepast worden.') as waarsch,
    0 as sort
from fv_labour
where labourstatus_id = 1 and engineer_id = 4
union
select convert(nvarchar, getdate(), 120) as dat, 
    substring(convert(nvarchar, dateadd(mi, case 
        when datepart(mi, getdate()) between 53 and 59 then 60
        when datepart(mi, getdate()) between 0 and 7 then 0
        when datepart(mi, getdate()) between 8 and 22 then 15
        when datepart(mi, getdate()) between 23 and 37 then 30
        else 45
    end - datepart(mi, getdate()), getdate()), 120),1,16) + ':00' as tme,
    convert(nvarchar(250), '') as waarsch,
    1 as sort
order by sort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr14()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, engineer_id, labourstatus_id, startdt, rostartdt, verifydt, radiostatus_id, is_modified) select newid(), 4, 1, getdate(), '02/20/2012 18:55:00', '02/20/2012 18:55:00', 0, 0
from fv_engineer where id = 4
and not exists (select id from fv_labour where labourstatus_id = 1 and engineer_id = 4)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr21()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_engineer set last_labour_roenddt = '02/20/2012 18:55:00'
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr41()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cnt
from fv_labour
where labourstatus_id = 1 and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr159()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '08/08/2012 11:35:00' as dt from fv_engineer where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr178()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id as labid
from fv_labour
where labourstatus_id = 1 and activity_id is null and engineer_id = 4 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete fv_labour where labourstatus_id = 4 and activity_id is null and engineer_id = 4 and parent_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select a.eventnumber as incidentnr, 
    coalesce(a.name, cus.customername) as klant, 
    con.serviceobjecttype as installatie, 
    con.contracttype as contract, 
    a.region_oms_number as regio, coalesce(a.street, cus.street,'') + '
' + coalesce(a.zip, cus.zip, '') + ' ' + coalesce(a.city, cus.city, '') as adres, 
    a.contact as contactpers, a.building as gebouw, a.room as ruimte,
    a.label as lab, 
    a.serialnumber as serienummer,
    coalesce(a.phone, cus.phone, a.mobilephone) as telefoon
from fv_activity a
    left outer join fv_customer cus
        on cus.id = a.customer_id
    left outer join fv_contract con
        on a.contract_id = con.id and con.isactive = 1 
    left outer join fv_serviceobject sob
        on sob.id = a.serviceobject_id
    left outer join fv_serviceobjecttype sot
        on sot.id = sob.serviceobjecttype_id
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr1Reduced()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    a.region_oms_number as regio, coalesce(a.street, cus.street,'') + N'
' + coalesce(a.zip, cus.zip, '') + ' ' + coalesce(a.city, cus.city, '') as adres, 
    a.contact as contactpers, a.building as gebouw, a.room as ruimte,
    a.label as lab, 
    a.serialnumber as serienummer,
    coalesce(a.phone, cus.phone, a.mobilephone) as telefoon
from fv_activity a
    left outer join fv_customer cus
        on cus.id = a.customer_id
    left outer join fv_contract con
        on a.contract_id = con.id and con.isactive = 1 
    left outer join fv_serviceobject sob
        on sob.id = a.serviceobject_id
    left outer join fv_serviceobjecttype sot
        on sot.id = sob.serviceobjecttype_id
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr3()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntstat50 from fv_activitystatus
where activitystatustype_id = 50 
and activity_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr4()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, activity_id, signaturecode_id, entrydt, printsend, radiostatus_id, send_email)
select newid(), '00000000-0000-0000-0000-000000000000', 1, getdate(), 0, -1, 1
where not exists(select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr5()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntlabtravel from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000'
and labourstatus_id = 3
and enddt is null
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr7()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntlabwork from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000'
and labourstatus_id = 2
and enddt is null
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr49()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id as labid
from fv_labour
where labourstatus_id = 1 and activity_id is null and engineer_id = 4 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr2()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select a.external_id as fvticket, a.notes as opmplanner, a.description as omschrijving
from fv_activity a 
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement2Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_history.id,
    convert(nvarchar, fv_history.debrief_entrydt, 105) as datum,
    fv_history.engineer as fst,
    fv_history.activitytype as opdrtype
from fv_history
inner join fv_activity
    on fv_activity.id = '00000000-0000-0000-0000-000000000000'
    and fv_history.serviceobject_id = fv_activity.serviceobject_id
order by debrief_entrydt desc
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            var analyser = new Analyzer();
            statement.Traverse(analyser);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr143()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select causecode as incident,
    solutioncode as oplossing,
    engineer_notes as intopm
from fv_history
where id = 00000000-0000-0000-0000-000000000000
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr105()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id, engineer_notes)
select newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), 160, 0, ''
from fv_engineer
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr106()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 160
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr100()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_debrief.causecode, fv_activity.description) as opdrachtomschr, solutioncode as oplossing, case when is_external = 1 then 'true' else 'false' end as externeoorz,
stat_divisioncode_id as statdivisioncode, stat_productcode_id as statproductcode,
stat_incidentcode_id as statincidentcode, stat_ordercode_id as statordercode
from fv_debrief 
inner join fv_activity
    on fv_activity.id = fv_debrief.activity_id
where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr101()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set causecode = '0', solutioncode = '', is_external = case when '0' = 'true' then 1 else 0 end, co_debrief_mat = 0, signaturecode_id = 2, radiostatus_id = 0,
stat_divisioncode_id = 0, stat_productcode_id = 0,
stat_incidentcode_id = 0, stat_ordercode_id = 0,
stat_conclusioncode_id = 8,
solutiondt = getdate(), is_finished = 1
where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr102()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 65, 0
from fv_engineer 
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr103()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 65
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement3Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_divisioncode
where isactive = 1
order by code
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement4Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_productcode
where isactive = 1
and stat_divisioncode_id = case when '0' = '' then null else 0 end
order by code");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement5Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_incidentcode
where isactive = 1
order by code");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement6Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_ordercode
where isactive = 1
order by code");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement7()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement8()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr8()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, labourstatus_id, startdt, rostartdt, verifydt, is_modified, parent_id, radiostatus_id) select newid(), '00000000-0000-0000-0000-000000000000', 4, 4, getdate(), last_labour_roenddt, '02/20/2012 18:55:00', 0, '00000000-0000-0000-0000-000000000000', -1
from fv_engineer 
where id = 4
and not exists (select id from fv_labour where labourstatus_id = 4 and activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and enddt is null and parent_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr9()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar, a.reportdt, 105) + ' ' + substring(convert(nvarchar, a.reportdt, 108),1,5) as meldingstijd,
convert(nvarchar, convert(decimal(12,2), coalesce(a.responsetime, 0))) as reponse,
a.contact as contactp,
coalesce(a.street, '') + '
' + coalesce(a.zip, '') + ' ' + coalesce(a.city, '') as adres,
a.building as gebouw,
a.room as ruimte,
coalesce(ls.id, 3) as reistype,
coalesce(a.phone, cus.phone, a.mobilephone) as telefoon
from fv_activity a
left outer join fv_customer cus
    on cus.id = a.customer_id
cross join (select max(l.startdt) as maxstartdt from fv_labour l where l.activity_id = '00000000-0000-0000-0000-000000000000' and l.engineer_id = 4 and l.enddt is null) l
left outer join fv_labour lab
    on lab.activity_id = a.id
    and lab.engineer_id = 4
    and lab.startdt = l.maxstartdt
inner join fv_labourstatus ls
    on ls.id = lab.labourstatus_id
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr15()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set enddt = getdate(), roenddt = convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 0 and 14 then 15
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 15 and 29 then 30
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 30 and 44 then 45
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 45 and 59 then 60
            end - datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 
    dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 120),1,16)), radiostatus_id = -1, labourstatus_id = 0
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr22()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id 
from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and roenddt is null and labourstatus_id = 4 and parent_id = '00000000-0000-0000-0000-000000000000'

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr62()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 40, 0
from fv_engineer 
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr63()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 40
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement9Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_labourstatus
where labourstatustype_id = 1 and isactive = 1
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr10()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, labourstatus_id, startdt, rostartdt, verifydt, is_modified, parent_id, radiostatus_id) select newid(), '00000000-0000-0000-0000-000000000000', 4, 2, getdate(), last_labour_roenddt, '02/20/2012 18:55:00', 0, '00000000-0000-0000-0000-000000000000', -1
from fv_engineer 
where id = 4
and not exists (select id from fv_labour where labourstatus_id = 2 and activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and enddt is null and parent_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr11()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select a.eventnumber as incidentnr,
    a.name as klant,
    con.serviceobjecttype as installtie,
    con.contracttype as contractj,
    a.region_oms_number as regio,
    coalesce(a.street, '') + '
' + coalesce(a.zip, '') + ' ' + coalesce(a.city, '') as adres,
    a.contact as contactp,
    a.building as gebouw,
    a.room as ruimte,
    a.label as lab,
    a.serialnumber as serienr
from fv_activity a
left outer join fv_serviceobject sob
    on sob.id = a.serviceobject_id
left outer join fv_contract con
    on con.id = a.contract_id and con.isactive = 1
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr24()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id 
from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and roenddt is null and labourstatus_id = 2 and parent_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr64()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 50, 0
from fv_engineer 
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr65()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 50
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement10()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement11()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement12()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) from fv_debrief inner join fv_debrief_material on debrief_id = fv_debrief.id
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement13()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) from fv_debrief inner join fv_debrief_material on debrief_id = fv_debrief.id
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr19()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set enddt = getdate(), roenddt = convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 0 and 14 then 15
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 15 and 29 then 30
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 30 and 44 then 45
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 45 and 59 then 60
            end - datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 
    dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 120),1,16)), radiostatus_id = -1
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr26()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when is_external = 1 then 'true' else 'false' end as externeoorz,
case when is_finished = 1 then 'true' else 'false' end as opdrgereed,
stat_divisioncode_id as statdivisioncode, stat_productcode_id as statproductcode,
stat_incidentcode_id as statincidentcode, stat_ordercode_id as statodercode,
stat_conclusioncode_id as statconclusioncode
from fv_debrief
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr145()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief
set solutiondt = getdate()
where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr148()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 55, 0
from fv_engineer 
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr149()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 55
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement14Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_divisioncode
where isactive = 1
order by code
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement15Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_productcode
where isactive = 1
and stat_divisioncode_id = case when '0' = '' then null else 0 end
order by code");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement16Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_incidentcode
where isactive = 1
order by code");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement17Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_ordercode
where isactive = 1
order by code");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement18Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, '[' + code + '] ' + description
from fv_stat_conclusioncode
where isactive = 1
order by code");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr16()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(a.name, '') + '
' + coalesce(a.street, '') + '
' + coalesce(a.zip, '') + '  ' + coalesce(a.city, '') + '
contactpersoon: ' + coalesce(a.contact, '') + '
tel: ' + coalesce(a.phone, '') + '
email: ' + coalesce(a.email, '') as klantdata,
deb.customerinfo_update as wijziging
from fv_activity a
inner join fv_debrief deb
    on deb.activity_id = a.id
where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr17()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(deb.causecode, act.description) as opdrachtomschr, deb.solutioncode as oplossing, deb.engineer_notes as interneopm, deb.solutiondt as dt, deb.solutiondt as tm
from fv_debrief deb
inner join fv_activity act
    on deb.activity_id = act.id
where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr18()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    1 as sort, 
    dm.articlenumber as artikelnr,
    dm.notes as omschrijving,
    dm.depotcode as magcode,
    replace(convert(nvarchar, dm.amount), '.', ',') as aantal,
    dm.label as lab,
    dm.serialnumber_old as serieoud,
    dm.serialnumber_new as seriennw
from fv_debrief_material dm
where '00000000-0000-0000-0000-000000000000' <> '' and dm.id = '00000000-0000-0000-0000-000000000000'
union
select     2 as sort, 
    '' as artikelnr,
    '' as omschrijving,
    '' as magcode,
    '' as aantal,
    '' as lab,
    '' as serieoud,
    '' as seriennw
from fv_engineer
where id = 4
order by sort
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement19()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_material where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement20Component99()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    dm.id as debmatid, 
    dm.articlenumber as artikelnr,
    dm.notes as omschrijving,
    dm.depotcode as magcode,
    dm.amount as aantal
from fv_debrief deb
inner join fv_debrief_material dm
    on deb.id = dm.debrief_id
where deb.activity_id = '00000000-0000-0000-0000-000000000000'
order by dm.articlenumber
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr27()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select dateadd(mi, datediff(mi, rostartdt, roenddt), '1900-01-01 00:00:00') as duur, roenddt as eindtijd, 0 as sort, rostartdt as starttijd, datediff(mi, rostartdt, roenddt) as orgduur, labourstatus_id as splitlabstatusid
from fv_labour
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr33()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set no_ext_engineers = 0, no_ext_hours = convert(numeric(18,2), datediff(mi, '1900-01-01 00:00:00', '1900-01-01 ' + convert(nvarchar,convert(datetime,'09/08/2012 14:54:00'),108))) / 60, entrydt = getdate()
where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr34()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select no_ext_engineers as aant_tech,
    dateadd(mi, no_ext_hours * 60, '1900-01-01 00:00:00') as uren_tech,
    '1900-01-01 12:00:00' as pauzestart
from fv_debrief  
where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr52()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(uniqueidentifier, '10000000-0000-0000-0000-000000000000')
from fv_engineer
where id = 4 
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr59()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as pauze_cnt
from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and engineer_id = 4
and labourstatus_id = 5
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr60()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set is_modified = 1, radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and is_modified = 0 and engineer_id = 4 and 1=2
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr109()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(id) as id
from fv_labour 
where '08/08/2012 11:33:00' = rostartdt
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr110()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(id) as id
from fv_labour 
where '08/08/2012 11:33:00' = roenddt
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr111()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datediff(mi, rostartdt, '08/08/2012 11:33:00') as duursplit
from fv_labour 
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr161()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datediff(dd, rostartdt, roenddt) as dagovergang
from fv_labour
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement21Component101()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_labour.id, 
    convert(nvarchar, rostartdt, 105) as datum,
    substring(convert(nvarchar, rostartdt, 108),1,5) as van, 
    substring(convert(nvarchar, roenddt, 108),1,5) as tot,
    fv_labourstatus.description as type,
    substring(convert(nvarchar, dateadd(mi, datediff(mi, rostartdt, roenddt), '1900-01-01 00:00:00'), 120), 12, 5) as duur
from fv_labour
inner join fv_labourstatus
    on fv_labourstatus.id = fv_labour.labourstatus_id
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' 
    and is_modified = 0
order by rostartdt, roenddt
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement22()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement23()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement24()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*7*/ update fv_labour set roenddt = dateadd(mi, datediff(mi, '1900-01-01 00:00:00', '1900-01-01 '+ convert(nvarchar,convert(datetime,'09/08/2012 14:55:00'), 108)), rostartdt)
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement25()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement26()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement27()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement28()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement29()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*4*/ update fv_labour set rostartdt = dateadd(mi, 45, rostartdt), roenddt = dateadd(mi, 45, roenddt)
where datediff(mi, convert(datetime, '08/08/2012 11:33:00'), rostartdt) >= 0
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement30()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*2*/ update fv_labour set roenddt = convert(datetime, '08/08/2012 11:33:00')
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement31()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*3*/ insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
select newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), getdate(), '08/08/2012 16:44:00',
dateadd(mi, 0 - 0, convert(datetime, '08/08/2012 16:44:00')), '02/20/2012 18:55:00', 0, -1, 0, '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement32()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*5*/ insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
select newid(), '00000000-0000-0000-0000-000000000000', 4, dateadd(s, -10, getdate()), dateadd(s, -10, getdate()), convert(datetime, '08/08/2012 11:33:00'),
convert(datetime, '08/08/2012 16:44:00'), '02/20/2012 18:55:00', 5, -1, 0, '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement33()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement34()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr54()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar(36), id) as inlabourid, 0 as sort
from fv_labour
where convert(datetime, substring('02/20/2012 18:55:00',1 , 11) + convert(nvarchar,convert(datetime,'08/08/2012 11:34:00'), 108)) > rostartdt 
    and convert(datetime, substring('02/20/2012 18:55:00',1 , 11) + convert(nvarchar,convert(datetime,'08/08/2012 11:34:00'), 108)) < roenddt
and activity_id = '00000000-0000-0000-0000-000000000000'
union
select '' as inlabourid, 1 as sort
from fv_engineer
where id = 4 
order by sort
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr55()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar(36), id) as startlabourid, 0 as sort
from fv_labour
where rostartdt = convert(datetime, substring('02/20/2012 18:55:00',1,11) + convert(nvarchar,convert(datetime,'08/08/2012 11:34:00'), 108))
and roenddt > dateadd(mi, 0, convert(datetime, substring('2008-07-28 08:00:00',1,11) + convert(nvarchar,convert(datetime,'2008-07-30t08:45:00'), 108)))
and activity_id = '00000000-0000-0000-0000-000000000000'
union
select '' as startlabourid, 1 as sort
from fv_engineer
where id = 4 
order by sort
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr56()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datediff(mi, '1900-01-01 00:00:00', '1900-01-01 ' + convert(nvarchar,convert(datetime,'09/08/2012 13:54:00'), 108)) as duration");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr57()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar(36), id) as overlaplabourid, 0 as sort
from fv_labour 
where dateadd(mi, datediff(mi, '1900-01-01 00:00:00', '1900-01-01 ' + convert(nvarchar,convert(datetime, '09/08/2012 13:54:00'), 108)), 
    convert(datetime, substring('02/20/2012 18:55:00',1,11) + convert(nvarchar,convert(datetime, '08/08/2012 11:34:00'), 108))) > roenddt
and convert(datetime, substring('02/20/2012 18:55:00',1,11) + convert(nvarchar,convert(datetime, '08/08/2012 11:34:00'), 108)) between rostartdt and roenddt
and activity_id = '00000000-0000-0000-0000-000000000000'
union
select '' as overlaplabourid, 1 as sort
from fv_engineer
where id = 4 
order by sort
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement35Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_labour.id, 
    convert(nvarchar, rostartdt, 105) as datum,
    substring(convert(nvarchar, rostartdt, 108),1,5) as van, 
    substring(convert(nvarchar, roenddt, 108),1,5) as tot,
    fv_labourstatus.description as type
from fv_labour
inner join fv_labourstatus
    on fv_labourstatus.id = fv_labour.labourstatus_id
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' 
    and is_modified = 0
order by rostartdt
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement36()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
select newid(), activity_id, engineer_id, getdate(), getdate(), convert(datetime, substring(convert(nvarchar, '02/20/2012 18:55:00', 120), 1, 11) + convert(nvarchar, '08/08/2012 11:36:00', 108)),
dateadd(mi, 0, convert(datetime, substring(convert(nvarchar, '02/20/2012 18:55:00', 120), 1, 11) + convert(nvarchar, '08/08/2012 11:36:00', 108))), '02/20/2012 18:55:00', 5, -1, 0, '00000000-0000-0000-0000-000000000000'
from fv_labour 
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement37()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
select newid(), activity_id, engineer_id, getdate(), getdate(), dateadd(mi, 0, convert(datetime, substring(convert(nvarchar, '02/20/2012 18:55:00', 120),1 , 11) + convert(nvarchar, '08/08/2012 11:36:00', 108))),
roenddt, '02/20/2012 18:55:00', 2, -1, 0, '00000000-0000-0000-0000-000000000000'
from fv_labour 
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement38()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set roenddt = 
convert(datetime, substring(convert(nvarchar, '02/20/2012 18:55:00', 120),1,11) + convert(nvarchar, '08/08/2012 11:36:00', 108))
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement39()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
select newid(), activity_id, engineer_id, getdate(), getdate(), convert(datetime, substring(convert(nvarchar, '02/20/2012 18:55:00', 120),1,11) + convert(nvarchar, '08/08/2012 11:36:00', 108)),
dateadd(mi, 0, convert(datetime, substring(convert(nvarchar, '02/20/2012 18:55:00', 120),1 , 11) + convert(nvarchar, '08/08/2012 11:36:00', 108))), '02/20/2012 18:55:00', 5, -1, 0, '00000000-0000-0000-0000-000000000000'
from fv_labour 
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement40()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set rostartdt = 
dateadd(mi, 0, convert(datetime, substring(convert(nvarchar, '02/20/2012 18:55:00', 120),1 , 11) + convert(nvarchar, '08/08/2012 11:36:00', 108)))
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement41()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  count(0)
from    fv_debrief
inner join fv_debrief_material on debrief_id = fv_debrief.id
where   activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement42()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when flow_id <> 1 then 1
                                   else fv_debrief.is_finished
                              end
                       from   fv_activitytype
                       inner join fv_activity
                              on fv_activity.id = '00000000-0000-0000-0000-000000000000'
                                 and fv_activity.activitytype_id = fv_activitytype.id
                       inner join fv_debrief
                              on fv_activity.id = fv_debrief.activity_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement43()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when flow_id <> 1 then 1
                                   else fv_debrief.is_finished
                              end
                       from   fv_activitytype
                       inner join fv_activity
                              on fv_activity.id = '00000000-0000-0000-0000-000000000000'
                                 and fv_activity.activitytype_id = fv_activitytype.id
                       inner join fv_debrief
                              on fv_activity.id = fv_debrief.activity_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement44()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from
    fv_debrief
where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement45()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from
    fv_debrief
where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr35()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select e.username as fst,
    coalesce(sig.name, a.contact) as klant,
    coalesce(d.email, a.email) as mail,
    d.solutioncode as sam,
    sig.signature as sign,
    case when d.send_email = 1 then 'true' else 'false' end as mail_werkbon,
    coalesce(d.signaturecode_id, 1) as tekendvoor,
    convert(nvarchar, d.solutiondt, 105) + ' ' + substring(convert(nvarchar, d.solutiondt, 108),1,5) as afmelding
from fv_activity a
inner join fv_debrief d
    on d.activity_id = a.id
left outer join fv_debrief_signature sig
    on sig.debrief_id = d.id
inner join fv_engineer e
    on e.id = a.engineer_id
where a.id = '00000000-0000-0000-0000-000000000000'    
    

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr45()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into
    fv_debrief_signature
    (
      id,
      debrief_id,
      radiostatus_id,
      signdt
    )
    select
        newid(),
        fv_debrief.id,
        -1,
        getdate()
    from
        fv_debrief
    where
        activity_id = '00000000-0000-0000-0000-000000000000'
        and not exists ( select
                            fv_debrief_signature.id
                         from
                            fv_debrief_signature
                            inner join fv_debrief
                                on fv_debrief_signature.debrief_id = fv_debrief.id
                                   and fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000' )
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr68()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 00000000-0000-0000-0000-000000000000, 0
from fv_engineer 
where ((id = 4) and ('N' <> 'h'))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr69()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 00000000-0000-0000-0000-000000000000
where ((id = '00000000-0000-0000-0000-000000000000') and ('N' <> 'h'))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr70()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select to_activitystatustype_id as to_actstatus_id
from fv_signaturecode
where id = case when '0' = '' then null else 0 end");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr72()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id as labid
from fv_labour
where labourstatus_id = 1 and activity_id is null and engineer_id = 4 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr142()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'incident: ' + coalesce(fv_debrief.causecode, '') + ' oplossing: ' + coalesce(fv_debrief.causecode, fv_activity.description, '')  +  ' externe oorzaak: ' + case when fv_debrief.is_external = 1 then 'ja' else 'nee' end + ' opdracht gereed: ' + case when fv_debrief.is_finished = 1 then 'ja' else 'nee' end as sam
from fv_activity
inner join fv_debrief
    on fv_activity.id = fv_debrief.activity_id
inner join fv_activitytype
    on fv_activitytype.id = fv_activity.activitytype_id
    and fv_activitytype.flow_id = 1
where activity_id = '00000000-0000-0000-0000-000000000000'
union
select 'uitgevoerde werkzaamheden: ' + coalesce(fv_debrief.notes, '') as sam
from fv_activity
inner join fv_debrief
    on fv_activity.id = fv_debrief.activity_id
inner join fv_activitytype
    on fv_activitytype.id = fv_activity.activitytype_id
    and fv_activitytype.flow_id = 2
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr158()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set is_modified = 1, radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and is_modified = 0 and engineer_id = 4 and 'N' <> 'h'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement46Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description 
from fv_signaturecode
where isactive = 1
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement47()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement48()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement49()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set signaturecode_id = 0, email = '' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement50()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_param_mobile set paramvalue = '00000000-0000-0000-0000-000000000000' where id = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr38()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_debrief.no_ext_hours as uren_tech,
    fv_debrief.no_ext_engineers as aant_tech,
    coalesce(fv_debrief.causecode, fv_activity.description, '') as incident,
    fv_debrief.solutioncode as oplossing,
    case when fv_debrief.is_external = 1 then 'ja' else 'nee' end as externeoorz,
    case when fv_debrief.is_finished = 1 then 'ja' else 'nee' end as gereed,
    fv_debrief.notes as uitgwzh,
    fv_activitytype.flow_id as flowid
from fv_activity
inner join fv_debrief
    on fv_activity.id = fv_debrief.activity_id
inner join fv_activitytype
    on fv_activitytype.id = fv_activity.activitytype_id
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement51Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    dm.id as debmatid, 
    dm.articlenumber as artikelnr,
    dm.notes as omschrijving,
    dm.depotcode as magcode,
    dm.amount as aantal
from fv_debrief deb
inner join fv_debrief_material dm
    on deb.id = dm.debrief_id
where deb.activity_id = '00000000-0000-0000-0000-000000000000'
order by dm.articlenumber
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr39()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select customer_notes as klantopm
from fv_debrief
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement52()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt
    from fv_labour 
    where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement53()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt
    from fv_labour 
    where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement54()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select activitystatustype_id from fv_cancelreason where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement55()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select activitystatustype_id from fv_cancelreason where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr28()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set enddt = getdate(), roenddt = convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 0 and 14 then 15
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 15 and 29 then 30
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 30 and 44 then 45
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 45 and 59 then 60
            end - datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 
    dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 120),1,16))
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr29()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select dateadd(mi, datediff(mi, rostartdt, roenddt), '1900-01-01 00:00:00') as duur, roenddt as eindtijd, 0 as sort, rostartdt as starttijd, datediff(mi, rostartdt, roenddt) as orgduur, labourstatus_id as splitlabstatusid
from fv_labour
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr30()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 1 as defcancel
from fv_engineer where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr32()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set is_modified = 1, radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and is_modified = 0 and engineer_id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr112()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as pauze_cnt
from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and engineer_id = 4
and labourstatus_id = 5
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr113()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(id) as id
from fv_labour 
where '08/08/2012 11:33:00' = rostartdt
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr114()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(id) as id
from fv_labour 
where '08/08/2012 11:33:00' = roenddt
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr115()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datediff(mi, rostartdt, '08/08/2012 11:33:00') as duursplit
from fv_labour 
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr162()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datediff(dd, rostartdt, roenddt) as dagovergang
from fv_labour
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr181()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, engineer_notes, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), activitystatustype_id, '',0
from fv_cancelreason where id = 0
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement56Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_cancelreason where isactive = 1 and activitystatustype_id in (140,150) order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement57Component142()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_labour.id, 
    convert(nvarchar, rostartdt, 105) as datum,
    substring(convert(nvarchar, rostartdt, 108),1,5) as van, 
    substring(convert(nvarchar, roenddt, 108),1,5) as tot,
    fv_labourstatus.description as type,
    substring(convert(nvarchar, dateadd(mi, datediff(mi, rostartdt, roenddt), '1900-01-01 00:00:00'), 120), 12, 5) as duur
from fv_labour
inner join fv_labourstatus
    on fv_labourstatus.id = fv_labour.labourstatus_id
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000'
and fv_labour.is_modified = 0
order by rostartdt, roenddt
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement58()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement59()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement60()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*17*/ update fv_labour set roenddt = dateadd(mi, datediff(mi, '1900-01-01 00:00:00', '1900-01-01 '+ convert(nvarchar, '09/08/2012 13:55:00', 108)), rostartdt)
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement61()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement62()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement63()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement64()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement65()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*4*/ update fv_labour set rostartdt = dateadd(mi, 45, rostartdt), roenddt = dateadd(mi, 45, roenddt)
where datediff(mi, convert(datetime, '08/08/2012 11:33:00'), rostartdt) >= 0
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement66()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*2*/ update fv_labour set roenddt = convert(datetime, '08/08/2012 11:33:00')
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement67()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*3*/ insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
values (newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), getdate(), '08/08/2012 16:44:00',
dateadd(mi, 0 - 0, convert(datetime, '08/08/2012 16:44:00')), '02/20/2012 18:55:00', 0, -1, 0, '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement68()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*5*/ insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
select newid(), '00000000-0000-0000-0000-000000000000', 4, dateadd(s, -10, getdate()), dateadd(s, -10, getdate()), convert(datetime, '08/08/2012 11:33:00'),
convert(datetime, '08/08/2012 16:44:00'), '02/20/2012 18:55:00', 5, -1, 0, '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement69()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement70()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr118()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(a.ordernumber,a.external_id) as ordernr, 
    coalesce(a.name, cus.customername) as klant, 
    con.serviceobjecttype as installatie, 
    con.contracttype as contract, 
    a.region_oms_number as regio, coalesce(a.street, cus.street,'') + '
' + coalesce(a.zip, cus.zip, '') + ' ' + coalesce(a.city, cus.city, '') as adres, 
    a.contact as contactpers, a.building as gebouw, a.room as ruimte,
    a.label as lab, 
    a.serialnumber as serienummer,
    coalesce(a.phone, cus.phone, a.mobilephone) as telefoon
from fv_activity a
    left outer join fv_customer cus
        on cus.id = a.customer_id
    left outer join fv_contract con
        on a.contract_id = con.id and con.isactive = 1
    left outer join fv_serviceobject sob
        on sob.id = a.serviceobject_id
    left outer join fv_serviceobjecttype sot
        on sot.id = sob.serviceobjecttype_id
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr119()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntstat50 from fv_activitystatus
where activitystatustype_id = 50 
and activity_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr120()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntlabtravel from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000'
and labourstatus_id = 3
and enddt is null
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr121()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntlabwork from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000'
and labourstatus_id = 2
and enddt is null
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr122()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id as labid
from fv_labour
where labourstatus_id = 1 and activity_id is null and engineer_id = 4 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr123()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, activity_id, signaturecode_id, entrydt, printsend, radiostatus_id, send_email)
select newid(), '00000000-0000-0000-0000-000000000000', 1, getdate(), 0, -1, 1
where not exists(select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement71()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement72()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr124()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select a.contact as contactp,
coalesce(a.street, '') + '
' + coalesce(a.zip, '') + ' ' + coalesce(a.city, '') as adres,
a.building as gebouw,
a.room as ruimte,
coalesce(ls.id, 3) as reistype,
coalesce(a.phone, cus.phone, a.mobilephone) as telefoon
from fv_activity a
left outer join fv_customer cus
    on cus.id = a.customer_id
cross join (select max(l.startdt) as maxstartdt from fv_labour l where l.activity_id = '00000000-0000-0000-0000-000000000000' and l.engineer_id = 4 and l.enddt is null and is_modified = 0) l
left outer join fv_labour lab
    on lab.activity_id = a.id
    and lab.engineer_id = 4
    and lab.startdt = l.maxstartdt
inner join fv_labourstatus ls
    on ls.id = lab.labourstatus_id
where a.id = '00000000-0000-0000-0000-000000000000'

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr125()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id 
from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and roenddt is null and labourstatus_id = 4 and parent_id = '00000000-0000-0000-0000-000000000000'

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr126()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, labourstatus_id, startdt, rostartdt, verifydt, is_modified, parent_id, radiostatus_id) select newid(), '00000000-0000-0000-0000-000000000000', 4, 4, getdate(), last_labour_roenddt, '02/20/2012 18:55:00', 0, '00000000-0000-0000-0000-000000000000', -1
from fv_engineer 
where id = 4
and not exists (select id from fv_labour where labourstatus_id = 4 and activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and enddt is null and parent_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr127()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 40, 0
from fv_engineer 
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr128()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 40
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr129()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set enddt = getdate(), roenddt = convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 0 and 14 then 15
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 15 and 29 then 30
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 30 and 44 then 45
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 45 and 59 then 60
            end - datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 
    dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 120),1,16)), radiostatus_id = -1, labourstatus_id = 0
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement73Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_labourstatus
where labourstatustype_id = 1 and isactive = 1
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr131()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(a.ordernumber,a.external_id) as ordernr,
    a.name as klant,
    con.serviceobjecttype as installtie, 
    con.contracttype as contractj,
    a.region_oms_number as regio,
    coalesce(a.street, '') + '
' + coalesce(a.zip, '') + ' ' + coalesce(a.city, '') as adres,
    a.contact as contactp,
    a.building as gebouw,
    a.room as ruimte,
    a.label as lab,
    a.serialnumber as serienr
from fv_activity a
left outer join fv_serviceobject sob
    on sob.id = a.serviceobject_id
left outer join fv_contract con
    on con.id = a.contract_id and con.isactive = 1
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr132()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, labourstatus_id, startdt, rostartdt, verifydt, is_modified, parent_id, radiostatus_id) select newid(), '00000000-0000-0000-0000-000000000000', 4, 2, getdate(), last_labour_roenddt, '02/20/2012 18:55:00', 0, '00000000-0000-0000-0000-000000000000', -1
from fv_engineer 
where id = 4
and not exists (select id from fv_labour where labourstatus_id = 2 and activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and enddt is null and parent_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr133()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id 
from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and roenddt is null and labourstatus_id = 2 and parent_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr134()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 50, 0
from fv_engineer 
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr135()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 50
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement74()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement75()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement76()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) from fv_debrief inner join fv_debrief_material on debrief_id = fv_debrief.id where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement77()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) from fv_debrief inner join fv_debrief_material on debrief_id = fv_debrief.id where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr136()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set enddt = getdate(), roenddt = convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 0 and 14 then 15
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 15 and 29 then 30
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 30 and 44 then 45
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 45 and 59 then 60
            end - datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 
    dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 120),1,16)), radiostatus_id = -1
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr146()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief
set solutiondt = getdate()
where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr138()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes as uitgwzh, engineer_notes as intopm
from fv_debrief
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement78()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '0', engineer_notes = '' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr139()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    1 as sort, 
    dm.articlenumber as artikelnr,
    dm.notes as omschrijving,
    dm.depotcode as magcode,
    replace(convert(nvarchar, dm.amount), '.', ',') as aantal
from fv_debrief_material dm
where '00000000-0000-0000-0000-000000000000' <> '' and dm.id = '00000000-0000-0000-0000-000000000000'
union
select     2 as sort, 
    '' as artikelnr,
    '' as omschrijving,
    '' as magcode,
    '' as aantal
from fv_engineer
where id = 4
order by sort
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement79()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_material where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement80Component210()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    dm.id as debmatid, 
    dm.articlenumber as artikelnr,
    dm.notes as omschrijving,
    dm.depotcode as magcode,
    dm.amount as aantal
from fv_debrief deb
inner join fv_debrief_material dm
    on deb.id = dm.debrief_id
where deb.activity_id = '00000000-0000-0000-0000-000000000000'
order by dm.articlenumber
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr140()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_debrief.no_ext_hours as uren_tech,
    (fv_debrief.no_ext_engineers + 1) as aant_tech
from fv_debrief
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr141()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'incident: 
' + coalesce(fv_debrief.causecode, fv_activity.description, '') + '

oplossing: 
' + coalesce(fv_debrief.solutioncode, '')  +  '

externe oorzaak: ' + case when fv_debrief.is_external = 1 then 'ja' else 'nee' end + '
opdracht gereed: ' + case when fv_debrief.is_finished = 1 then 'ja' else 'nee' end as sam
from fv_activity
inner join fv_debrief
    on fv_activity.id = fv_debrief.activity_id
inner join fv_activitytype
    on fv_activitytype.id = fv_activity.activitytype_id
    and fv_activitytype.flow_id = 1
where activity_id = '00000000-0000-0000-0000-000000000000'
union
select 'uitgevoerde werkzaamheden: 
' + coalesce(fv_debrief.notes, '') as sam
from fv_activity
inner join fv_debrief
    on fv_activity.id = fv_debrief.activity_id
inner join fv_activitytype
    on fv_activitytype.id = fv_activity.activitytype_id
    and fv_activitytype.flow_id = 2
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr144()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
    dateadd(mi, sum(datediff(mi, rostartdt, roenddt)) + (max(fv_debrief.no_ext_hours) * 60), '1900-01-01 00:00:00') as uren, convert(decimal(12,2), (sum(datediff(mi, rostartdt, roenddt)) + (max(fv_debrief.no_ext_hours) * 60))/ 60) as uren_decimaal
from fv_labour
inner join fv_labourstatus
    on fv_labourstatus.id = fv_labour.labourstatus_id
    and fv_labourstatus.labourstatustype_id = 2
inner join fv_debrief
    on fv_debrief.activity_id = fv_labour.activity_id
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement81Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    dm.id as debmatid, 
    dm.articlenumber as artikelnr,
    dm.notes as omschrijving,
    dm.depotcode as magcode,
    dm.amount as aantal
from fv_debrief deb
inner join fv_debrief_material dm
    on deb.id = dm.debrief_id
where deb.activity_id = '00000000-0000-0000-0000-000000000000'
order by dm.articlenumber
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr80()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
    when (datepart(mi, getdate())) between 0 and 14 then 15
    when (datepart(mi, getdate())) between 15 and 29 then 30
    when (datepart(mi, getdate())) between 30 and 44 then 45
    when (datepart(mi, getdate())) between 45 and 59 then 60
end - datepart(mi, getdate()), getdate()), 120),1,16) + ':00') as datum,
    convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
    when (datepart(mi, getdate())) between 0 and 14 then 15
    when (datepart(mi, getdate())) between 15 and 29 then 30
    when (datepart(mi, getdate())) between 30 and 44 then 45
    when (datepart(mi, getdate())) between 45 and 59 then 60
end - datepart(mi, getdate()), getdate()), 120),1,16) + ':00') as starttijd,
    dateadd(mi, 15, convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
    when (datepart(mi, getdate())) between 0 and 14 then 15
    when (datepart(mi, getdate())) between 15 and 29 then 30
    when (datepart(mi, getdate())) between 30 and 44 then 45
    when (datepart(mi, getdate())) between 45 and 59 then 60
end - datepart(mi, getdate()), getdate()), 120),1,16) + ':00')) as eindtijd
from fv_engineer 
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr81()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datediff(mi, convert(datetime, substring('08/08/2012 11:35:00',1,11) + convert(nvarchar,convert(datetime,'08/08/2012 11:36:00'), 108)), 
    convert(datetime, substring('08/08/2012 11:35:00',1,11) + convert(nvarchar,convert(datetime,'08/08/2012 11:35:00'), 108))) as verschil
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr82()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select newid() as newguid, newid() as newsoid
from fv_engineer where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement82Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_activitytype
where billable = 0 and isactive = 1 and id > 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement83()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_serviceorder (id, orderdt, verifydt, mainengineer_id)
select '00000000-0000-0000-0000-000000000000', getdate(), '02/20/2012 18:55:00', fv_engineer.id
from fv_engineer
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement84()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activity (id, engineer_id, maxstatusdt, activitystatustype_id, planstartdt, planenddt, activitytype_id, notes, serviceorder_id, customer_id, reportdt, agendatype_id)
select '00000000-0000-0000-0000-000000000000', 4, getdate(), 30, convert(datetime, substring('08/08/2012 11:35:00',1,11) + convert(nvarchar,convert(datetime,'08/08/2012 11:36:00'), 108)), convert(datetime, substring('08/08/2012 11:35:00',1,11) + convert(nvarchar,convert(datetime,'08/08/2012 11:35:00'), 108)), 0, '', '00000000-0000-0000-0000-000000000000', 0, getdate(), 1
from fv_engineer
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement85()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), fv_activity.id, 4, fv_activity.maxstatusdt, 30, 0
from fv_activity
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement86()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, labourstatus_id, startdt, rostartdt, verifydt, is_modified, parent_id, radiostatus_id) select newid(), '00000000-0000-0000-0000-000000000000', 4, 2, getdate(), last_labour_roenddt, '02/20/2012 18:55:00', 0, '00000000-0000-0000-0000-000000000000', -1 from fv_engineer where id = 4 and not exists (select id from fv_labour where labourstatus_id = 2 and activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and enddt is null and parent_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement87()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement88()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr83()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select at.description as actype, coalesce(a.street, '') + '
' + coalesce(a.zip, '') + ' ' + coalesce(a.city, '') as adres,
a.notes as opm
from fv_activity a 
inner join fv_activitytype at
    on at.id = a.activitytype_id
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr85()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id 
from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and roenddt is null and labourstatus_id = 2 and parent_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr86()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 50, 0
from fv_engineer 
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr87()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 50
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr88()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set enddt = getdate(), roenddt = convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 0 and 14 then 15
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 15 and 29 then 30
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 30 and 44 then 45
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 45 and 59 then 60
            end - datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 
    dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 120),1,16)), radiostatus_id = -1
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr90()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, activity_id, signaturecode_id, co_debrief_mat, radiostatus_id, entrydt, send_email)
select newid(), '00000000-0000-0000-0000-000000000000', 2, 0, -1, getdate(), 1
where not exists(select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr96()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id as labid
from fv_labour
where labourstatus_id = 1 and activity_id is null and engineer_id = 4 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr91()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 55, 0
from fv_engineer 
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr92()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 55
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr93()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select dateadd(mi, datediff(mi, rostartdt, roenddt), '1900-01-01 00:00:00') as duur, roenddt as eindtijd, 0 as sort, rostartdt as starttijd, datediff(mi, rostartdt, roenddt) as orgduur, labourstatus_id as splitlabstatusid
from fv_labour
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr94()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set engineer_notes = ''
where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr95()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set is_modified = 1, radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and is_modified = 0 and engineer_id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr97()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select engineer_notes as opm from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr98()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', fv_engineer.id, getdate(), 60, 0
from fv_engineer 
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr99()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 60
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr169()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(id) as id
from fv_labour 
where '08/08/2012 11:33:00' = rostartdt
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr170()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(id) as id
from fv_labour 
where '08/08/2012 11:33:00' = roenddt
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr171()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datediff(mi, rostartdt, '08/08/2012 11:33:00') as duursplit
from fv_labour 
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr172()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datediff(dd, rostartdt, roenddt) as dagovergang
from fv_labour
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement89Component236()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_labour.id, 
    convert(nvarchar, rostartdt, 105) as datum,
    substring(convert(nvarchar, rostartdt, 108),1,5) as van, 
    substring(convert(nvarchar, roenddt, 108),1,5) as tot,
    fv_labourstatus.description as type,
    substring(convert(nvarchar, dateadd(mi, datediff(mi, rostartdt, roenddt), '1900-01-01 00:00:00'), 120), 12, 5) as duur
from fv_labour
inner join fv_labourstatus
    on fv_labourstatus.id = fv_labour.labourstatus_id
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' 
    and is_modified = 0
order by rostartdt, roenddt

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement90()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement91()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement92()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*7*/ update fv_labour set roenddt = dateadd(mi, datediff(mi, '1900-01-01 00:00:00', '1900-01-01 '+ convert(nvarchar, '09/08/2012 14:56:00', 108)), rostartdt)
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement93()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement94()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement95()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement96()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select rostartdt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement97()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*4*/ update fv_labour set rostartdt = dateadd(mi, 45, rostartdt), roenddt = dateadd(mi, 45, roenddt)
where datediff(mi, convert(datetime, '08/08/2012 11:33:00'), rostartdt) >= 0
and activity_id = '00000000-0000-0000-0000-000000000000'
and is_modified = 0
and parent_id = '00000000-0000-0000-0000-000000000000'
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement98()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*2*/ update fv_labour set roenddt = convert(datetime, '08/08/2012 11:33:00')
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement99()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*3*/ insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
select newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), getdate(), '08/08/2012 16:44:00',
dateadd(mi, 0 - 0, convert(datetime, '08/08/2012 16:44:00')), '02/20/2012 18:55:00', 0, -1, 0, '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement100()
        {
            var statement = MacroScope.Factory.CreateStatement(@"/*5*/ insert into fv_labour (id, activity_id, engineer_id, startdt, enddt, rostartdt, roenddt, verifydt, labourstatus_id, radiostatus_id, is_modified, parent_id)
select newid(), '00000000-0000-0000-0000-000000000000', 4, dateadd(s, -10, getdate()), dateadd(s, -10, getdate()), convert(datetime, '08/08/2012 11:33:00'),
convert(datetime, '08/08/2012 16:44:00'), '02/20/2012 18:55:00', 5, -1, 0, '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement101()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement102()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where activity_id = '00000000-0000-0000-0000-000000000000'
    and verifydt = '02/20/2012 18:55:00'
    and is_modified = 0
    and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement103()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, engineer_id, labourstatus_id, startdt, rostartdt, enddt, roenddt, verifydt, is_modified, parent_id, radiostatus_id) 
select newid(), 4, 4, getdate(), last_labour_roenddt, getdate(), 
    dateadd(mi, 15, last_labour_roenddt),'02/20/2012 18:55:00', 0, '00000000-0000-0000-0000-000000000000', -1
from fv_engineer 
where id = 4
and not exists (select id from fv_labour where labourstatus_id = 4 and activity_id is null and engineer_id = 4 and parent_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement104()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select last_labour_roenddt from fv_engineer
where fv_engineer.id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement105()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select last_labour_roenddt from fv_engineer
where fv_engineer.id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement106()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where engineer_id = 4
    and verifydt = '02/20/2012 18:55:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement107()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(roenddt) 
    from fv_labour 
    where engineer_id = 4
    and verifydt = '02/20/2012 18:55:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement108()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement109()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr73()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id as labid
from fv_labour
where labourstatus_id = 1 and activity_id is null and engineer_id = 4 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr75()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_labour.id, rostartdt as starttijd, dateadd(mi, datediff(mi, rostartdt, roenddt), '1900-01-01 00:00:00') as duur, labourstatus_id
from fv_labour
inner join fv_labourstatus
    on fv_labourstatus.id = fv_labour.labourstatus_id
    and fv_labourstatus.labourstatustype_id = 1
where is_modified = 0
and activity_id is null
and verifydt = convert(datetime,'02/20/2012 18:55:00')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr76()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set is_modified = 1, radiostatus_id = 0 where verifydt = '02/20/2012 18:55:00' and is_modified = 0 and engineer_id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr150()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(paramvalue, 14) as retention
from fv_param_mobile 
where description = 'retention'
union
select 14 as retention
from fv_engineer
where id = 4
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr151()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_material
where radiostatus_id in (1,2)
and debrief_id in (select fv_debrief.id from fv_debrief
                   inner join fv_activity
                   on fv_debrief.activity_id = fv_activity.id
                   and fv_activity.activitystatustype_id in (60, 120, 150)
                   and datediff(dd, fv_activity.maxstatusdt, getdate()) > 0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr152()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_signature
where radiostatus_id in (1,2)
and debrief_id in (select fv_debrief.id from fv_debrief
                   inner join fv_activity
                   on fv_debrief.activity_id = fv_activity.id
                   and fv_activity.activitystatustype_id in (60, 120, 150)
                   and datediff(dd, fv_activity.maxstatusdt, getdate()) > 0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr153()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief
where radiostatus_id in (1,2)
and activity_id in (select id from fv_activity 
                    where activitystatustype_id in (60, 120, 150)
                    and datediff(dd, maxstatusdt, getdate()) > 0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr154()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour
where radiostatus_id in (1,2)
and 
    (activity_id in (select id from fv_activity 
                    where activitystatustype_id in (60, 120, 150)
                    and datediff(dd, maxstatusdt, getdate()) > 0)
    )
or
    (activity_id is null
    and enddt is not null
    and datediff(dd, enddt, getdate()) > 0
    )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr155()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activitystatus 
where 
((radiostatus_id in (1,2) or (radiostatus_id is null))
    and activity_id in (select id from fv_activity 
                        where activitystatustype_id in (60, 120, 150)
                        and datediff(dd, maxstatusdt, getdate()) > 0)
)
or 
not activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr156()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_serviceorder
where id in (select serviceorder_id from fv_activity
             where activitystatustype_id in (60, 120, 150)
             and datediff(dd, maxstatusdt, getdate()) > 0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr157()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activity
where activitystatustype_id in (60, 120, 150)
and datediff(dd, maxstatusdt, getdate()) > 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement110Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_labour.id, 
    convert(nvarchar, rostartdt, 105) as datum,
    substring(convert(nvarchar, rostartdt, 108),1,5) as van, 
    substring(convert(nvarchar, roenddt, 108),1,5) as tot,
    fv_labourstatus.description as type
from fv_labour
inner join fv_labourstatus
    on fv_labourstatus.id = fv_labour.labourstatus_id
    and fv_labourstatus.labourstatustype_id = 1
where fv_labour.activity_id is null
    and verifydt = '02/20/2012 18:55:00' 
    and is_modified = 0
order by rostartdt
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement111Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_labourstatus
where labourstatustype_id = 1 and isactive = 1
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement112()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set roenddt = dateadd(mi, datediff(mi, '1900-01-01 00:00:00', '1900-01-01 ' + convert(nvarchar, convert(datetime, '09/08/2012 13:54:00'), 108)), rostartdt), labourstatus_id = 0 where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement113()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement114()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr77()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set radiostatus_id = 0 
where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr79()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement115Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_labour.id, 
    convert(nvarchar, rostartdt, 105) as datum,
    substring(convert(nvarchar, rostartdt, 108),1,5) as van, 
    substring(convert(nvarchar, roenddt, 108),1,5) as tot,
    fv_labourstatus.description as type,
    convert(nvarchar, coalesce(fv_activity.external_id, '')) + case when coalesce(fv_activity.sub_id, '0') = 0 then '' else '-' + convert(nvarchar, fv_activity.sub_id) end + case when fv_activity.eventnumber is null then '' else ' / ' + convert(nvarchar, fv_activity.eventnumber) end as fvticket,
    substring(convert(nvarchar, dateadd(mi, datediff(mi, rostartdt, roenddt), '1900-01-01 00:00:00'), 120), 12, 5) as duur,
    fv_activitytype.description as taak
from fv_labour
inner join fv_labourstatus
    on fv_labourstatus.id = fv_labour.labourstatus_id
left outer join fv_activity
    on fv_labour.activity_id = fv_activity.id
left outer join fv_activitytype
    on fv_activity.activitytype_id = fv_activitytype.id
where datediff(dd, fv_labour.verifydt, '02/20/2012 18:55:00') <= 14 and fv_labour.engineer_id = 4
order by rostartdt, roenddt
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr163()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntstat50 from fv_activitystatus");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr164()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntlabtravel from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000'
and labourstatus_id = 3
and enddt is null
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr165()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as cntlabwork from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000'
and labourstatus_id = 2
and enddt is null
and engineer_id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr166()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id as labid
from fv_labour
where labourstatus_id = 1 and activity_id is null and engineer_id = 4 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr167()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, activity_id, signaturecode_id, co_debrief_mat, radiostatus_id, entrydt, send_email)
select newid(), '00000000-0000-0000-0000-000000000000', 2, 0, -1, getdate(), 1
where not exists(select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr168()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select at.description as actype, coalesce(a.street, '') + '
' + coalesce(a.zip, '') + ' ' + coalesce(a.city, '') as adres,
a.notes as opm
from fv_activity a 
inner join fv_activitytype at
    on at.id = a.activitytype_id
where a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement116()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement117()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select roenddt from fv_labour where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr173()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, activity_id, engineer_id, labourstatus_id, startdt, rostartdt, verifydt, is_modified, parent_id, radiostatus_id) select newid(), '00000000-0000-0000-0000-000000000000', 4, 4, getdate(), last_labour_roenddt, '02/20/2012 18:55:00', 0, '00000000-0000-0000-0000-000000000000', -1
from fv_engineer 
where id = 4
and not exists (select id from fv_labour where labourstatus_id = 4 and activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and enddt is null and parent_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr174()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set enddt = getdate(), roenddt = convert(datetime, substring(convert(nvarchar, dateadd(mi, case 
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 0 and 14 then 15
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 15 and 29 then 30
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 30 and 44 then 45
                when (datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt))) between 45 and 59 then 60
            end - datepart(mi, dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 
    dateadd(mi, datediff(mi, startdt, getdate()), rostartdt)), 120),1,16)), radiostatus_id = -1, labourstatus_id = 0
where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr175()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id 
from fv_labour
where activity_id = '00000000-0000-0000-0000-000000000000' and engineer_id = 4 and roenddt is null and labourstatus_id = 4 and parent_id = '00000000-0000-0000-0000-000000000000'

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr176()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select at.description as actypeit,
coalesce(a.street, '') + '
' + coalesce(a.zip, '') + ' ' + coalesce(a.city, '') as adresit,
coalesce(ls.id, 3) as reistypeit,
a.notes as opmit
from fv_activity a
inner join fv_activitytype at
    on at.id = a.activitytype_id
cross join (select max(l.startdt) as maxstartdt from fv_labour l where l.activity_id = '00000000-0000-0000-0000-000000000000' and l.engineer_id = 4 and l.enddt is null and is_modified = 0) l
left outer join fv_labour lab
    on lab.activity_id = a.id
    and lab.engineer_id = 4
    and lab.startdt = l.maxstartdt
inner join fv_labourstatus ls
    on ls.id = lab.labourstatus_id
where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement118Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_labourstatus
where labourstatustype_id = 1 and isactive = 1
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr179()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    1 as def_filter
from fv_engineer
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement119Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_locationtypemutation order by id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement120Component456()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select mm.id as m_id,
        convert(nvarchar, mm.mutationdt, 105) + ' '
        + substring(convert(nvarchar, mm.mutationdt, 108), 1, 5) as m_mutationdt,
        mm.material_description + ' ' + mm.material_external_id as m_artnum,
        mm.material_description as m_desc,
        convert(nvarchar, mm.quantity) as m_quantity
 from   fv_materialmutation mm
 where  mm.activity_id = '00000000-0000-0000-0000-000000000000'
        and mm.locationtypemutation_id = case when '0' = ''
                                                   or '0' = 'null'
                                              then 1
                                              else '0'
                                         end
 order by mm.mutationdt, m_artnum, m_desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr180()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    mat.description as mat_descr, 
    mat.external_id as mat_extid, 
    mm.quantity as quantity,
    coalesce(mm.locationtypemutation_id, 1) as deftype,
    coalesce(mm.materialmutationpriority_id, -1) as matprio,
    coalesce(mm.materialmutationreason_id, -1) as returnreason,
    coalesce(mm.location_external_id, '') as depot,
    coalesce(mm.label, '') as label,
    coalesce(mm.serialnumber_old, '') as sernumold,
    coalesce(mm.serialnumber_new, '') as sernumnew,
    0 as sort
from fv_materialmutation mm
inner join fv_material mat
    on mat.id = mm.material_id
    and mm.id = case when '00000000-0000-0000-0000-000000000000' = '' then '00000000-0000-0000-0000-000000000000' else '00000000-0000-0000-0000-000000000000' end
union
select    mm.material_description as mat_descr, 
    mm.material_external_id as mat_extid, 
    mm.quantity as quantity,
    coalesce(mm.locationtypemutation_id, 1) as deftype,
    coalesce(mm.materialmutationpriority_id, -1) as matprio,
    coalesce(mm.materialmutationreason_id, -1) as returnreason,
    coalesce(mm.location_external_id, '') as depot,
    coalesce(mm.label, '') as label,
    coalesce(mm.serialnumber_old, '') as sernumold,
    coalesce(mm.serialnumber_new, '') as sernumnew,
    1 as sort
from fv_materialmutation mm
where mm.id = case when '00000000-0000-0000-0000-000000000000' = '' then '00000000-0000-0000-0000-000000000000' else '00000000-0000-0000-0000-000000000000' end
union
select    '' as mat_descr, 
    '' as mat_extid, 
    1 as quantity,
    1 as deftype,
    -1 as matprio,
    -1 as returnreason,
    '' as depot,
    '' as label,
    '' as sernumold,
    '' as sernumnew,
    2 as sort
from fv_engineer
where id = '4'
order by sort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement121Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_locationtypemutation order by id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement122Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialmutationpriority order by id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement123Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialmutationreason order by id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement124()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation
           (id
           ,external_id
           ,activity_id
           ,engineer_id
           ,serviceorder_id
           ,mutationdt
           ,quantity
           ,material_id
       ,locationtypemutation_id
           ,materialmutationreason_id
           ,radiostatus_id
           ,material_external_id
           ,material_description
           ,label
           ,serialnumber_old
           ,serialnumber_new
           ,location_external_id
           ,materialmutationpriority_id)
     select newid()
           ,'0'
           ,'00000000-0000-0000-0000-000000000000'
           ,'4'
           ,act.serviceorder_id
           ,getdate()
           ,replace('0', ',', '.')
           ,case when '0' = '' then null else '0' end
       ,case when '0' = '' then null else '0' end
           ,case when '0' = '' then null else '0' end
           ,-1
           ,'0'
           ,''
           ,'0'
           ,'0'
           ,'0'
           ,'0'
           ,case when '0' = '' then null else '0' end
           from 
           fv_activity act 
            where
            id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement125()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set 
           mutationdt = getdate()
           ,quantity = replace('0', ',', '.')
       ,material_id = case when '0' = '' then null else '00000000-0000-0000-0000-000000000000' end
       ,locationtypemutation_id = case when '0' = '' then null else '0' end
           ,materialmutationreason_id = case when '0' = '' then null else '0' end
           ,radiostatus_id = -1
           ,material_external_id  = '0'
           ,material_description = ''
           ,label = '0'
           ,serialnumber_old = '0'
           ,serialnumber_new = '0'
           ,location_external_id = '0'
           ,materialmutationpriority_id = case when '0' = '' then null else '0' end
           where
       id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatement126Component481()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description, notes from fv_material where isactive = 1
and coalesce(external_id, '') like '%' + '0' + '%'
and coalesce(description, '') like '%' + '0' + '%'
and coalesce(notes, '') like '%' + '' + '%'
and '0' = '1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
             Console.WriteLine(stringifier.ToSql());
        }
    }
}
