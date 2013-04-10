using MacroScope;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class Worksphere
    {
        [TestMethod]
        public void TestSelectStatement1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as isfunctiehersteld from fv_debrief_status
where activity_id in ( select a.id from fv_activity a
inner join fv_activity b on
a.external_id = b.external_id
and a.sub_id = b.sub_id
where b.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement2()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select   planner_id
  from    fv_activity
  where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement3()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as isfunctiehersteld from fv_debrief_status
where activity_id in ( select a.id from fv_activity a
inner join fv_activity b on
a.external_id = b.external_id
and a.sub_id = b.sub_id
where b.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr490()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    getdate() as nu,
    fv_activity.id
from    fv_activity
where    fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr698()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(ontvangst_autorisatie, 0) as ontvangst_autorisatie
from    fv_engineer
where    id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr354()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_customer_main.external_id,
    fv_activity.name,
    fv_activity.name_2,
    coalesce(fv_activity.street, '') + '
' + coalesce(fv_activity.zip, '') + ' ' +  coalesce(fv_activity.city, '') + '
' + case when fv_activity.fax is null then ''
        else 'fax: '
    end + coalesce(fv_activity.fax,'') as overig,
    coalesce(fv_activity.contactpersoon, '') + coalesce(' ' + fv_activity.contactpersoon_phone, '') as contact,
    fv_customer.external_id as functieplaatscode,
    fv_customer.customername as functieplaatsnaam,
    coalesce(fv_customer.street, '') + '
' + coalesce(fv_customer.zip, '') + ' ' + coalesce(fv_customer.city, '') as functieplaatsadres
from    fv_activity
    left outer join fv_customer_main
        on fv_activity.customer_main_id = fv_customer_main.id
    left outer join fv_customer
        on fv_activity.customer_id = fv_customer.id
where    fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr355()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_customer.external_id, fv_customer.notes, fv_customer.street + ' ' + fv_customer.zip + ' ' + fv_customer.city as overig, 
                      fv_customer.verantwoordelijk
from         fv_customer
where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement4Component2170()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_history.id, fv_history.historydt, fv_history.description
from         fv_history inner join fv_activity on fv_activity.id = fv_history.activity_id
where fv_activity.id = convert(uniqueidentifier,'00000000-0000-0000-0000-000000000000') and fv_history.serviceobject_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr359()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_activity.aangemaakt_door_naam, fv_activity.herpland_door_naam, fv_activity.verantwoordelijk, fv_activity.planner_name, fv_region.description as vestiging, fv_activity.melder, 
                      fv_activity.melder_phone, fv_activity.melddatum, fv_priority.description as priority, fv_activity.meldkamernummer, fv_productgroep.description as productgroep, fv_ordersoort.description as ordersoort
from         fv_activity left outer join
                      fv_priority on fv_activity.priority_id = fv_priority.id left outer join
                      fv_region on fv_activity.region_id = fv_region.id left outer join
                      fv_productgroep on fv_activity.productgroep_id = fv_productgroep.id left outer join fv_ordersoort on fv_activity.ordersoort_id = fv_ordersoort.id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr360()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select taken, normtijd from fv_activity  where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr356()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_history where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr358()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_serviceobject.external_id, fv_serviceobject.description, fv_customer.external_id as functieplaats, fv_serviceobject.notes, fv_activity.customer_id
from    fv_activity
    left outer join fv_customer on fv_activity.customer_id = fv_customer.id
    left outer join fv_serviceobject on fv_activity.serviceobject_id = fv_serviceobject.id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement5Component2179()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_history.id, fv_history.historydt, fv_history.description
from         fv_history inner join fv_activity on fv_activity.id = fv_history.activity_id
where fv_activity.id = '00000000-0000-0000-0000-000000000000' and not fv_history.serviceobject_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr395()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     verholpen, coalesce(verholpendt,getdate()) as verholpendt, vervolgactie, vervolgactie_id, vervolgnotes, startdt
from         fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr396()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set verholpen=0, verholpendt='29-8-2012 21:55:00', startdt='0', vervolgactie=0 where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement6()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case activitytype_id when 1 then 1 when 2 then 1 else 0 end from fv_activity where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement7()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_activity.isnlsfbcodeverplicht,0) isnlsfbcodeverplicht from fv_activity where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement8()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_debrief.scannr,0) from fv_activity
        inner join fv_debrief on fv_debrief.activity_id = fv_activity.id where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement9()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select activitytype_id from fv_activity where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement10()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select activitytype_id from fv_activity where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement11()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(isafmeldbonvoorklantverplicht, 0)+coalesce(ishandtekeningverplicht, 0) as beidenietverplicht
from    fv_activity
where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr397()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debriefoperations (id,activity_id,operations_id,radiostatus_id,done) select newid(),'00000000-0000-0000-0000-000000000000',id,-1,0 from fv_operations where id not in (select operations_id from fv_debriefoperations where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr630()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set causecode_id = case when '0' = '' then null else 0+0 end,
nlsfb_id = case when '0' = '' then null else 0+0 end, vervolgactie=0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr631()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(d.causecode_id,a.causecode_id) as causecode_id, coalesce(d.nlsfb_id,a.nlsfb_id) as nlsfb_id, vervolgactie from fv_activity a inner join fv_debrief d
on activity_id = a.id
where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement12()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debriefoperations set done = case when done = 0 then 1 else 0 end where activity_id = '00000000-0000-0000-0000-000000000000' and operations_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement13Component2206()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select o.id, o.description, case when dop.done=1 then 'v' else '' end as done, '' as empty from fv_operations o left outer join fv_debriefoperations dop on o.id = dop.operations_id and dop.activity_id = '00000000-0000-0000-0000-000000000000' and o.isactive = 1 order by o.orderby");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement14Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id + ' ' + description
from fv_nlsfb
where isactive = 1
order by external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement15Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_causecode where isactive = 1
order by external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement16()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  case when len(convert(nvarchar(5), signature)) > 3 then 1
             else case when coalesce(fv_activity.ishandtekeningverplicht, 0) != 1
                       then 1
                       else coalesce(fv_paraafstatus.canescape, 0)
                  end
        end as isproceedbuttonenabled
from    fv_debrief
        inner join fv_activity on fv_debrief.activity_id = fv_activity.id
    left outer join fv_paraafstatus on fv_paraafstatus.id = 0+0
where   fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement17()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  case when opdrachtnummer is null then 1
             else 0
        end as isopdrachtnummerleeg
from    fv_activity
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement18()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(isafmeldbonvoorklantverplicht, 0) as isafmeldbonvoorklantverplicht
from    fv_activity
where   fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr410()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select name_signature from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr411()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(signaturedt,getdate()) as nu, signature, 1 as def, opdrachtnummer from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr412()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief
set    opdrachtnummer = '$form.txtopdrachtnr$',
    name_signature = '$form.txtname$',
    signaturedt = case when '0' = 'p' then null else '$flow.signaturedt$' end,
    paraafstatus_id = '0'
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr724()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 54, 0
from fv_engineer
where id = 0""");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement19Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_paraafstatus where isactive = 1 order by id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement20()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set name_signature= '$form.txtname$', signaturedt= '$flow.signaturedt$',paraafstatus_id='0' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement21()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail  where labour_id in (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and enddt is null and labourstatus_id=2)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr398()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_labour.id, rostartdt, coalesce(roenddt, getdate()) as nu, datepart(hh, case when ld.uren is null then '1900-01-01t' + case when len(convert(nvarchar, (case when datediff(mi, rostartdt, coalesce(roenddt, getdate())) < 0 then 0 else (datediff(mi, rostartdt, coalesce(roenddt, getdate())) + case when datediff(mi, rostartdt, coalesce(roenddt, getdate())) % 15 > 0 then 15 else 0 end) / 60 end))) = 1 then '0' else '' end + convert(nvarchar, (case when datediff(mi, rostartdt, coalesce(roenddt, getdate())) < 0 then 0 else (datediff(mi, rostartdt, coalesce(roenddt, getdate())) + case when datediff(mi, rostartdt, coalesce(roenddt, getdate())) % 15 > 0 then 15 else 0 end) / 60 end)) + ':' + case when (datediff(mi, rostartdt, coalesce(roenddt, getdate())) - (datediff(mi, rostartdt, coalesce(roenddt, getdate())) / 60) * 60) < 10 then '00' when (datediff(mi, rostartdt, coalesce(roenddt, getdate())) - (datediff(mi, rostartdt, coalesce(roenddt, getdate())) / 60) * 60) <= 15 then '15' when (datediff(mi, rostartdt, coalesce(roenddt, getdate())) - (datediff(mi, rostartdt, coalesce(roenddt, getdate())) / 60) * 60) <= 30 then '30' when (datediff(mi, rostartdt, coalesce(roenddt, getdate())) - (datediff(mi, rostartdt, coalesce(roenddt, getdate())) / 60) * 60) <= 45 then '45' else '00' end + ':00' else ld.uren end) as uren, datepart(mi, case when ld.uren is null then '1900-01-01t' + case when len(convert(nvarchar, (case when datediff(mi, rostartdt, coalesce(roenddt, getdate())) < 0 then 0 else (datediff(mi, rostartdt, coalesce(roenddt, getdate())) + case when datediff(mi, rostartdt, coalesce(roenddt, getdate())) % 15 > 0 then 15 else 0 end) / 60 end))) = 1 then '0' else '' end + convert(nvarchar, (case when datediff(mi, rostartdt, coalesce(roenddt, getdate())) < 0 then 0 else (datediff(mi, rostartdt, coalesce(roenddt, getdate())) + case when datediff(mi, rostartdt, coalesce(roenddt, getdate())) % 15 > 0 then 15 else 0 end) / 60 end)) + ':' + case when (datediff(mi, rostartdt, coalesce(roenddt, getdate())) - (datediff(mi, rostartdt, coalesce(roenddt, getdate())) / 60) * 60) < 10 then '00' when (datediff(mi, rostartdt, coalesce(roenddt, getdate())) - (datediff(mi, rostartdt, coalesce(roenddt, getdate())) / 60) * 60) <= 15 then '15' when (datediff(mi, rostartdt, coalesce(roenddt, getdate())) - (datediff(mi, rostartdt, coalesce(roenddt, getdate())) / 60) * 60) <= 30 then '30' when (datediff(mi, rostartdt, coalesce(roenddt, getdate())) - (datediff(mi, rostartdt, coalesce(roenddt, getdate())) / 60) * 60) <= 45 then '45' else '00' end + ':00' else ld.uren end) as minuten from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id = 1 where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and enddt is null and labourstatus_id = 2 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr400()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ld.labour_type_id as id from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and enddt is null and labourstatus_id=2
union
(select id from fv_labour_type where external_id = '0708' and not exists (select uren from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and enddt is null and labourstatus_id=2))
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr404()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$form.txtlabid$', '00000000-0000-0000-0000-000000000000', 1, -1, dateadd(mi, 0, dateadd(hh, 0, substring(convert(nvarchar, getdate(), 20), 1, 10) + 't00:00:00'))
from fv_engineer
where id = 0
    and '0' + ':' + '0' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr405()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren)
select newid(), '$form.txtlabid$', '00000000-0000-0000-0000-000000000000', 10, -1, dateadd(mi, 0, dateadd(hh, 0, substring(convert(nvarchar, getdate(), 20), 1, 10) + 't00:00:00'))
from fv_engineer
where id = 0
    and '0' + ':' + '0' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr406()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$form.txtlabid$', '00000000-0000-0000-0000-000000000000', id, -1, dateadd(mi, 0, dateadd(hh, 0, substring(convert(nvarchar, getdate(), 20), 1, 10) + 't00:00:00'))
from fv_labour_type
where id = 0
    and '0' + ':' + '0' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr546()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id,rostartdt,coalesce(roenddt,getdate()) as nu from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and enddt is null and labourstatus_id=2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr547()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    case when len(convert(nvarchar, sum(datepart(hh, uren)) + ( sum(datepart(mi, uren)) / 60 ))) = 1 then '0' else '' end
        + convert(nvarchar, sum(datepart(hh, uren)) + ( sum(datepart(mi, uren)) / 60 )) + ':'
        + case when len(convert(nvarchar, ( sum(datepart(mi, uren)) % 60 ))) = 1 then '0' else '' end
        + convert(nvarchar, ( sum(datepart(mi, uren)) % 60 ))
    as total
from fv_labour_detail
    inner join fv_labour
        on fv_labour_detail.labour_id = fv_labour.id
where    fv_labour.activity_id in (select a.id from fv_activity a inner join fv_activity b on a.serviceorder_id = b.serviceorder_id where b.id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr549()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    datepart(hh, case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as uren,
    datepart(mi, case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as minuten
from fv_labour
    left outer join fv_labour_detail ld
        on ld.labour_id = fv_labour.id
            and ld.labour_type_id = 10
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000'
    and enddt is null
    and labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr550()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    datepart(hh, case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as uren,
    datepart(mi, case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as minuten,
    ld.labour_type_id
from fv_labour
    left outer join fv_labour_detail ld
        on ld.labour_id = fv_labour.id
            and not ld.labour_type_id in (1, 2, 3, 10)
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000'
    and fv_labour.enddt is null
    and fv_labour.labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr703()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$form.txtlabid$', '00000000-0000-0000-0000-000000000000', 2, -1, dateadd(mi, 0, dateadd(hh, 0, substring(convert(nvarchar, getdate(), 20), 1, 10) + 't00:00:00'))
from fv_engineer
where id = 0
    and '0' + ':' + '0' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr704()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$form.txtlabid$', '00000000-0000-0000-0000-000000000000', 3, -1, dateadd(mi, 0, dateadd(hh, 0, substring(convert(nvarchar, getdate(), 20), 1, 10) + 't00:00:00'))
from fv_engineer
where id = 0
    and '0' + ':' + '0' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr705()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    datepart(hh, case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as uren,
    datepart(mi, case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as minuten
from fv_labour
    left outer join fv_labour_detail ld
        on ld.labour_id = fv_labour.id
            and ld.labour_type_id = 2
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000'
    and enddt is null
    and labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr706()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    datepart(hh, case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as uren,
    datepart(mi, case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as minuten
from fv_labour
    left outer join fv_labour_detail ld
        on ld.labour_id = fv_labour.id
            and ld.labour_type_id = 3
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000'
    and enddt is null
    and labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement22Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description
from fv_labour_type
where isactive = 1
    and not id in (1, 2, 3, 10)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr407()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))+(sum(datepart(mi, fv_labour_detail.uren))/60))) = 1 then '0' else '' end +  convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))+(sum(datepart(mi, fv_labour_detail.uren))/60)) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60))) = 1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60)),'00:00') as normaal
from         fv_labour_detail right outer join
                      fv_labour on fv_labour_detail.labour_id = fv_labour.id and fv_labour_detail.labour_type_id = 1
where     fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and not fv_labour.enddt is null and fv_labour.engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr408()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))+(sum(datepart(mi, fv_labour_detail.uren))/60))) = 1 then '0' else '' end +  convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))+(sum(datepart(mi, fv_labour_detail.uren))/60)) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60))) = 1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60)),'00:00') as normaal
from         fv_labour_detail right outer join
                      fv_labour on fv_labour_detail.labour_id = fv_labour.id and fv_labour_detail.labour_type_id = 2
where    fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and not fv_labour.enddt is null and fv_labour.engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr409()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))+(sum(datepart(mi, fv_labour_detail.uren))/60))) = 1 then '0' else '' end +  convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))+(sum(datepart(mi, fv_labour_detail.uren))/60)) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60))) = 1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60)),'00:00') as normaal
from         fv_labour_detail right outer join
                      fv_labour on fv_labour_detail.labour_id = fv_labour.id and fv_labour_detail.labour_type_id not in (1,2)
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and not fv_labour.enddt is null and fv_labour.engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement23Component2284()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_labour.id, convert(nvarchar,fv_labour.rostartdt,105) + ' ' + case when len(convert(nvarchar,datepart(hh,fv_labour.rostartdt)) )=1 then '0' else '' end + convert(nvarchar,datepart(hh,fv_labour.rostartdt)) + ':' + case when len(convert(nvarchar,datepart(mi,fv_labour.rostartdt)) )=1 then '0' else '' end + convert(nvarchar,datepart(mi,fv_labour.rostartdt)) as van_tot, case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))))=1 then '0' else '' end + convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))))=1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))) as normaal, case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail_1.uren))))=1 then '0' else '' end + convert(nvarchar, sum(datepart(hh, fv_labour_detail_1.uren))) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail_1.uren))))=1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail_1.uren))) as reis, case when len(convert(nvarchar, (sum(datepart(hh, fv_labour_detail_2.uren)) + sum(datepart(mi, fv_labour_detail_2.uren))/60)))=1 then '0' else '' end + convert(nvarchar, (sum(datepart(hh, fv_labour_detail_2.uren)) + sum(datepart(mi, fv_labour_detail_2.uren))/60)) + ':' + case when len(convert(nvarchar, (sum(datepart(mi,fv_labour_detail_2.uren))%60)))=1 then '0' else '' end + convert(nvarchar, sum(datepart(mi,fv_labour_detail_2.uren))%60) as ovr,
1 as canchange
from fv_labour left outer join fv_labour_detail on fv_labour.id = fv_labour_detail.labour_id and fv_labour_detail.labour_type_id = 1 left outer join fv_labour_detail fv_labour_detail_1 on fv_labour.id = fv_labour_detail_1.labour_id and fv_labour_detail_1.labour_type_id = 2 left outer join fv_labour_detail fv_labour_detail_2 on fv_labour.id = fv_labour_detail_2.labour_id and fv_labour_detail_2.labour_type_id not in (1,2)
where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and not fv_labour.enddt is null and fv_labour.engineer_id = 0
group by fv_labour.id, fv_labour.rostartdt, fv_labour.roenddt
union
select     fv_labour.id, convert(nvarchar,fv_labour.rostartdt,105) + ' ' + case when len(convert(nvarchar,datepart(hh,fv_labour.rostartdt)) )=1 then '0' else '' end + convert(nvarchar,datepart(hh,fv_labour.rostartdt)) + ':' + case when len(convert(nvarchar,datepart(mi,fv_labour.rostartdt)) )=1 then '0' else '' end + convert(nvarchar,datepart(mi,fv_labour.rostartdt)) as van_tot, case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))))=1 then '0' else '' end + convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren))) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))))=1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))) as normaal, case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail_1.uren))))=1 then '0' else '' end + convert(nvarchar, sum(datepart(hh, fv_labour_detail_1.uren))) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail_1.uren))))=1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail_1.uren))) as reis, case when len(convert(nvarchar, (sum(datepart(hh, fv_labour_detail_2.uren)) + sum(datepart(mi, fv_labour_detail_2.uren))/60)))=1 then '0' else '' end + convert(nvarchar, (sum(datepart(hh, fv_labour_detail_2.uren)) + sum(datepart(mi, fv_labour_detail_2.uren))/60)) + ':' + case when len(convert(nvarchar, (sum(datepart(mi,fv_labour_detail_2.uren))%60)))=1 then '0' else '' end + convert(nvarchar, sum(datepart(mi,fv_labour_detail_2.uren))%60) as ovr,
0 as canchange
from fv_labour left outer join fv_labour_detail on fv_labour.id = fv_labour_detail.labour_id and fv_labour_detail.labour_type_id = 1 left outer join fv_labour_detail fv_labour_detail_1 on fv_labour.id = fv_labour_detail_1.labour_id and fv_labour_detail_1.labour_type_id = 2 left outer join fv_labour_detail fv_labour_detail_2 on fv_labour.id = fv_labour_detail_2.labour_id and fv_labour_detail_2.labour_type_id not in (1,2)
where fv_labour.activity_id in (select a.id from fv_activity a inner join fv_activity b on a.serviceorder_id = b.serviceorder_id where b.id = '00000000-0000-0000-0000-000000000000') and fv_labour.enddt is null and fv_labour.engineer_id = 0
group by fv_labour.id, fv_labour.rostartdt, fv_labour.roenddt

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement24()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, startdt, rostartdt, enddt, roenddt, radiostatus_id, activity_id, labourstatus_id, engineer_id) select  '$flow.lab$', getdate(), getdate() , getdate(), getdate() ,  3, '00000000-0000-0000-0000-000000000000', 2, 0 from fv_engineer where fv_engineer.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement25()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail where labour_id = '$sub.grduren.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement26()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour where id = '$sub.grduren.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr437()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select getdate() as nu, id, 0 as def from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement27Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_cancelreason.id, fv_cancelreason.description from fv_cancelreason where fv_cancelreason.isactive = 1 order by fv_cancelreason.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement28()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set planstartdt = '$flow.newdt$' where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement29()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set restduur=(0*60)+0 where activity_id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr436()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id,startdt,coalesce(roenddt,getdate()) as nu from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id=2 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement30()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set roenddt = '$flow.enddt$' where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id=2 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr414()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren)) + (sum(datepart(mi, fv_labour_detail.uren)) / 60))) = 1 then '0' else '' end
    +  convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren)) + (sum(datepart(mi, fv_labour_detail.uren)) / 60)) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60))) = 1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60)) as normaal
from fv_labour_detail
    inner join fv_labour_type
        on fv_labour_detail.labour_type_id = fv_labour_type.id
    inner join fv_labour
        on fv_labour_detail.labour_id = fv_labour.id
where fv_labour_type.id in (2, 10)
    and fv_labour.activity_id in
        (select a.id
            from fv_activity a
            inner join fv_activity b on a.serviceorder_id = b.serviceorder_id
            where b.id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr415()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    case when len(convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren)) + (sum(datepart(mi, fv_labour_detail.uren)) / 60))) = 1 then '0' else '' end
    +  convert(nvarchar, sum(datepart(hh, fv_labour_detail.uren)) + (sum(datepart(mi, fv_labour_detail.uren)) / 60)) + ':' + case when len(convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60))) = 1 then '0' else '' end + convert(nvarchar, sum(datepart(mi, fv_labour_detail.uren))-((sum(datepart(mi, fv_labour_detail.uren))/60)*60)) as normaal
from fv_labour_detail
    inner join fv_labour_type
        on fv_labour_detail.labour_type_id = fv_labour_type.id
    inner join fv_labour
        on fv_labour_detail.labour_id = fv_labour.id
where not fv_labour_type.id in (2, 10)
    and fv_labour.activity_id in
        (select a.id
            from fv_activity a
            inner join fv_activity b on a.serviceorder_id = b.serviceorder_id
            where b.id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr680()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'nb: ' + o.description as omschrijving from fv_operations o inner join fv_debriefoperations do on do.operations_id = o.id where do.activity_id = '00000000-0000-0000-0000-000000000000' and o.id = 9 and do.done=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr682()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(overigekosten,'') + ' ' + coalesce(convert(nvarchar,overigekosten_bedrag),'') as overig from fv_debrief  where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement31Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"    select    fv_labour.rostartdt,
        fv_labour.roenddt,
        coalesce(e.username, m.description) as monteur,
        dateadd(mi, sum(datepart(hour, coalesce(fv_labour_detail.uren, '1900-01-01t00:00:00'))) * 60
                + sum(datepart(mi, coalesce(fv_labour_detail.uren, '1900-01-01t00:00:00'))), '1900-01-01t00:00:00') as tijd,
        case when fv_labour_detail.labour_type_id in (2, 10 ) then 'reis' else 'werk' end as type
    from    fv_labour
        left outer join fv_labour_detail
            on fv_labour_detail.labour_id = fv_labour.id
--                and fv_labour_detail.labour_type_id in (2, 10 )
        left outer join fv_engineer e
            on fv_labour.engineer_id = e.id
        left outer join fv_medewerker m
            on fv_labour.medewerker_id = m.id
    where    fv_labour.activity_id in (select  a.id from fv_activity a inner join fv_activity b on a.serviceorder_id = b.serviceorder_id where b.id = '00000000-0000-0000-0000-000000000000' )
    group by fv_labour.rostartdt,
            fv_labour.roenddt,
            e.username,
            m.description,
            case when fv_labour_detail.labour_type_id in (2, 10 ) then 'reis' else 'werk' end
    having  sum(datepart(hour, coalesce(fv_labour_detail.uren, '1900-01-01t00:00:00'))) * 60 + sum(datepart(mi, coalesce(fv_labour_detail.uren, '1900-01-01t00:00:00'))) <> 0
--union
--    select    fv_labour.rostartdt,
--        fv_labour.roenddt,
--        coalesce(e.username, m.description) as monteur,
--        dateadd(mi, sum(datepart(hour, coalesce(fv_labour_detail.uren, '1900-01-01t00:00:00'))) * 60
--            + sum(datepart(mi, coalesce(fv_labour_detail.uren, '1900-01-01t00:00:00'))), '1900-01-01t00:00:00') as tijd,
--        'werk' as type
--    from    fv_labour
--        left outer join fv_labour_detail
--            on fv_labour_detail.labour_id = fv_labour.id
--                and fv_labour_detail.labour_type_id not in (2, 10 )
--        left outer join fv_engineer e
--            on fv_labour.engineer_id = e.id
--        left outer join fv_medewerker m
--            on fv_labour.medewerker_id = m.id
--    where    fv_labour.activity_id in (select a.id from fv_activity a inner join fv_activity b on a.serviceorder_id = b.serviceorder_id where b.id = '00000000-0000-0000-0000-000000000000')
--    group by fv_labour.rostartdt,
--        fv_labour.roenddt,
--        e.username,
--        m.description
--    having    sum(datepart(hour, coalesce(fv_labour_detail.uren, '1900-01-01t00:00:00'))) * 60 + sum(datepart(mi, coalesce(fv_labour_detail.uren, '1900-01-01t00:00:00'))) <> 0
order by rostartdt");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr370()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_serviceobject.external_id, fv_serviceobject.description, fv_customer.external_id as functieplaats, fv_customer.id,fv_serviceobject.id as eqid, 1 as sortorder
from         fv_serviceobject  left outer join
                      fv_customer on fv_serviceobject.customer_id = fv_customer.id
where fv_serviceobject.external_id like '%$flow.eqext$' and '$flow.eqext$'<>''
union
select '$flow.eqext$' as external_id,'' as description,'' as functieplaats,null as id,null as eqid, 2 as sortorder from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000' and coalesce(scannr,'')<>''
order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr473()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select problemcode_id, causecode_id, solutioncode_id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr492()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select s.external_id, s.description from fv_serviceobject s inner join fv_activity a on a.serviceobject_id = s.id where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr535()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set serviceobject_id = case when '$form.txtequipmentid$' = '' then null else '$form.txtequipmentid$' end where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr536()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set solutioncode_id= case when '0' = '' then null else 0+0 end where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr537()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set scandt=getdate(),scannr=case when '$form.txtequipment$' = '' then null else '$form.txtequipment$' end where activity_id = '00000000-0000-0000-0000-000000000000';");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement32Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_solutioncode where isactive = 1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr497()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'true' as def, customer_main_id from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement33Component3031()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_customer.id,
    fv_customer.external_id,
    fv_customer.customername as oms,
    fv_customer.customer_main_id,
    fv_customer_main.name,
    fv_customer_main.name2
from    fv_customer
    inner join fv_customer_main
        on fv_customer.customer_main_id=fv_customer_main.id
where    len(fv_customer.external_id) = case when '$sub.chmain$'='true' then 8 else len(fv_customer.external_id) end
    and fv_customer.isactive=1
    and fv_customer.external_id like '$sub.txtfp$'+'%'
    and fv_customer.customername like '%$sub.txtname$%'
    and '0'='1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement34()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    activitytype_id = 0,
--activitytype_id = case when '$form.cbtype$'='' then null else  '$form.cbtype$' end,
    capability_id = case when '0'='' then null else '0' end,
    productgroep_id = case when '0'='' then null else '0' end,
    customer_main_id = $sub.grdfp2.klant$,
    customer_id = $sub.grdfp2.id$,
    functieplaatsnaam = '$sub.grdfp2.name$',
    description = '$form.txtdescnw$',
    opdrachtnummer = '$form.txtopdrnr$',
    name='$sub.grdfp2.klantname$',
    name_2='$sub.grdfp2.klantname2$'
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr426()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_customer.external_id, fv_customer.notes, fv_customer.street + ' ' + fv_customer.zip + ' ' + fv_customer.city as overig, 
                      fv_customer.verantwoordelijk
from         fv_customer
where external_id = '$sub.txtfpcode$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement35Component2337()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, coalesce(name,'') + '/' + coalesce(name2,'') + '/' + coalesce(city,'') as oms,name,name2 from fv_customer_main where city like '$sub.txtcity$' + '%' and name like '%' + '$sub.txtname$' + '%' and 0=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement36()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitytype_id=0 end where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement37()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set capability_id= case when '0' = '' then null else '0' end, productgroep_id=case when '0' = '' then null else '0' end, functieplaatsnaam=case when coalesce(customer_id,0)=0 then '$form.txtfpnb$' else functieplaatsnaam end where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement38()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set customer_main_id = $sub.grdklant.id$, name='$sub.grdklant.name$', name_2='$sub.grdklant.name2$', description = '$form.txtdescnw$', opdrachtnummer = '$form.txtopdrnr$'  where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement39()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set     activitytype_id = 0,    
--activitytype_id = $form.cbtype$,
    description = replace('$form.txtdescnw$', '
', ' '),
    opdrachtnummer = '$form.txtopdrnr$',
    capability_id = 0,
    ordersoort_id = 0
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr432()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_ordersoort where external_id = 'zz01'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr433()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_activity
set    activitytype_id = 0,
--activitytype_id = $form.cbtype$,
    description = replace('$form.txtdescnw$', '
', ' '),
    opdrachtnummer = '$form.txtopdrnr$',
    capability_id = 0,
    productgroep_id = 0,
    ordersoort_id = 0,
    functieplaatsnaam = case when coalesce(customer_id,0)=0 then '$form.txtfpnb$' else functieplaatsnaam end,
    samenvatting = '$form.txtsamenv$'
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr467()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(fv_activity.activitytype_id, 'null') as activitytype_id,
    fv_activity.description,
    fv_activity.opdrachtnummer,
    coalesce(fv_activity.capability_id, 'null') as capability_id,
    fv_activity.sub_id,
    fv_activity.serviceordernumber,
    coalesce(fv_activity.productgroep_id, 2) as productgroep_id,
    fv_activity.equipmentname,
    fv_activity.functieplaatsnaam,
    fv_activity.contactpersoon,
    fv_customer_main.name
from    fv_activity
    left outer join fv_customer_main on fv_activity.customer_main_id = fv_customer_main.id
where    fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr654()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
coalesce(fv_activity.ministoringsboek, case when fv_activity.ordersoort_id = 1 then upper(coalesce(at.description, '')) + '
' + 'melding: ' + coalesce(substring(convert(nvarchar, fv_activity.melddatum, 13), 1, 11),'')  + ' ' + coalesce(fv_activity.melder, '') + ' ' + coalesce(fv_activity.melder_phone, '') + '
' + 'prioriteit: ' + coalesce(fv_priority.description, '') else 'plandatum: ' + coalesce(substring(convert(nvarchar, fv_activity.planstartdt, 13), 1, 11),'') + '
' end + '
---------------------------------------------------
' + coalesce(fv_activity.name, '') + case when fv_activity.name_2 is null then '' else '
' + coalesce(fv_activity.name_2, '')  end + '
' + coalesce(fv_customer.external_id, '') + ' ' + coalesce(fv_activity.functieplaatsnaam, '') + '
---------------------------------------------------
' + case when fv_activity.equipmentname is null then '' else coalesce(fv_activity.equipmentname, '') + '
' end + coalesce(fv_activity.description, '') + '
' + coalesce(fv_activity.notes, '') + '
---------------------------------------------------
' + 'opdrachtnummer: ' + coalesce(fv_activity.opdrachtnummer, ''))  as orderbeschrijving
from    fv_activity
    left outer join fv_priority
        on fv_activity.priority_id = fv_priority.id
    left outer join fv_activitytype at
        on fv_activity.activitytype_id = at.id
    left outer join fv_customer
        on fv_customer.id = fv_activity.customer_id
where    fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement40Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_capability where isactive = 1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement41Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_productgroep where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement42Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description
from fv_activitytype
where external_id in ('10', '20')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement43()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set opdrachtnummer='$form.txtopdrachtnr$', name_signature = '$sub.grdcontact2.name$', email='$sub.grdcontact2.email$', signaturedt= substring('$form.datsig$',1,11) + substring('$form.timesig$',12,8), paraafstatus_id='0' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement44()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set opdrachtnummer = '$form.txtopdrachtnr$', name_signature = '$sub.grdcontact2.name$', email = '$form.txtemail$' + case when len('$form.txtemail$')>0 then ';' else '' end + '$sub.grdcontact2.email$', signaturedt = substring('$form.datsig$',1,11) + substring('$form.timesig$',12,8), send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement45Component2402()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_contact.contactsurname, fv_contact.phone, fv_contact.email
from         fv_customer_main inner join
                      fv_activity on fv_customer_main.id = fv_activity.customer_main_id inner join
                      fv_contact on fv_customer_main.id = fv_contact.customer_main_id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'
order by fv_contact.contactsurname");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr373()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select c.external_id from fv_customer c inner join fv_activity a on a.customer_id = c.id where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement46Component2417()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    s.id,
    substring(s.external_id, 9, 10) as short_ext,
    s.description,
    s.external_id
from    fv_serviceobject s
    inner join fv_customer c
        on c.id = s.customer_id
    inner join fv_customer cp
        on cp.id = c.parent_customer_id
where    c.external_id like '$sub.txtfp$' + '%'
    and s.external_id like '%' + '$sub.txteqnr$'
    and s.description like '%$sub.txtdesc$%'
    and '0' = '1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement47()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set serviceobject_id = $sub.grdeq.id$ where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr372()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_serviceobject.external_id, fv_serviceobject.description, fv_customer.external_id as functieplaats, fv_serviceobject.notes,fv_customer.id
from fv_serviceobject left outer join fv_customer on fv_serviceobject.customer_id = fv_customer.id
where fv_serviceobject.external_id = '$sub.txtequipnr$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr494()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr495()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select at.external_id as typewerk,
cm.external_id as kunnr,
a.contact as contactpersoonid,
case when coalesce(a.customer_id,0)=0 then a.functieplaatsnaam else fp.external_id end as functieplaatsid,
coalesce(eq.external_id,'') as equipmentid,
coalesce(a.description,'') as omschrijving,
coalesce(a.opdrachtnummer,'') as opdrachtnummer,
pc.external_id as productcombi  from fv_activity a inner join fv_activitytype at on at.id = a.activitytype_id left outer join fv_customer_main cm on a.customer_main_id = cm.id left outer join fv_customer fp on a.customer_id = fp.id  left outer join fv_serviceobject eq on a.serviceobject_id = eq.id  left outer join fv_capability pc on a.capability_id = pc.id where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr525()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set sub_id = 0, serviceordernumber='$form.txtso$' where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr693()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and activitystatustype_id = 30 and '$form.txtso$'=''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement48()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(isafmeldbonvoorklantverplicht,0) from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement49()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(isurenspecificatieverplicht,0) from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement50()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(isafmeldbonvoorklantverplicht,0) from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement51()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(isequipmentscannenverplicht,0) from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement52()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief
set email = '$form.txtemail$', send_email = case when '$form.chmail$' = 'true' then 1 else 0 end, send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end 
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr416()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_debrief.email,fv_contact.email) as email from fv_activity inner join fv_debrief on fv_activity.id = fv_debrief.activity_id left outer join fv_contact on fv_activity.contact_id = fv_contact.id where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr417()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    case when send_email = 1 then 'true' else 'false' end as mail,
    case when send_specificatie = 1 then 'true' else 'false' end as spec
from    fv_debrief
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr524()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_debrief.cc from fv_activity inner join fv_debrief on fv_activity.id = fv_debrief.activity_id where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement53Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  l1.emailto
from    fv_emaillist l1
where   l1.id in ( select   min(id)
                   from     fv_emaillist l2
                   where    l1.activity_id = l2.activity_id
                            and l1.emailto = l2.emailto )
        and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement54()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set send_email = case when '$form.chmail$' = 'true' then 1 else 0 end, send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end 
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement55()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set email = '$form.txtemail$' + case when len('$form.txtemail$')>0 then ';' else '' end + '$sub.grdemail.mail$' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement56()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update
    fv_debrief
set 
    email = '$form.txtemail$' + case when len('$form.txtemail$') > 0 then ';'
                                     else ''
                                end + '$sub.grdemail.mail$',
    name_signature = '$form.txtparaafnaam$',
    opdrachtnummer = '$form.txtopdrachtnr$',
    signaturedt = substring('$form.datsig$', 1, 11) + substring('$form.timesig$', 12, 8)    
where
    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement57Component2468()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_contact.contactsurname, fv_contact.email
from         fv_customer_main inner join
                      fv_activity on fv_customer_main.id = fv_activity.customer_main_id inner join
                      fv_contact on fv_customer_main.id = fv_contact.customer_main_id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'
and fv_contact.isactive = 1
order by fv_contact.contactsurname");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement58()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  convert(nvarchar, coalesce(min(ds.statusdt),
                                   dateadd(year, 1, getdate())), 126) as debrief_statusdt
from    fv_debrief_status ds
        inner join fv_activity a on a.external_id = ds.external_id
                                    and a.sub_id = ds.sub_id
                                    and a.activitystatustype_id not in ( 120, 125, 60, 62 )
where   ds.activitystatustype_id = 59
        and not exists ( select 0
                         from   fv_activitystatus acts
                         where  acts.activity_id = a.id
                                and acts.activitystatustype_id in ( 120, 125, 60, 62 ) )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr448()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr449()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_labour
set    radiostatus_id = 0
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr450()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debriefoperations set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and done = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr451()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 0, -5
from fv_engineer
where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr452()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_activity
set    maxstatusdt = getdate()
    ,activitystatustype_id = 0
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr453()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour_detail set radiostatus_id=0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr460()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set radiostatus_id=0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr656()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour
set    enddt = getdate(),
    roenddt = coalesce(roenddt, getdate())
where    activity_id = '00000000-0000-0000-0000-000000000000'
    and enddt is null
    and labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr666()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_activity.serviceordernumber,'') as sonr
from fv_activity 
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr722()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from   fv_debrief_status
where         exists (select * from fv_activity a where a.external_id = fv_debrief_status.external_id
                                    and a.sub_id = fv_debrief_status.sub_id
                                    and a.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr735()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_photo set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and radiostatus_id != -2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr620()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(bestel_autorisatie,0) as bestel_autorisatie, coalesce(ontvangst_autorisatie,0) as ontvangst_autorisatie from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr629()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when count(quantity)=0 then '0' else '1' end as materiaalingevoerd from fv_materialmutation where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr672()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_activity.serviceordernumber,'') as sonr
from fv_activity 
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement59Component2471()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(bestelnr,'') + '/' + coalesce(description,'') + '/' + coalesce(supplier_name,'') as omsch, quantity, type, id,'' as empty
from         fv_materialmutation
where     ((type = 'd') or(type = 'o')) and activity_id = '00000000-0000-0000-0000-000000000000'
union
select     coalesce(fv_material.bestelnr,'') + '/' + coalesce(fv_materialmutation.description,'') + '/' + coalesce(fv_supplier.description,'') as omsch, fv_materialmutation.quantity, type, fv_materialmutation.id,'' as empty
from         fv_materialmutation inner join
                      fv_material on fv_materialmutation.material_id = fv_material.id left outer join
                      fv_supplier on fv_material.supplier_id = fv_supplier.id
where     (fv_materialmutation.type = 'a') and  activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement60()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement61()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement62()
        {
            var statement = MacroScope.Factory.CreateStatement(@"drop table fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement63()
        {
            var statement = MacroScope.Factory.CreateStatement(@"create table fv_tmp_bestelling(balie int null , huisnummer nvarchar(50) null , id uniqueidentifier rowguidcol constraint pk_fv_tmp_bestelling primary key , land nvarchar(50) null , leveranciernummer nvarchar(50) null , naam nvarchar(50) null , naam2 nvarchar(50) null , onderaanneming int null , plaats nvarchar(50) null , postcode nvarchar(50) null , sonummer nvarchar(50) null , straat nvarchar(50) null , werkbon int null )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement64()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement65()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestelling (id,sonummer,werkbon,straat,naam,naam2,huisnummer,postcode,plaats,land) select '$flow.bestel_id$',serviceordernumber,sub_id,street,name,name_2,housenumber,zip,city,'nl' from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement66()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement67()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement68()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set quantity=0,description='$form.txtoms$' where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr382()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(mm.bestelnr,fv_material.bestelnr) as bestelnr, mm.description, coalesce(fv_supplier.description,mm.supplier_name) as supomsch, coalesce(mm.price,fv_material.price) as price, mm.quantity, mm.purchaseorderpositie
from            fv_materialmutation mm left outer join 
fv_material on mm.material_id = fv_material.id left outer join
                      fv_supplier on fv_material.supplier_id = fv_supplier.id
where  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement69()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr379()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_supplier where gabicode = '29'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement70Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_supplier where isactive =1 and not gabicode is null
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement71Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_material.id,fv_material.bestelnr + '/'  + fv_supplier.description as omsch, fv_material.hitrate, fv_material.description, fv_material.external_id from fv_material inner join fv_supplier on fv_material.supplier_id = fv_supplier.id where 0 = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr380()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_material.bestelnr, fv_material.description, fv_supplier.description as supomsch, fv_material.price, 1 as def
from            fv_material left outer join
                      fv_supplier on fv_material.supplier_id = fv_supplier.id
where  fv_material.id = $sub.grdzoekart.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement72()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,material_id,radiostatus_id,description,type) select newid(),'00000000-0000-0000-0000-000000000000',getdate(),0,id,-1,'$sub.txtoms$','a' from fv_material where id =  $sub.grdzoekart.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr383()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,material_id,radiostatus_id,description,type) select '$flow.mat_id$','00000000-0000-0000-0000-000000000000',getdate(),1,m.id,-1,fv_materialgroup.description,fv_materialgroup.category from fv_materialgroup left outer join fv_material m on fv_materialgroup.material_external_id = m.external_id where fv_materialgroup.id = 0 and '0'<>''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement73Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialgroup where category='h' and isactive =1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement74Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialgroup where category='s' and isactive =1 and parent_id = 0 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement75Component2516()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_material.description as oms, fv_materialgroup.category, fv_materialgroup.id
from         fv_material right outer join
                      fv_materialgroup on fv_material.external_id = fv_materialgroup.material_external_id
where fv_materialgroup.parent_id = 0 order by fv_materialgroup.external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement76()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,radiostatus_id,description,type,price) select newid(),'00000000-0000-0000-0000-000000000000',getdate(),1,-1,'$sub.grdklein.oms$','d',convert(real,replace('$sub.grdklein.id$',',','.')) from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement77Component2528()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 2.5 as id, 'klein materiaal 2.5' as oms from fv_engineer where id = 0 
union
select 5.0 as id, 'klein materiaal 5.0' as oms from fv_engineer where id = 0 
union
select 10.0 as id, 'klein materiaal 10.0' as oms from fv_engineer where id = 0 
union
select 15.0 as id, 'klein materiaal 15.0' as oms from fv_engineer where id = 0 
union
select 20.0 as id, 'klein materiaal 20.0' as oms from fv_engineer where id = 0 
union
select 25.0 as id, 'klein materiaal 25.0' as oms from fv_engineer where id = 0 
union
select 30.0 as id, 'klein materiaal 30.0' as oms from fv_engineer where id = 0
union
select 40.0 as id, 'klein materiaal 40.0' as oms from fv_engineer where id = 0 
union
select 50.0 as id, 'klein materiaal 50.0' as oms from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr496()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 1 as def from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement78()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,material_id,radiostatus_id,description,type) select newid(),'00000000-0000-0000-0000-000000000000',getdate(),0,min(id),-1,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel1$') group by bestelnr union select newid(),'00000000-0000-0000-0000-000000000000',getdate(),0,min(id),-1,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel2$') group by bestelnr union select newid(),'00000000-0000-0000-0000-000000000000',getdate(),0,min(id),-1,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel3$') group by bestelnr union select newid(),'00000000-0000-0000-0000-000000000000',getdate(),0,min(id),-1,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel4$') group by bestelnr union select newid(),'00000000-0000-0000-0000-000000000000',getdate(),0,min(id),-1,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel5$') group by bestelnr ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr386()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '-' as def from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement79()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set supplier_name = '$sub.grdzoeklev.name$' where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement80Component2572()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description from fv_supplier where isactive = 1 and description like '%'+'$sub.txtzoek$' + '%' and 0=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement81()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set supplier_name='$form.txtsup$', bestelnr='$form.txtbestel$', quantity=0,description='$form.txtoms$',price=convert(real,replace('$form.txtprice$',',','.')),n_price=convert(real,replace('$form.txtprice$',',','.')) where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr388()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     mm.supplier_name,mm.bestelnr, mm.description, mm.quantity, mm.price, mm.n_price, mm.purchaseorderpositie
from            fv_materialmutation mm
where  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr389()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     mm.supplier_name,mm.bestelnr, mm.description, mm.quantity, mm.price, mm.n_price
from            fv_materialmutation mm
where  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement82()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement83()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where price is null and id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement84()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set supplier_name='$form.txtsup$', bestelnr='$form.txtbestel$', quantity=0,description='$form.txtoms$',price=convert(real,replace('$form.txtprice$',',','.')) where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr384()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     mm.supplier_name,mm.bestelnr, mm.description, mm.quantity, mm.price, mm.purchaseorderpositie
from            fv_materialmutation mm
where  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr385()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     mm.supplier_name,mm.bestelnr, mm.description, mm.quantity, mm.price
from            fv_materialmutation mm
where  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement85()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement86()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where price is null and id = '$flow.mat_id$' and purchaseorderpositie is null and external_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr390()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select overigekosten, overigekosten_bedrag from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement87()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set overigekosten = '$form.txtkosten_oms$', overigekosten_bedrag = case when '$form.txtkosten$'='' then null else convert(real,replace('$form.txtkosten$',',','.')) end where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr447()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'strukton worksphere heeft in uw opdracht werkzaamheden verricht welke zijn beschreven op de pda. met het plaatsen van een paraaf op de pda van de medewerker van strukton worksphere geeft u aan dat u akkoord gaat met de door de medewerker uitgevoerde werkzaamheden.' as txt from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement88Component4207()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  fv_tmp_werkbonmateriaal.id,
        fv_tmp_werkbonmateriaal.external_id,
        werkbonid,
        fabrikant,
        leverancier,
        aantal,
        artikelnummer,
        coalesce(artikelnummer, '') + '/' + coalesce(omschrijving, '') + '/'
        + coalesce(leverancier, '') as omschrijving,
        '' as empty,
        0 as is_mutated
from    fv_tmp_werkbonmateriaal
        inner join fv_activity on fv_activity.sub_id = fv_tmp_werkbonmateriaal.werkbonid
where not exists (select * from fv_materialmutation where fv_activity.id = fv_materialmutation.activity_id
and fv_materialmutation.wbm_id = fv_tmp_werkbonmateriaal.external_id)
and fv_activity.id = '00000000-0000-0000-0000-000000000000'
union
select  fv_tmp_werkbonmateriaal.id,
        fv_tmp_werkbonmateriaal.external_id,
        werkbonid,
        fabrikant,
        leverancier,
        aantal,
        artikelnummer,
        coalesce(artikelnummer, '') + '/' + coalesce(omschrijving, '') + '/'
        + coalesce(leverancier, '') as omschrijving,
        '' as empty,
        1
from    fv_tmp_werkbonmateriaal
        inner join fv_activity on fv_activity.sub_id = fv_tmp_werkbonmateriaal.werkbonid
where exists (select * from fv_materialmutation where fv_activity.id = fv_materialmutation.activity_id
and fv_materialmutation.wbm_id = fv_tmp_werkbonmateriaal.external_id)
and fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement89Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(bestelnr,'') + '/' + coalesce(description,'') + '/' + coalesce(supplier_name,'') as omsch, quantity, type, id,'' as empty
from         fv_materialmutation
where     type in ('d','o','a') and activity_id = '00000000-0000-0000-0000-000000000000'
and material_id is null
union
select     coalesce(fv_material.bestelnr,'') + '/' + coalesce(fv_materialmutation.description,'') + '/' + coalesce(fv_supplier.description,'') as omsch, fv_materialmutation.quantity, type, fv_materialmutation.id,'' as empty
from         fv_materialmutation inner join
                      fv_material on fv_materialmutation.material_id = fv_material.id left outer join
                      fv_supplier on fv_material.supplier_id = fv_supplier.id
where     (fv_materialmutation.type = 'a') and  activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr351()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(convert(nvarchar,fv_activity.sub_id),'') as werkbon,  coalesce(fv_activity.serviceordernumber,'') as serviceordernumber, opdrachtnummer from fv_activity
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement90()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set opdrachtnummer = '$sub.txtopdrachtnr$' where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement91()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set opdrachtnummer = '$sub.txtopdrachtnr$' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr361()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_customer.external_id,
    fv_activity.equipmentname,
    fv_customer.id,
    'focus.intra/onderhoudshistorie?p=' + coalesce(fv_engineer.external_id, '') + '&eq=' + coalesce(fv_serviceobject.external_id, '') + '&fp=' + replace('/', '_', coalesce(fv_customer.external_id, '')) as webadres
from    fv_activity
    inner join fv_engineer
        on fv_activity.engineer_id = fv_engineer.id
            and fv_activity.id = '00000000-0000-0000-0000-000000000000'
    left outer join fv_customer
        on fv_activity.customer_id = fv_customer.id
    left outer join fv_serviceobject
        on fv_activity.serviceobject_id = fv_serviceobject.id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement92Component2639()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_history.id, historydt, fv_history.description
from         fv_history inner join fv_activity on fv_activity.id = fv_history.activity_id
where fv_activity.id = '00000000-0000-0000-0000-000000000000' and fv_history.serviceobject_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement93Component3773()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_history.id, historydt, fv_history.description
from         fv_history inner join fv_activity on fv_activity.id = fv_history.activity_id
where fv_activity.id = '00000000-0000-0000-0000-000000000000' and not fv_history.serviceobject_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr371()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select extra_notes from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement94()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$sub.txtnotes$',extra_notes = '$sub.txtextra$' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr413()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select       'ordernr: ' + coalesce(fv_activity.serviceordernumber,'') + '
' + 'werkbon: ' + coalesce(convert(nvarchar,fv_activity.sub_id),'') + '
' + 'datum: ' + convert(nvarchar,getdate(),105) + '

' + 'omschrijving: 
' + coalesce (fv_activity.description, '') as samenvatting
from         fv_activity
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr657()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select      fv_debrief.notes
from         fv_debrief 
where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr725()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  ds.rostatusdt as enddt
from fv_activity a
left outer join  fv_debrief_status ds on ds.external_id = a.external_id and ds.sub_id = a.sub_id
and ds.activitystatustype_id in (59,150)
where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement95()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set medewerker_id = $sub.grdzoekmdw.id$ where id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement96()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_debrief
set    vervolg_medewerker_id = $sub.grdzoekmdw.id$,
    vervolgactie_id = case when '0'='' or '0'='null' then null else '0' end,
    vervolgnotes = '$form.txtvervolgnotes$',
    restduur = datepart(hh, '$form.tmrest$') + convert(real, datepart(mi, '$form.tmrest$')) / 60
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement97Component2666()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    id,
    external_id,
    description
from    fv_medewerker
where    isactive = 1
    and description like '$sub.txtzoek$' + '%'
    and '0' = '1'
order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr387()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '-' as def from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement98()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set supplier_name = '$sub.grdzoeklev2.name$' where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement99Component2675()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description from fv_supplier where isactive = 1 and description like '%'+'$sub.txtzoek$' + '%' and 0=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr427()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     cm.external_id, cm.name, cm.name2, coalesce(cm.street,'') + '
' + coalesce(cm.zip,'') + ' ' +  coalesce(cm.city,'') + '
' +  case when cm.fax is null then '' else 'fax: ' end + coalesce(cm.fax,'') as overig, 
                      c.contactsurname + ' ' + c.phone as contact
from         fv_customer_main cm left outer join fv_contact c on c.customer_main_id = cm.id
where cm.external_id = '$sub.txtklantnr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement100()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitytype_id= 0 where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement101()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set capability_id= case when '0'='' then null else '0' end, productgroep_id= case when '0'='' then null else '0' end, functieplaatsnaam=case when coalesce(customer_id,0)=0 then '$form.txtfpnb$' else functieplaatsnaam end where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement102()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set contact = '$sub.grdcontact.extid$', contactpersoon = '$sub.grdcontact.name$', contactpersoon_phone = '$sub.grdcontact.phone$', description = '$form.txtdescnw$', opdrachtnummer = '$form.txtopdrnr$' where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement103Component2685()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_contact.contactsurname, fv_contact.phone,fv_contact.id, fv_contact.external_id
from         fv_customer_main inner join
                      fv_activity on fv_customer_main.id = fv_activity.customer_main_id inner join
                      fv_contact on fv_customer_main.id = fv_contact.customer_main_id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'
order by fv_contact.contactsurname");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr430()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select c.external_id from fv_customer c inner join fv_activity a on a.customer_id = c.id where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement104Component2691()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    s.id,
    substring(s.external_id, 9, 10) as short_ext,
    s.description,
    s.external_id
from    fv_serviceobject s
    inner join fv_customer c
        on c.id = s.customer_id
    inner join fv_activity a
        on a.customer_main_id = c.customer_main_id
where    a.id = '00000000-0000-0000-0000-000000000000'
    and c.external_id like '$sub.txtfp$' + '%'
    and s.external_id like '%' + '$sub.txteqnr$'
    and s.description like '%$sub.txtdescez$%'
    and '0' = '1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement105()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitytype_id= 0 end where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement106()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set capability_id= case when '0'='' then null else '0' end, productgroep_id= case when '0'='' then null else '0' end, functieplaatsnaam=case when coalesce(customer_id,0)=0 then '$form.txtfpnb$' else functieplaatsnaam end where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement107()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set serviceobject_id = $sub.grdeq2.id$, equipmentname = '$sub.grdeq2.name$', description = '$form.txtdescez$', opdrachtnummer = '$form.txtopdrnr$' where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement108Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"            select 
                convert(nvarchar,datepart(dd,sta.statusdt)) + '-'+ convert(nvarchar,datepart(mm,sta.statusdt)) + ' ' + case len(convert(nvarchar,datepart(hh,sta.statusdt))) when 1 then '0' else '' end + convert(nvarchar,datepart(hh,sta.statusdt)) + ':'+ + case len(convert(nvarchar,datepart(mi,sta.statusdt))) when 1 then '0' else '' end + convert(nvarchar,datepart(mi,sta.statusdt)) as plnstrtdt,
                a.serviceordernumber + ' ' + convert(nvarchar,a.sub_id) as sonr,                coalesce(a.functieplaatsnaam,'') + ' ' + substring(a.description,1,50) as betreft
                from fv_activity a inner join fv_activitystatus sta on sta.activity_id = a.id and ((sta.activitystatustype_id = 30) or (sta.activitystatustype_id = 170))
where (a.engineer_id=0)  and ((a.activitystatustype_id<60) or (a.activitystatustype_id=140) or (a.activitystatustype_id=160) or (a.activitystatustype_id=170))
and a.planstartdt<='$app.selecteddateend$'                order by sta.statusdt desc



");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr491()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement109Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar,datepart(dd,a.planstartdt)) + '-'+ convert(nvarchar,datepart(mm,a.planstartdt)) + ' ' + case len(convert(nvarchar,datepart(hh,a.planstartdt))) when 1 then '0' else '' end + convert(nvarchar,datepart(hh,a.planstartdt)) + ':'+ + case len(convert(nvarchar,datepart(mi,a.planstartdt))) when 1 then '0' else '' end + convert(nvarchar,datepart(mi,a.planstartdt)) as plnstrtdt, a.id, a.serviceorder_id,coalesce(a.functieplaatsnaam,'') + ' ' + substring(a.description,1,50) as betreft, a.ordersoort_id from fv_activity a where a.external_id is null and a.activitystatustype_id = 30 and a.engineer_id = 0 and a.serviceordernumber is null and a.sub_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement110()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitystatustype_id = 120 where id = '$sub.grdopen.id$' and $sub.grdopen.ordersoort_id$>=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement111()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id,engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)  select newid(),0, getdate(), 0, 120, '$sub.grdopen.id$' from fv_engineer  where  id = 0 and $sub.grdopen.ordersoort_id$>=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement112()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select   case activitytype_id when 4 then 1 when 15 then 1 else 0 end as isonderhoud
  from    fv_activity
  where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement113()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select   coalesce(isequipmentscannenverplicht, 0)   as isequipmentscannenverplicht
  from    fv_activity
  where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement114()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) from fv_serviceobject s inner join fv_activity a on a.serviceobject_id = s.id where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement115()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set isequipmentnietvantoepassing = 0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr500()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select scannr from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr501()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select problemcode_id, causecode_id, solutioncode_id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr502()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select s.external_id, s.description,s.id from fv_serviceobject s inner join fv_activity a on a.serviceobject_id = s.id where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr541()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set serviceobject_id = case when '$form.txtequipmentid$' = '' then null else '$form.txtequipmentid$' end where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr542()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set solutioncode_id= case when '0' = '' then null else 0+0 end where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr543()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set scandt=getdate(),scannr='$form.txtequipment$' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement116Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_solutioncode where isactive = 1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement117()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set isequipmentnietvantoepassing = 1 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr511()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     verholpen, coalesce(verholpendt,getdate()) as verholpendt, vervolgactie, vervolgactie_id, vervolgnotes, startdt
from         fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr512()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set verholpen=0, verholpendt='29-8-2012 21:55:00', startdt='0', vervolgactie=0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement118()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when /*(patindex ('%een%' , '$form.txtnotes$') +
patindex ( '%het%' , '$form.txtnotes$' ) +
patindex ( '%de%' , '$form.txtnotes$' )
) **/ 
(len('$form.txtnotes$')-20) > 0 then 1 else 0 end as checklidwoorden50karakters");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr514()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select description from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr515()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes, extra_notes from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr516()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$sub.txtnotes$', chknotes= case when '$sub.txtnotes$'='' then 0 else 1 end where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement119()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$sub.txtnotes$' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement120()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_teksten (id, notes, engineer_id, radiostatus_id) select newid(), '$form.txtnotes$', id, 0 from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement121()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_remark (id, notes, engineer_id) select max(id) + 1, '$form.txtnotes$', 0 from fv_remark");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr517()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select def_remark_category_id as def from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr635()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr683()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$sub.grdtekst.notes$' as notes from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement122Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description  from fv_remark_category where isactive = 1 order by id
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement123Component2928()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    min(r.id) as id,
    substring(r.notes, 1, 
        case    when charindex(nchar(10),r.notes)=0 then 80
            when charindex(nchar(10),r.notes)<80 then charindex(nchar(10),r.notes)
            else 80
        end) as n,
    r.notes
from    fv_remark r
where    ((r.engineer_id = 0 and 0 = -1)
        or (r.engineer_id is null and r.remark_category_id = 0)
        or (0 = -2)
    )
    and r.notes like '%$sub.txtsearch$%'
group by r.notes
order by r.notes");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement124()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$sub.txtdebnotes$' + case when '$sub.txtdebnotes$'='' then '' else ' ' end + '$sub.grdtekst.notes$'  where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement125()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_engineer set def_remark_category_id = case when '0'='' then null else '0' end");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement126()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_remark where id = $sub.grdtekst.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr518()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select getdate() as nu, id, 0 as def from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement127Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_cancelreason.id, fv_cancelreason.description from fv_cancelreason where fv_cancelreason.isactive = 1 order by fv_cancelreason.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement128()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief 
set restduur=(0*60)+0,
send_email = null
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement129()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(isafmeldbonvoorklantverplicht, 0)+coalesce(ishandtekeningverplicht, 0) as beidenietverplicht
from    fv_activity
where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr521()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set vervolgactie_id= case when '0' = '' then null else 0+0 end, vervolgnotes='$form.txtvervolgnotes$',restduur=0/60.0 where activity_id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr522()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     vervolgactie_id, vervolgnotes,restduur*60 as restduur
from         fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr523()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  fv_medewerker.description from fv_debrief inner join fv_medewerker on fv_debrief.vervolg_medewerker_id = fv_medewerker.id where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement130Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    id,
    description
from
    fv_vervolgactie
where
    (
     not exists ( select
                    0
                  from
                    fv_debrief_status
                  where
                    activity_id in (select
                                        a.id
                                    from
                                        fv_activity a
                                        inner join fv_activity b
                                            on a.external_id = b.external_id
                                               and a.sub_id = b.sub_id
                                    where
                                        b.id = '00000000-0000-0000-0000-000000000000')
                    and activitystatustype_id in (157) )
     and description like '%noodopl.%'
    )
union
select
    id,
    description
from
    fv_vervolgactie
where
    description not like '%noodopl.%'
order by
    description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement131()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief
set    email = '$form.txtemail$'
        + case when len('$form.txtemail$') > 0 then ';'
               else ''
          end + '$sub.grdzoekemail.cc$'
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement132()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update  fv_debrief
set     email = '$form.txtemail$'
        + case when len('$form.txtemail$') > 0 then ';'
               else ''
          end + '$sub.grdzoekemail.cc$',
        name_signature = '$form.txtparaafnaam$',
        opdrachtnummer = '$form.txtopdrachtnr$',
        signaturedt = substring('$form.datsig$', 1, 11)
        + substring('$form.timesig$', 12, 8)
where   activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement133Component2981()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  id,
        external_id,
        description,
        email
from    fv_medewerker
where   isactive = 1
        and description like '$sub.txtzoek$' + '%'
        and '0' = '1'
        and coalesce(email, '') <> ''
union
select  id,
        external_id,
        description,
        email
from    fv_medewerker
where   isactive = 1
        and description like '$sub.txtzoek$' + '%'
        and '0' = '1'
        and coalesce(email, '') = ''
        and not exists ( select    *
                  from      fv_medewerker
                  where     isactive = 1
                            and description like '$sub.txtzoek$' + '%'
                            and '0' = '1'
                            and coalesce(email, '') <> ''
                )
order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement134()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set sub_id = case when '$sub.txtwb$'='' then null else '$sub.txtwb$' end, serviceordernumber='$sub.txtso$' where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement135()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and activitystatustype_id = 30");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr526()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr527()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select at.external_id as typewerk,
cm.external_id as kunnr,
a.contact as contactpersoonid,
case when coalesce(a.customer_id,0)=0 then a.functieplaatsnaam else fp.external_id end as functieplaatsid,
coalesce(eq.external_id,'') as equipmentid,
coalesce(a.description,'') as omschrijving,
coalesce(a.opdrachtnummer,'') as opdrachtnummer,
pc.external_id as productcombi  from fv_activity a inner join fv_activitytype at on at.id = a.activitytype_id left outer join fv_customer_main cm on a.customer_main_id = cm.id left outer join fv_customer fp on a.customer_id = fp.id  left outer join fv_serviceobject eq on a.serviceobject_id = eq.id  left outer join fv_capability pc on a.capability_id = pc.id where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement136Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_problemcode where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement137Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_causecode where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr530()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id,engineer_id, startdt, rostartdt, radiostatus_id, activity_id, labourstatus_id) select  newid(),   '0', getdate(), getdate() ,  3, '00000000-0000-0000-0000-000000000000', 2 from fv_engineer where fv_engineer.id = '0' and not exists (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id=2 and roenddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr531()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 50, 0 from fv_engineer where id = 0 and 50 in (select activitystatustype_id from fv_activity where id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr624()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(convert(nvarchar,fv_activity.sub_id),'')+ ' / ' + coalesce(fv_activity.serviceordernumber,'') + ' (' + coalesce(fv_ordersoort.description,'') + ')' as serviceordernumber,
    fv_activity.samenvatting as orderbeschrijving,
    fv_activity.productgroep_id,
    fv_customer.external_id as sb
from    fv_activity
    left outer join fv_ordersoort
        on fv_activity.ordersoort_id = fv_ordersoort.id
    left outer join fv_customer
        on fv_activity.customer_id = fv_customer.id
where    fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement138()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, radiostatus_id, activity_id, serviceobject_id, extra_notes, vervolgactie, name_signature, startdt, opdrachtnummer, send_email, send_specificatie)
select newid(), 3, id, serviceobject_id, notes, 0, contactpersoon, getdate(), opdrachtnummer, case when isafmeldbonvoorklantverplicht = 1 then 1 else null end, case when isafmeldbonvoorklantverplicht = 1 then 1 else null end
from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and not exists (select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement139()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set rostartdt = getdate() where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 2 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement140()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 50, 0
from fv_engineer
where id = 0
    and 50 not in (select activitystatustype_id from fv_activity where id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement141()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt ,engineer_id ,radiostatus_id)
select newid(), id, external_id, sub_id, 50, getdate(), 0, 0 from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and 50 not in (select activitystatustype_id from fv_debrief_status where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement142()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 59, 0
from fv_engineer
where id = 0
    and 59 not in (select activitystatustype_id from fv_debrief_status where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement143()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt ,engineer_id ,radiostatus_id)
select newid(), id, external_id, sub_id, 59, getdate(), 0, 0) from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and 59 not in (select activitystatustype_id from fv_debrief_status where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement144()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as isfunctiehersteld from fv_debrief_status
where activity_id in ( select a.id from fv_activity a
inner join fv_activity b on
a.external_id = b.external_id
and a.sub_id = b.sub_id
where b.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement145()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, radiostatus_id, activity_id, serviceobject_id, extra_notes, vervolgactie, name_signature, startdt, opdrachtnummer, send_email, send_specificatie)
select newid(), 3, id, serviceobject_id, notes, 0, contactpersoon, getdate(), opdrachtnummer, case when isafmeldbonvoorklantverplicht = 1 then 1 else null end, case when isurenspecificatieverplicht = 1 then 1 else null end
from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and not exists (select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement146()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 52, 0
from fv_engineer
where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement147()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select   coalesce(isequipmentscannenverplicht, 0)   as isequipmentscannenverplicht
  from    fv_activity
  where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement148()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select   coalesce(isequipmentscannenverplicht, 0)   as isequipmentscannenverplicht
  from    fv_activity
  where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr538()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(convert(nvarchar,fv_activity.sub_id),'') + ' / ' + coalesce(fv_activity.serviceordernumber,'') + ' (' + coalesce(fv_ordersoort.description,'') + ')' as serviceordernumber,
    fv_activity.samenvatting
from    fv_activity
    left outer join fv_ordersoort
        on fv_activity.ordersoort_id = fv_ordersoort.id
where    fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr539()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id,engineer_id, startdt, rostartdt, radiostatus_id, activity_id, labourstatus_id) select  newid(),   '0', getdate(), getdate() ,  3, '00000000-0000-0000-0000-000000000000', 2 from fv_engineer where fv_engineer.id = '0' and not exists (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id=2 and roenddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr540()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 50, 0 from fv_engineer where id = 0 and 50 in (select activitystatustype_id from fv_activity where id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement149()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  convert(nvarchar, coalesce(min(ds.statusdt),
                                   dateadd(year, 1, getdate())), 126) as debrief_statusdt
from    fv_debrief_status ds
        inner join fv_activity a on a.external_id = ds.external_id
                                    and a.sub_id = ds.sub_id
                                    and a.activitystatustype_id not in ( 120, 125, 60, 62 )
where   ds.activitystatustype_id = 59
        and not exists ( select 0
                         from   fv_activitystatus acts
                         where  acts.activity_id = a.id
                                and acts.activitystatustype_id in ( 120, 125, 60, 62 ) )
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement150()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, radiostatus_id, activity_id, serviceobject_id, extra_notes, vervolgactie, name_signature, startdt, opdrachtnummer, send_email, send_specificatie)
select newid(), 3, id, serviceobject_id, notes, 0, contactpersoon, getdate(), opdrachtnummer, case when isafmeldbonvoorklantverplicht = 1 then 1 else null end, case when isurenspecificatieverplicht = 1 then 1 else null end
from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and not exists (select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement151()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set rostartdt = getdate() where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 2 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement152()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 50, case when coalesce(isantidaterentoegestaan,0) = 1 then -1 else 0 end
from fv_activity
where id = '00000000-0000-0000-0000-000000000000' and activitystatustype_id!=50");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement153()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(isantidaterentoegestaan,1) from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement154()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as isorderstarted from fv_debrief_status
where activity_id in ( select a.id from fv_activity a
inner join fv_activity b on
a.external_id = b.external_id
and a.sub_id = b.sub_id
where b.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id in (50,157)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement155()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt ,engineer_id ,radiostatus_id)
select newid(), id, external_id, sub_id, 50, getdate(), 0, 0 from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and 50 not in (select activitystatustype_id from fv_debrief_status where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement156()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '00000000-0000-0000-0000-000000000000', 0, getdate(), 59, case when coalesce(isantidaterentoegestaan,0) = 1 then -1 else 0 end
from fv_activity
where id = '00000000-0000-0000-0000-000000000000' and activitystatustype_id!=59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement157()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(isantidaterentoegestaan,1) from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement158()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as isorderstarted from fv_debrief_status
where activity_id in ( select a.id from fv_activity a
inner join fv_activity b on
a.external_id = b.external_id
and a.sub_id = b.sub_id
where b.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement159()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt, rostatusdt, engineer_id ,radiostatus_id)
select newid(), id, external_id, sub_id, 59, getdate(), '29-8-2012 21:55:00', 0, 0 from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and 59 not in (select activitystatustype_id from fv_debrief_status where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr545()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(convert(nvarchar,fv_activity.sub_id),'') as werkbonnr, coalesce(fv_activity.serviceordernumber,'') as serviceordernumber, coalesce(fv_ordersoort.description,'') + ' - ' + coalesce(at.description,'') as ordersoort, fv_activity.sub_id, fv_activity.name, fv_activity.name_2, 
                      fv_activity.functieplaatsnaam, fv_activity.opdrachtnummer, fv_activity.description, fv_activity.melddatum, fv_activity.melder, 
                      fv_activity.melder_phone, fv_priority.description as priority, fv_activity.notes, c.external_id as functieplaatsnr, s.external_id as equipmentnr, fv_activity.equipmentname,
fv_activity.planstartdt, opdrachtnummer
from         fv_activity left outer join
                      fv_ordersoort on fv_activity.ordersoort_id = fv_ordersoort.id left outer join
                      fv_priority on fv_activity.priority_id = fv_priority.id left outer join
fv_activitytype at on fv_activity.activitytype_id = at.id left outer join fv_customer c on fv_activity.customer_id = c.id left outer join fv_serviceobject s on fv_activity.serviceobject_id = s.id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr552()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_activity.serviceordernumber,'') as serviceordernumber from fv_activity where  id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr553()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) as aantal from fv_materialmutation where activity_id = '00000000-0000-0000-0000-000000000000' and external_id is null and not purchaseorderpositie is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr681()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement160()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement161()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement162Component3800()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, purchaseorder, leveranciernaam, convert(nvarchar,orderdt,105) + ' ' + coalesce(besteller,'') as orderdt, case when selected=1 then '*' else '' end as selected from fv_tmp_purchaseorder order by purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement163()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_purchaseorder set selected = case when coalesce(selected,0) = 0 then 1 else 0 end where id = '$sub.grdorder.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement164Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fa_aantal,go_aantal,be_aantal) as aantal, omschrijving from fv_tmp_purchaseorderline where purchaseorder = '$sub.grdorder.purchaseorder$' order by positie");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement165()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,radiostatus_id,type) select '$flow.mat_id$','00000000-0000-0000-0000-000000000000',getdate(),1,-1,'d' from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement166Component3133()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(bestelnr,'') + '/' + coalesce(description,'') + '/' + coalesce(supplier_name,'') as omsch, quantity, type, id,'' as empty
from         fv_materialmutation
where     ((type = 'd') or(type = 'o')) and activity_id = '00000000-0000-0000-0000-000000000000' and fv_materialmutation.external_id is null and fv_materialmutation.purchaseorderpositie is null
union
select     coalesce(fv_material.bestelnr,'') + '/' + coalesce(fv_materialmutation.description,'') + '/' + coalesce(fv_supplier.description,'') as omsch, fv_materialmutation.quantity, type, fv_materialmutation.id,'' as empty
from         fv_materialmutation inner join
                      fv_material on fv_materialmutation.material_id = fv_material.id left outer join
                      fv_supplier on fv_material.supplier_id = fv_supplier.id
where     (fv_materialmutation.type = 'a') and  activity_id = '00000000-0000-0000-0000-000000000000' and fv_materialmutation.external_id is null and fv_materialmutation.purchaseorderpositie is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr564()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sonummer,werkbon,coalesce(s.description,'') + '; ' + t.leveranciernummer as leveranciernummer, coalesce(t.naam,'') + '
' + coalesce(t.straat,'') + ' ' + coalesce(t.huisnummer,'') + '
' + coalesce(t.postcode,'') + ' ' + coalesce(t.plaats,'') as adres,case when t.onderaanneming=1 then 'true' else 'false' end as onderaanneming, case when t.balie=1 then 'true' else 'false' end as balie, coalesce(t.straat,'') as straat, coalesce(t.leveranciernummer,'') as levnr from fv_tmp_bestelling t left outer join fv_supplier s on s.external_id = t.leveranciernummer");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr565()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr567()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set onderaanneming = case when '$form.chkoa$'='true' then 1 else 0 end, balie = case when '$form.chkbalie$'='true' then 1 else 0 end");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr569()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,aantal,type) select newid(),1,'o' from fv_engineer where id = 0 and '$flow.oa$'='1' and not exists (select id from fv_tmp_bestellingregel)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement167()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel where exists (select id from fv_tmp_bestelling where type<>'o')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement168()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel where exists (select id from fv_tmp_bestelling where type='o')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement169()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set onderaanneming = case when '$form.chkoa$'='true' then 1 else 0 end, balie = case when '$form.chkbalie$'='true' then 1 else 0 end");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement170()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set description = '$flow.bestelling_nummer$' where id = '00000000-0000-0000-0000-000000000000' and ordersoort_id = -2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement171Component3162()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     omschrijving as omsch, aantal as quantity, type, id,'' as empty
from         fv_tmp_bestellingregel

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement172()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,aantal,type) select '$flow.mat_id$',1,'d' from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr554()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_supplier where gabicode = '29'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement173Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_supplier where isactive =1 and not gabicode is null
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement174Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_material.id,fv_material.bestelnr + '/'  + fv_supplier.description as omsch, fv_material.hitrate, fv_material.description, fv_material.external_id from fv_material inner join fv_supplier on fv_material.supplier_id = fv_supplier.id where 0 = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr555()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_material.bestelnr, fv_material.description, fv_supplier.description as supomsch, fv_material.price, 1 as def
from            fv_material left outer join
                      fv_supplier on fv_material.supplier_id = fv_supplier.id
where  fv_material.id = $sub.grdzoekartbest.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement175()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,bestelling_id,aantal,artikelnummer,omschrijving,prijs,type) select newid(),id,0,'$sub.txtbestel$','$sub.txtoms$',0,'a' from fv_tmp_bestelling where id = '$flow.bestel_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr556()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 1 as def from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement176()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,bestelling_id,artikelnummer,aantal,omschrijving,type) select newid(),'$flow.bestel_id$','$sub.txtbestel1$',0,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel1$') group by bestelnr union select newid(),'$flow.bestel_id$','$sub.txtbestel2$',0,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel2$') group by bestelnr union select newid(),'$flow.bestel_id$','$sub.txtbestel3$',0,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel3$') group by bestelnr union select newid(),'$flow.bestel_id$','$sub.txtbestel4$',0,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel4$') group by bestelnr union select newid(),'$flow.bestel_id$','$sub.txtbestel5$',0,min(description),'a' from fv_material where (bestelnr = '$sub.txtbestel5$') group by bestelnr ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr557()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,bestelling_id,artikelnummer,aantal,omschrijving,type) select '$flow.mat_id$', '$flow.bestel_id$', m.external_id, 1, m.description, fv_materialgroup.category from fv_materialgroup left outer join fv_material m on fv_materialgroup.material_external_id = m.external_id where fv_materialgroup.id = 0 and '0'<>''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement177Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialgroup where category='h' and isactive =1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement178Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialgroup where category='s' and isactive =1 and parent_id = 0 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement179Component3200()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_material.description as oms, fv_materialgroup.category, fv_materialgroup.id
from         fv_material right outer join
                      fv_materialgroup on fv_material.external_id = fv_materialgroup.material_external_id
where fv_materialgroup.parent_id = 0 order by fv_materialgroup.external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement180()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestellingregel set aantal=0,omschrijving='$form.txtoms$' where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr558()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     artikelnummer,omschrijving,aantal,prijs
from            fv_tmp_bestellingregel
where  id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement181()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement182()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestellingregel set artikelnummer='$form.txtbestel$', aantal=0,omschrijving='$form.txtoms$',prijs=convert(real,replace('$form.txtprice$',',','.')) where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr559()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select artikelnummer,omschrijving,aantal,prijs
from            fv_tmp_bestellingregel
where  id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement183()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement184()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel where prijs is null and id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement185()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestellingregel set artikelnummer='$form.txtbestel$', aantal=0,omschrijving='$form.txtoms$',prijs=convert(real,replace('$form.txtprice$',',','.'))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr561()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select artikelnummer,omschrijving,aantal,prijs
from            fv_tmp_bestellingregel
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement186()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr563()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '-' as def from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr577()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select leveranciernummer from fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr667()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$sub.grdzoeklev3.totaal$' as totaal from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement187Component3234()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description, external_id + '
' + description + '
' + coalesce(straat,'') + ' ' + coalesce(huisnummer,'') + '
' + coalesce(postcode,'') + ' ' + coalesce(plaats,'') + '
tel: ' + coalesce(telefoon,'') + '
fax: ' + coalesce(fax,'') as totaal from fv_supplier where isactive = 1 and description like '%'+'$sub.txtzoek$' + '%' and 0=1

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement188()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set leveranciernummer = '$sub.grdzoeklev3.ext_id$' where id = '$flow.bestel_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr566()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password, '$flow.functieplaats$' as fp from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement189()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_orderrequest");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement190()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_orderrequest set selected=1 where sonummer = '$flow.sonrophalen$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement191Component3249()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sonummer, coalesce(sonummer,'') + ' ' + coalesce(omschrijving,'') + ' ' + coalesce(basisstart,'') + ' ' + coalesce(basiseind,'') as omschrijving from fv_tmp_orderrequest where selected=0 order by sonummer");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement192()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_orderrequest set selected=0 where sonummer = '$flow.sonrgekozen$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement193Component3252()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sonummer, coalesce(sonummer,'') + ' ' + coalesce(omschrijving,'') + ' ' + coalesce(basisstart,'') + ' ' + coalesce(basiseind,'') as omschrijving from fv_tmp_orderrequest where selected=1 order by sonummer");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr568()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select naam,naam2,straat,huisnummer,postcode,plaats,land from fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement194()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set naam='$sub.txtnaam$',naam2='$sub.txtnaam2$',straat='$sub.txtstraat$',plaats='$sub.txtplaats$',postcode='$sub.txtzip$',land='$sub.txtland$',onderaanneming = case when '$form.chkoa$'='true' then 1 else 0 end, balie = case when '$form.chkbalie$'='true' then 1 else 0 end");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr570()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement195()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_orderrequest");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement196()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_orderrequest (sonummer,selected) select '$sub.txtso$',1 from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr571()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_activity.serviceordernumber,'') as serviceordernumber from fv_activity where  id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr573()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement197()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement198()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement199Component3281()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, purchaseorder, leveranciernaam, convert(nvarchar,orderdt,105) + ' ' + coalesce(besteller,'') as orderdt, case when selected=1 then 'v' else '' end as selected from fv_tmp_purchaseorder order by purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement200Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fa_aantal,go_aantal,be_aantal) as aantal, omschrijving from fv_tmp_purchaseorderline where purchaseorder = '$sub.grdorder.purchaseorder$' order by positie");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement201()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_purchaseorder set selected = case when coalesce(selected,0) = 0 then 1 else 0 end where id = '$sub.grdorder.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement202()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_purchaseorder set selected = 0 where id <> '$sub.grdorder.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr574()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement203()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement204()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement205()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_purchaseorder set selected = 1 where purchaseorder in (select min(purchaseorder) from fv_tmp_purchaseorder)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement206Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(ol.fa_aantal,ol.go_aantal,ol.be_aantal) as aantal, ol.omschrijving from fv_tmp_purchaseorderline ol inner join fv_tmp_purchaseorder o on ol.purchaseorder = o.purchaseorder and o.selected = 1 order by ol.positie");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr576()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select description, coalesce(straat,'') + coalesce(huisnummer,'') as adres, postcode, plaats, telefoon, fax, external_id from fv_supplier where external_id = '$sub.txtlevnr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr595()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '$flow.werkdatum$'='' then convert(datetime,substring(convert(nvarchar,getdate(),126),1,10)) else convert(datetime,'$flow.werkdatum$') end as datum from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr596()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    convert(real, sum(case when lm.veldindicatie in ('indirect', 'normaal', 'reis binnen werktijd') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal) else 0 end)) / 60 as n_aantal,
    convert(real, sum(case when lm.veldindicatie in ('reis') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal) else 0 end)) / 60 as r_aantal,
    convert(real, sum(case when lm.veldindicatie in ('over', 'over_extra', 'overuren 1en2') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal) else 0 end)) / 60 as o_aantal,
    datepart(wk, dateadd(dd,-1,convert(datetime, '$sub.dtweek$'))) + 1 - datepart(ww, dateadd(yy, ( datepart(year, convert(datetime, '$sub.dtweek$')) - 1900 ), 0) + 3) as weeknr
from    fv_engineer
    cross join fv_weekdagen
    left outer join fv_declaratie d
        on d.werkdt = dateadd(dd, fv_weekdagen.id, dateadd(dd, 2 - datepart(dw, '$sub.dtweek$') - case when datepart(dw, '$sub.dtweek$') = 1 then 7 else 0 end, '$sub.dtweek$'))
            and d.engineer_id = fv_engineer.id
    left outer join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
    left outer join fv_looncomponent lc
        on lm.looncomponent_id = lc.id
where    fv_engineer.id = 0
group by    fv_engineer.id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement207Component3315()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_weekdagen.dagnaam as weekdag,
    dateadd(dd, fv_weekdagen.id, dateadd(dd, 2 - datepart(dw, '$sub.dtweek$') - case when datepart(dw, '$sub.dtweek$') = 1 then 7 else 0 end, '$sub.dtweek$')) as dag,
    convert(real, sum(case when lm.veldindicatie in ('indirect', 'normaal', 'reis binnen werktijd') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal) else 0 end)) / 60 as n_aantal,
    convert(real, sum(case when lm.veldindicatie in ('reis') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal) else 0 end)) / 60 as r_aantal,
    convert(real, sum(case when lm.veldindicatie in ('over', 'over_extra', 'overuren 1en2') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal) else 0 end)) / 60 as o_aantal,
    case when sum(case when coalesce(message, '') = '' and coalesce(keurregistratie, '0') <> '0' then 0 else 1 end) = 0 then 'ok' else '' end as verstuurd
from    fv_engineer
    cross join fv_weekdagen
    left outer join fv_declaratie d
        on d.werkdt = dateadd(dd, fv_weekdagen.id, dateadd(dd, 2 - datepart(dw, '$sub.dtweek$') - case when datepart(dw, '$sub.dtweek$') = 1 then 7 else 0 end, '$sub.dtweek$'))
            and d.engineer_id = fv_engineer.id
    left outer join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
    left outer join fv_looncomponent lc
        on lm.looncomponent_id = lc.id
where    fv_engineer.id = 0
group by    fv_weekdagen.dagnaam,
    fv_weekdagen.id
order by    dag");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr583()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select   convert(real, sum(case when lm.veldindicatie in ('indirect', 'normaal', 'reis binnen werktijd') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal)
                           else 0
                      end)) / 60 as n_aantal,
    convert(real, sum(case when lm.veldindicatie in ('reis') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal)
                           else 0
                      end)) / 60 as r_aantal,
    convert(real, sum(case when lm.veldindicatie in ('over', 'over_extra', 'overuren 1en2') then datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal)
                           else 0
                      end)) / 60 as o_aantal,
    convert(nvarchar, convert(datetime, '$flow.werkdatum$'), 105) as datum
from    fv_engineer
    left outer join fv_declaratie d
        on d.werkdt = convert(datetime, '$flow.werkdatum$')
           and d.engineer_id = fv_engineer.id
    left outer join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
    left outer join fv_looncomponent lc
        on lm.looncomponent_id = lc.id
where   fv_engineer.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr607()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sum(case when coalesce(message,'')='' and coalesce(keurregistratie,'0')<>'0' then 0 else 1 end) as verstuurd from fv_declaratie where werkdt = convert(datetime,'$flow.werkdatum$') and engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr608()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(sum(case when lm.veldindicatie='vergoeding' then 1 else 0 end),0) as vergoeding from fv_engineer e left outer join fv_declaratie d on e.id = d.engineer_id inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id=lm.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and e.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement208()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete  from fv_declaratie
where   convert(datetime, '$flow.werkdatum$') = werkdt
and not activity_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement209()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert  into fv_declaratie
(
id,
looncomponent_mapping_id,
werkdt,
aantal,
engineer_id,
activity_id,
prestatiesoort,
rubricering
)
select  newid(),
lm.id,
convert(datetime, '$flow.werkdatum$'),
dateadd(mi,
sum(datepart(hh, ld.uren) * 60 + datepart(mi, ld.uren)),
convert(datetime, '$flow.werkdatum$')),
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
from    fv_labour l
inner join fv_labour_detail ld on ld.labour_id = l.id
inner join fv_labour_type lt on ld.labour_type_id = lt.id
inner join fv_looncomponent lc on lt.external_id = lc.external_id
inner join fv_looncomponent_mapping lm on lm.looncomponent_id = lc.id
and lm.veldindicatie = 'normaal'
inner join fv_activity a on l.activity_id = a.id
inner join fv_engineer e on e.id = 0
left outer join fv_medewerker m on l.medewerker_id = m.id
and e.external_id = m.external_id             
where   coalesce(l.engineer_id,e.id) = 0 and coalesce(l.engineer_id,m.external_id) is not null
and ld.uren >= convert(datetime, '$flow.werkdatum$')
and ld.uren < dateadd(dd, 1,
convert(datetime, '$flow.werkdatum$'))
group by a.serviceordernumber,
ld.activity_id,
lm.id,
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement210()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert  into fv_declaratie
(
id,
looncomponent_mapping_id,
werkdt,
aantal,
engineer_id,
activity_id,
prestatiesoort,
rubricering
)
select  newid(),
lm.id,
convert(datetime, '$flow.werkdatum$'),
dateadd(mi,
sum(datepart(hh, ld.uren) * 60 + datepart(mi, ld.uren)),
convert(datetime, '$flow.werkdatum$')),
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
from    fv_labour l
inner join fv_labour_detail ld on ld.labour_id = l.id
inner join fv_labour_type lt on ld.labour_type_id = lt.id
inner join fv_looncomponent lc on lt.external_id = lc.external_id
inner join fv_looncomponent_mapping lm on lm.looncomponent_id = lc.id
and lm.veldindicatie = 'reis binnen werktijd'
inner join fv_activity a on l.activity_id = a.id
inner join fv_engineer e on e.id = 0
left outer join fv_medewerker m on l.medewerker_id = m.id
and e.external_id = m.external_id             
where   coalesce(l.engineer_id,e.id) = 0 and coalesce(l.engineer_id,m.external_id) is not null
and ld.uren >= convert(datetime, '$flow.werkdatum$')
and ld.uren < dateadd(dd, 1,
convert(datetime, '$flow.werkdatum$'))
group by a.serviceordernumber,
ld.activity_id,
lm.id,
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement211()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert  into fv_declaratie
(
id,
looncomponent_mapping_id,
werkdt,
aantal,
engineer_id,
activity_id,
prestatiesoort,
rubricering
)
select  newid(),
lm.id,
convert(datetime, '$flow.werkdatum$'),
dateadd(mi,
sum(datepart(hh, ld.uren) * 60 + datepart(mi, ld.uren)),
convert(datetime, '$flow.werkdatum$')),
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
from    fv_labour l
inner join fv_labour_detail ld on ld.labour_id = l.id
inner join fv_labour_type lt on ld.labour_type_id = lt.id
inner join fv_looncomponent lc on lt.external_id = lc.external_id
inner join fv_looncomponent_mapping lm on lm.looncomponent_id = lc.id
and lm.veldindicatie = 'reis'
inner join fv_activity a on l.activity_id = a.id
inner join fv_engineer e on e.id = 0
left outer join fv_medewerker m on l.medewerker_id = m.id
and e.external_id = m.external_id             
where   coalesce(l.engineer_id,e.id) = 0 and coalesce(l.engineer_id,m.external_id) is not null
and ld.uren >= convert(datetime, '$flow.werkdatum$')
and ld.uren < dateadd(dd, 1,
convert(datetime, '$flow.werkdatum$'))
group by a.serviceordernumber,
ld.activity_id,
lm.id,
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement212()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert  into fv_declaratie
(
id,
looncomponent_mapping_id,
werkdt,
aantal,
engineer_id,
activity_id,
prestatiesoort,
rubricering
)
select  newid(),
lm.id,
convert(datetime, '$flow.werkdatum$'),
dateadd(mi,
sum(datepart(hh, ld.uren) * 60 + datepart(mi, ld.uren)),
convert(datetime, '$flow.werkdatum$')),
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
from    fv_labour l
inner join fv_labour_detail ld on ld.labour_id = l.id
inner join fv_labour_type lt on ld.labour_type_id = lt.id
inner join fv_looncomponent lc on lt.external_id = lc.external_id
inner join fv_looncomponent_mapping lm on lm.looncomponent_id = lc.id
and lm.veldindicatie = 'over'
inner join fv_activity a on l.activity_id = a.id
inner join fv_engineer e on e.id = 0
left outer join fv_medewerker m on l.medewerker_id = m.id
and e.external_id = m.external_id             
where   coalesce(l.engineer_id,e.id) = 0 and coalesce(l.engineer_id,m.external_id) is not null
and ld.uren >= convert(datetime, '$flow.werkdatum$')
and ld.uren < dateadd(dd, 1,
convert(datetime, '$flow.werkdatum$'))
group by a.serviceordernumber,
ld.activity_id,
lm.id,
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement213()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert  into fv_declaratie
(
id,
looncomponent_mapping_id,
werkdt,
aantal,
engineer_id,
activity_id,
prestatiesoort,
rubricering
)
select  newid(),
lm.id,
convert(datetime, '$flow.werkdatum$'),
dateadd(mi,
sum(datepart(hh, ld.uren) * 60 + datepart(mi, ld.uren)),
convert(datetime, '$flow.werkdatum$')),
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
from    fv_labour l
inner join fv_labour_detail ld on ld.labour_id = l.id
inner join fv_labour_type lt on ld.labour_type_id = lt.id
inner join fv_looncomponent lc on lt.external_id = lc.external_id
inner join fv_looncomponent_mapping lm on lm.looncomponent_id = lc.id
and lm.veldindicatie = 'overuren 1en2'
inner join fv_activity a on l.activity_id = a.id
inner join fv_engineer e on e.id = 0
left outer join fv_medewerker m on l.medewerker_id = m.id
and e.external_id = m.external_id             
where   coalesce(l.engineer_id,e.id) = 0 and coalesce(l.engineer_id,m.external_id) is not null
and ld.uren >= convert(datetime, '$flow.werkdatum$')
and ld.uren < dateadd(dd, 1,
convert(datetime, '$flow.werkdatum$'))
group by a.serviceordernumber,
ld.activity_id,
lm.id,
coalesce(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement214Component3962()
        {
            var statement = MacroScope.Factory.CreateStatement(@"    select    d.rubricering as id,
        d.rubricering as ordernr,
        convert(real, sum(case when lm.veldindicatie in ('normaal', 'reis binnen werktijd') then datepart(hh, d.aantal)
                               else 0
                          end) * 60 + sum(case when lm.veldindicatie in ('normaal', 'reis binnen werktijd') then datepart(mi, d.aantal)
                                               else 0
                                          end)) / 60 as n_aantal,
        convert(real, sum(case when lm.veldindicatie in ('reis') then datepart(hh, d.aantal)
                               else 0
                          end) * 60 + sum(case when lm.veldindicatie in ('reis') then datepart(mi, d.aantal)
                                               else 0
                                          end)) / 60 as r_aantal,
        convert(real, sum(case when lm.veldindicatie in ('over', 'over_extra', 'overuren 1en2') then datepart(hh, d.aantal)
                               else 0
                          end) * 60 + sum(case when lm.veldindicatie in ('over', 'over_extra', 'overuren 1en2') then datepart(mi, d.aantal)
                                               else 0
                                          end)) / 60 as o_aantal,
        case when sum(case when coalesce(d.keurregistratie, '0') = '0'
                                and coalesce(d.message, '') <> '' then 1
                           else 0
                      end) > 0 then '****'
             else ''
        end as err,
        'o' as screen,
        2 as sortorder,
        d.orderoms
    from    fv_declaratie d
        inner join fv_looncomponent_mapping lm
            on d.looncomponent_mapping_id = lm.id
               and lm.veldindicatie <> 'indirect'
               and lm.veldindicatie <> 'vergoeding'
    where    d.werkdt = convert(datetime, '$flow.werkdatum$')
        and d.engineer_id = 0
        and d.activity_id is null
    group by
        d.rubricering,
        d.orderoms
union
    select    convert(nchar(36), d.activity_id) as id,
        a.serviceordernumber as ordernr,
        convert(real, sum(case when lm.veldindicatie in ('normaal', 'reis binnen werktijd') then datepart(hh, d.aantal)
                               else 0
                          end) * 60 + sum(case when lm.veldindicatie in ('normaal', 'reis binnen werktijd') then datepart(mi, d.aantal)
                                               else 0
                                          end)) / 60 as n_aantal,
        convert(real, sum(case when lm.veldindicatie in ('reis') then datepart(hh, d.aantal)
                               else 0
                          end) * 60 + sum(case when lm.veldindicatie in ('reis') then datepart(mi, d.aantal)
                                               else 0
                                          end)) / 60 as r_aantal,
        convert(real, sum(case when lm.veldindicatie in ('over', 'over_extra', 'overuren 1en2') then datepart(hh, d.aantal)
                               else 0
                          end) * 60 + sum(case when lm.veldindicatie in ('over', 'over_extra', 'overuren 1en2') then datepart(mi, d.aantal)
                                               else 0
                                          end)) / 60 as o_aantal,
        case when sum(case when coalesce(d.keurregistratie, '0') = '0' and coalesce(d.message, '') <> '' then 1
                           else 0
                      end) > 0 then '****'
             else ''
        end as err,
        'd' as screen,
        1 as sortorder,
        '' as orderoms
    from    fv_declaratie d
        inner join fv_looncomponent_mapping lm
            on d.looncomponent_mapping_id = lm.id
        inner join fv_activity a
            on d.activity_id = a.id
    where    d.werkdt = convert(datetime, '$flow.werkdatum$')
        and d.engineer_id = 0
    group by
        d.activity_id,
        a.serviceordernumber
union
    select    convert(nchar(36), d.id) as id,
        l.description as ordernr,
        convert(real, datepart(hh, d.aantal) * 60 + datepart(mi, d.aantal)) / 60 as n_aantal,
        0 as r_aantal,
        0 as o_aantal,
        case when coalesce(d.keurregistratie, '0') = '0' and coalesce(d.message, '') <> '' then '****'
             else ''
        end as err,
        'i' as screen,
        3 as sortorder,
        '' as orderoms
    from    fv_declaratie d
        inner join fv_looncomponent_mapping lm
            on d.looncomponent_mapping_id = lm.id
               and lm.veldindicatie = 'indirect'
        inner join fv_looncomponent l
            on lm.looncomponent_id = l.id
    where    d.werkdt = convert(datetime, '$flow.werkdatum$')
        and d.engineer_id = 0
    order by sortorder
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr578()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar,convert(datetime,'$flow.werkdatum$'),105) as datum, '0' as def from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement215Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'indirect' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement216()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, omschrijving) select newid(), 0, convert(datetime,'$flow.werkdatum$'), dateadd(mi,0,dateadd(hh,0,'$flow.werkdatum$'+'t00:00:00')),id, '$sub.txtopm$' from fv_engineer where id = 0 and '0'+':'+'0'<>'0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement217Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select l.description, convert(real,datepart(hh,d.aantal)*60+datepart(mi,d.aantal))/60 as aantal from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent l on lm.looncomponent_id = l.id and lm.veldindicatie = 'indirect' where werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement218()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  sum(case when coalesce(message, '') = ''
                      and coalesce(keurregistratie, '0') != '0' then 0
                 else 1
            end) as verstuurd
from    fv_declaratie
where   werkdt = convert(datetime, '$flow.werkdatum$')
        and engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr580()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar,convert(datetime,'$flow.werkdatum$'),105) as datum from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr581()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select looncomponent_mapping_id, aantal, omschrijving from fv_declaratie where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement219Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'indirect' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement220()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set looncomponent_mapping_id = 0, aantal='$sub.tmuren$', omschrijving='$sub.txtopm$' where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement221()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$flow.declaratie$' and substring(convert(nvarchar,aantal,108),1,5)='00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement222()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr584()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar,convert(datetime,'$flow.werkdatum$'),105) as datum from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr610()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sum(case when coalesce(message,'')='' and coalesce(keurregistratie,'0')<>'0' then 0 else 1 end) as verstuurd from fv_declaratie where convert(nvarchar,werkdt,105) = convert(nvarchar,convert(datetime,'$flow.werkdatum$'),105) and engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement223()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where werkdt = convert(datetime,'$flow.werkdatum$') and looncomponent_mapping_id = $sub.grdvergoed.id$ and engineer_id=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement224()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id) select newid(), $sub.grdvergoed.id$, convert(datetime,'$flow.werkdatum$'), null, id from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement225Component3351()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description, case when d.id is null then '' else 'v' end as selected from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id left outer join fv_declaratie d on d.werkdt = convert(datetime,'$flow.werkdatum$') and d.looncomponent_mapping_id = lm.id and d.engineer_id = 0 where lm.veldindicatie = 'vergoeding' and lm.isactive=1 and l.isactive=1
order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement226()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  sum(case when coalesce(message, '') = ''
                      and coalesce(keurregistratie, '0') != '0' then 0
                 else 1
            end) as verstuurd
from    fv_declaratie
where   werkdt = convert(datetime, '$flow.werkdatum$')
        and engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr585()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar,convert(datetime,'$flow.werkdatum$'),105) as datum, serviceordernumber as ordernr, description
from fv_activity
where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr586()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select a.serviceordernumber as ordernr, d.aantal, d.id, d.omschrijving
from fv_declaratie d
    inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id
    inner join fv_activity a on d.activity_id = a.id
where d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and lm.veldindicatie = 'normaal'
    and d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr587()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select a.serviceordernumber as ordernr, a.description, d.aantal, d.looncomponent_mapping_id, d.id, d.reisurentvt
from fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
    inner join fv_activity a
        on d.activity_id = a.id
where d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and lm.veldindicatie = 'reis'
    and d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr588()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    a.serviceordernumber as ordernr,
    a.description,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id
from    fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
    inner join fv_activity a
        on d.activity_id = a.id
where    d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and lm.veldindicatie = 'overuren 1en2'
    and d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr589()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    a.serviceordernumber as ordernr,
    a.description,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id,
    d.overurentvt,

    d.consignatie
from    fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
    inner join fv_activity a
        on d.activity_id = a.id
where    d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and lm.veldindicatie = 'over'
    and d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr709()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select a.serviceordernumber as ordernr, d.aantal, d.id, d.omschrijving
from fv_declaratie d
    inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id
    inner join fv_activity a on d.activity_id = a.id
where d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and lm.veldindicatie = 'reis binnen werktijd'
    and d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement227Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    lm.id,
    l.description
from    fv_looncomponent l
    inner join fv_looncomponent_mapping lm
        on lm.looncomponent_id = l.id
where    lm.veldindicatie = 'reis'
    and lm.isactive = 1
    and l.isactive = 1
order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement228Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    lm.id,
    l.description
from    fv_looncomponent l
    inner join fv_looncomponent_mapping lm
        on lm.looncomponent_id = l.id
where    lm.veldindicatie = 'over'
    and lm.isactive = 1
    and l.isactive = 1
order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement229()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving)

select newid(), lm.id, convert(datetime, '$flow.werkdatum$'), '$sub.tmuren$', 0, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$'

from fv_looncomponent_mapping lm

    inner join fv_looncomponent lc

        on lm.looncomponent_id = lc.id

            and lm.veldindicatie = 'normaal'

            and substring('$sub.tmuren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement230()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set aantal = '$sub.tmuren$', omschrijving = '$sub.txtopm$' where id = '$sub.txtdeclidn$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement231()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidn$' and substring(convert(nvarchar, aantal, 108), 1, 5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement232()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving, reisurentvt)

select newid(), lm.id, convert(datetime, '$flow.werkdatum$'), '$sub.tmreisuren$', 0, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', case when '$sub.chkreisuren$' = 'true' then 1 else 0 end

from fv_looncomponent_mapping lm

    inner join fv_looncomponent lc

        on lm.looncomponent_id = lc.id

            and lm.veldindicatie = 'reis binnen werktijd'

            and substring('$sub.tmreisuren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement233()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set aantal = '$sub.tmreisuren$', omschrijving = '$sub.txtopm$', reisurentvt = case when '$sub.chkreisuren$' = 'true' then 1 else 0 end where id = '$sub.txtdeclidnr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement234()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidnr$' and substring(convert(nvarchar, aantal, 108), 1, 5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement235()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving, reisurentvt)

select newid(), lm.id, convert(datetime, '$flow.werkdatum$'), '$sub.tmoveriguren$', 0, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', case when '$sub.chkreisuren$' = 'true' then 1 else 0 end

from fv_looncomponent_mapping lm

    inner join fv_looncomponent lc

        on lm.looncomponent_id = lc.id

            and lm.id = case '0' when '' then null when 'null' then null else '0' end

            and substring('$sub.tmoveriguren$',12,5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement236()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie

set looncomponent_mapping_id = case '0' when '' then null when 'null' then null else '0' end,

    aantal = '$sub.tmoveriguren$',

    omschrijving = '$sub.txtopm$',

    reisurentvt = case when '$sub.chkreisuren$' = 'true' then 1 else 0 end

where id = '$sub.txtdeclidr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement237()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidr$' and ((substring(convert(nvarchar, aantal, 108), 1, 5) = '00:00') or (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement238()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving, overurentvt, consignatie)

select newid(), lm.id, convert(datetime, '$flow.werkdatum$'), '$sub.tmoveruren$', 0, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', case when '$sub.chkoveruren$' = 'true' then 1 else 0 end, case when '$sub.chkconsignatie$' = 'true' then 1 else 0 end

from fv_looncomponent_mapping lm

    inner join fv_looncomponent lc

        on lm.looncomponent_id = lc.id

            and lm.veldindicatie = 'overuren 1en2'

            and substring('$sub.tmoveruren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement239()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie

set aantal = '$sub.tmoveruren$',

    omschrijving = '$sub.txtopm$',

    overurentvt = case when '$sub.chkoveruren$' = 'true' then 1 else 0 end,

    consignatie = case when '$sub.chkconsignatie$' = 'true' then 1 else 0 end

where id = '$sub.txtdeclido$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement240()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclido$' and substring(convert(nvarchar, aantal, 108), 1, 5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement241()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving, overurentvt, consignatie)

select newid(), lm.id,  convert(datetime,'$flow.werkdatum$'),  '$sub.tmoverextrauren$', 0, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', case when '$sub.chkoveruren$' = 'true' then 1 else 0 end, case when '$sub.chkconsignatie$' = 'true' then 1 else 0 end

from fv_looncomponent_mapping lm

    inner join fv_looncomponent lc

        on lm.looncomponent_id = lc.id

            and lm.id = case '0' when '' then null when 'null' then null else '0' end

            and substring('$sub.tmoverextrauren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement242()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie

set    looncomponent_mapping_id = case '0' when '' then null when 'null' then null else '0' end,

    aantal = '$sub.tmoverextrauren$',

    omschrijving = '$sub.txtopm$',

    overurentvt = case when '$sub.chkoveruren$' = 'true' then 1 else 0 end,

    consignatie = case when '$sub.chkconsignatie$' = 'true' then 1 else 0 end

where    id = '$sub.txtdeclidoe$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement243()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidoe$' and ((substring(convert(nvarchar,aantal,108),1,5)='00:00') or (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement244()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where werkdt = convert(datetime,'$flow.werkdatum$') and engineer_id = 0 and activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr590()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    convert(nvarchar, convert(datetime,'$flow.werkdatum$'), 105) as datum,
    '$flow.declaratie_change$' as ordernr,
    '$flow.orderoms$' as orderoms
from    fv_engineer
where    id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr591()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr,
    '' as description,
    d.aantal,
    d.id,
    d.omschrijving
from
    fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
where    d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and lm.veldindicatie = 'normaal'
    and d.activity_id is null
    and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr592()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr, '' as description, d.aantal,d.looncomponent_mapping_id, d.id
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'reis' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr593()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr, '' as description, d.aantal,d.looncomponent_mapping_id, d.id
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'over' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr594()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr, '' as description, d.aantal,d.looncomponent_mapping_id, d.id
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'over_extra' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement245Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'reis' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement246Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'over' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement247Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'over_extra' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement248()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms) select  newid(),  lm.id,  convert(datetime,'$flow.werkdatum$'),  '$sub.tmuren$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', '$sub.txtdesc$' from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.veldindicatie = 'normaal' and substring('$sub.tmuren$',12,5)<>'00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement249()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set aantal='$sub.tmuren$', rubricering='$sub.txtordrnr$', omschrijving = '$sub.txtopm$', orderoms='$sub.txtdesc$' where id = '$sub.txtdeclidn$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement250()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidn$' and substring(convert(nvarchar,aantal,108),1,5)='00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement251()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms) select  newid(),  lm.id,  convert(datetime,'$flow.werkdatum$'),  '$sub.tmurenr$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', '$sub.txtdesc$' from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.id = case '0' when '' then null when 'null' then null else '0' end and substring('$sub.tmurenr$',12,5)<>'00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement252()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set looncomponent_mapping_id = case '0' when '' then null when 'null' then null else '0' end, aantal='$sub.tmurenr$', rubricering='$sub.txtordrnr$', omschrijving = '$sub.txtopm$', orderoms='$sub.txtdesc$' where id = '$sub.txtdeclidr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement253()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidr$' and ((substring(convert(nvarchar,aantal,108),1,5)='00:00') or (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement254()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms) select  newid(),  lm.id,  convert(datetime,'$flow.werkdatum$'),  '$sub.tmureno$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', '$sub.txtdesc$' from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.id = case '$sub.cbolco$' when '' then null when 'null' then null else '$sub.cbolco$' end and substring('$sub.tmureno$',12,5)<>'00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement255()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set looncomponent_mapping_id = case '$sub.cbolco$' when '' then null when 'null' then null else '$sub.cbolco$' end, aantal='$sub.tmureno$', rubricering='$sub.txtordrnr$', omschrijving = '$sub.txtopm$', orderoms='$sub.txtdesc$' where id = '$sub.txtdeclido$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement256()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclido$' and ((substring(convert(nvarchar,aantal,108),1,5)='00:00') or (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement257()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms) select  newid(),  lm.id,  convert(datetime,'$flow.werkdatum$'),  '$sub.tmurenoe$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', '$sub.txtdesc$' from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.id = case '0' when '' then null when 'null' then null else '0' end and substring('$sub.tmurenoe$',12,5)<>'00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement258()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set looncomponent_mapping_id = case '0' when '' then null when 'null' then null else '0' end, aantal='$sub.tmurenoe$', rubricering='$sub.txtordrnr$', omschrijving = '$sub.txtopm$', orderoms='$sub.txtdesc$' where id = '$sub.txtdeclidoe$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement259()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidoe$' and ((substring(convert(nvarchar,aantal,108),1,5)='00:00') or (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement260()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where werkdt = convert(datetime,'$flow.werkdatum$') and engineer_id = 0 and rubricering = '$flow.declaratie$' and activity_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr597()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select message from fv_declaratie where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr598()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'normale uren' as type, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'normaal' and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr599()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie in ('reis', 'reis binnen werktijd') and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr600()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'overuren 1en2' and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr601()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'over' and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr710()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie in ('reis binnen werktijd') and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr602()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'normale uren' as type, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'normaal' and d.activity_id is null and d.rubricering = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr603()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'reis' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr604()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'over' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr605()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id where d.werkdt = convert(datetime,'$flow.werkdatum$') and d.engineer_id = 0 and lm.veldindicatie = 'overuren 1en2' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr717()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    lc.description,
    d.aantal,
    d.message
from    fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
    inner join fv_looncomponent lc
        on lm.looncomponent_id = lc.id
    inner join fv_activity a
        on d.activity_id = a.id
where    d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and lm.veldindicatie in ('reis binnen werktijd')
    and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement261()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, rubricering, omschrijving, engineer_id, radiostatus_id, isactive) select newid(), '$sub.txtord$', '$sub.txtoms$', id, 0, 1 from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement262()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set radiostatus_id=0, isactive=0 where id = '$sub.grdord.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement263Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, rubricering, omschrijving from fv_declaratie where werkdt is null and engineer_id = 0 and isactive=1 order by rubricering");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr609()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr611()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select datepart(hh,case when datediff(hh,startdt,verholpendt)>23 then '1900-01-01t00:00:00' else '1900-01-01t' + case when len(convert(nvarchar,(case when datediff(mi,startdt,verholpendt)<0 then 0 else (datediff(mi,startdt,verholpendt) + case when datediff(mi,startdt,verholpendt)%15 > 0 then 15 else 0 end) /60 end )))=1 then '0' else '' end + convert(nvarchar,(case when datediff(mi,startdt,verholpendt)<0 then 0 else (datediff(mi,startdt,verholpendt) + case when datediff(mi,startdt,verholpendt)%15 > 0 then 15 else 0 end) /60 end)) + 
':' + case when (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=0 then '00' when (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=15 then '15' when  (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=30 then '30' when  (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=45 then '45' else '00' end + ':00' end) as uren, datepart(mi,case when datediff(hh,startdt,verholpendt)>23 then '1900-01-01t00:00:00' else '1900-01-01t' + case when len(convert(nvarchar,(case when datediff(mi,startdt,verholpendt)<0 then 0 else (datediff(mi,startdt,verholpendt) + case when datediff(mi,startdt,verholpendt)%15 > 0 then 15 else 0 end) /60 end )))=1 then '0' else '' end + convert(nvarchar,(case when datediff(mi,startdt,verholpendt)<0 then 0 else (datediff(mi,startdt,verholpendt) + case when datediff(mi,startdt,verholpendt)%15 > 0 then 15 else 0 end) /60 end)) + 
':' + case when (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=0 then '00' when (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=15 then '15' when  (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=30 then '30' when  (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=45 then '45' else '00' end + ':00' end) as minuten, 0 as def from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr613()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$form.txtlabid$','00000000-0000-0000-0000-000000000000',1,-1,dateadd(mi,0,dateadd(hh,0,substring(convert(nvarchar,getdate(),20),1,10)+'t00:00:00')) from fv_engineer where id = 0 and '0'+':'+'0'<>'0:0'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr614()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$form.txtlabid$','00000000-0000-0000-0000-000000000000',2,-1,dateadd(mi,0,dateadd(hh,0,substring(convert(nvarchar,getdate(),20),1,10)+'t00:00:00')) from fv_engineer where id = 0 and '0'+':'+'0'<>'0:0'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr615()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$form.txtlabid$','00000000-0000-0000-0000-000000000000',id,-1,dateadd(mi,0,dateadd(hh,0,substring(convert(nvarchar,getdate(),20),1,10)+'t00:00:00')) from fv_labour_type where id = 0 and '0'+':'+'0'<>'0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr616()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id,rostartdt,coalesce(roenddt,getdate()) as nu from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and enddt is null and labourstatus_id=2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr617()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when len(convert(nvarchar,sum(datepart(hh,uren)) + (sum(datepart(mi,uren))/60)))=1 then '0' else '' end + convert(nvarchar,sum(datepart(hh,uren)) + (sum(datepart(mi,uren))/60)) + ':' + case when len(convert(nvarchar,(sum(datepart(mi,uren))%60)))=1 then '0' else '' end + convert(nvarchar,(sum(datepart(mi,uren))%60)) as total from         fv_labour_detail inner join fv_labour on fv_labour_detail.labour_id = fv_labour.id
where     fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and not fv_labour.enddt is null and fv_labour.engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr671()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_labour_type where external_id = '0708' and not exists (select uren from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.activity_id = '00000000-0000-0000-0000-000000000000' and enddt is null and labourstatus_id=2)
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement264Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_labour_type where isactive=1 and id > 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement265()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bezorgadres (id,street,name,name_2,zip,city,engineer_id,radiostatus_id,isactive ) select newid(), '$sub.txtstraat$', '$sub.txtnaam$', '$sub.txtnaam2$', '$sub.txtzip$', '$sub.txtplaats$', id, 0, 1 from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement266()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bezorgadres set radiostatus_id=0, isactive=0 where id = '$flow.del_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement267Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, name, name_2, street, city, zip from fv_tmp_bezorgadres where (engineer_id = 0 or engineer_id is null) and isactive=1 order by name");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement268()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set naam='$flow.naam3$',naam2='$flow.naam2$',straat='$flow.h_adres$',plaats='$flow.plaats$',postcode='$flow.postcode$',land='nl'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement269Component3539()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    id,
    eng,
    datum,
    dateadd(mi, sum(normaal_min), dateadd(hh, sum(normaal_uur), '1900-01-01t00:00:00')) as normaal,
    dateadd(mi, sum(over_min), dateadd(hh, sum(over_uur), '1900-01-01t00:00:00')) as over_uur,
    dateadd(mi, sum(reis_min), dateadd(hh, sum(reis_uur), '1900-01-01t00:00:00')) as reis
from (
    select
        fv_labour.id,
        fv_medewerker.description as eng,
        fv_labour.rostartdt as datum,
        case when fv_labour_detail.labour_type_id in (1) then sum(datepart(hh, fv_labour_detail.uren)) else 0 end as normaal_uur,
        case when fv_labour_detail.labour_type_id in (1) then sum(datepart(mi, fv_labour_detail.uren)) else 0 end as normaal_min,
        case when fv_labour_detail.labour_type_id in (3, 4, 5) then sum(datepart(hh, fv_labour_detail.uren)) else 0 end as over_uur,
        case when fv_labour_detail.labour_type_id in (3, 4, 5) then sum(datepart(mi, fv_labour_detail.uren)) else 0 end as over_min,
        case when fv_labour_detail.labour_type_id in (2, 10) then sum(datepart(hh, fv_labour_detail.uren)) else 0 end as reis_uur,
        case when fv_labour_detail.labour_type_id in (2, 10) then sum(datepart(mi, fv_labour_detail.uren)) else 0 end as reis_min
    from
        fv_labour
        inner join fv_medewerker
            on fv_labour.medewerker_id = fv_medewerker.id
        left outer join fv_labour_detail
            on fv_labour.id = fv_labour_detail.labour_id
    where    fv_labour.activity_id = '00000000-0000-0000-0000-000000000000'
    group by
        fv_labour.id,
        fv_labour.rostartdt,
        fv_medewerker.description,
        fv_labour_detail.labour_type_id
    ) a
group by a.id, a.eng, a.datum");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement270()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, startdt, rostartdt, enddt, roenddt, radiostatus_id, activity_id, labourstatus_id) select  '$flow.lab$', getdate(), getdate() , getdate(), getdate() ,  3, '00000000-0000-0000-0000-000000000000', 2 from fv_engineer where fv_engineer.id = '0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement271()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail where labour_id = '$sub.grduren.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement272()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour where id = '$sub.grduren.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement273Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    id,
    eng,
    datum,
    dateadd(mi, sum(normaal_min), dateadd(hh, sum(normaal_uur), '1900-01-01t00:00:00')) as normaal,
    dateadd(mi, sum(over_min), dateadd(hh, sum(over_uur), '1900-01-01t00:00:00')) as over_uur,
    dateadd(mi, sum(reis_min), dateadd(hh, sum(reis_uur), '1900-01-01t00:00:00')) as reis
from (
    select
        fv_labour.id,
        coalesce(fv_medewerker.description, fv_engineer.username) as eng,
        fv_labour.rostartdt as datum,
        case when fv_labour_detail.labour_type_id in (1) then sum(datepart(hh, fv_labour_detail.uren)) else 0 end as normaal_uur,
        case when fv_labour_detail.labour_type_id in (1) then sum(datepart(mi, fv_labour_detail.uren)) else 0 end as normaal_min,
        case when fv_labour_detail.labour_type_id in (3, 4, 5) then sum(datepart(hh, fv_labour_detail.uren)) else 0 end as over_uur,
        case when fv_labour_detail.labour_type_id in (3, 4, 5) then sum(datepart(mi, fv_labour_detail.uren)) else 0 end as over_min,
        case when fv_labour_detail.labour_type_id in (2, 10) then sum(datepart(hh, fv_labour_detail.uren)) else 0 end as reis_uur,
        case when fv_labour_detail.labour_type_id in (2, 10) then sum(datepart(mi, fv_labour_detail.uren)) else 0 end as reis_min
    from
        fv_labour
        left outer join fv_medewerker
            on fv_labour.medewerker_id = fv_medewerker.id
        left outer join fv_engineer
            on fv_labour.engineer_id = fv_engineer.id
        left outer join fv_labour_detail
            on fv_labour.id = fv_labour_detail.labour_id
    where
        fv_labour.activity_id in (select a.id from fv_activity a inner join fv_activity b on a.serviceorder_id = b.serviceorder_id where b.id = '00000000-0000-0000-0000-000000000000')
    group by
        fv_labour.id,
        fv_labour.rostartdt,
        coalesce(fv_medewerker.description, fv_engineer.username),
        fv_labour_detail.labour_type_id
    ) a
group by a.id, a.eng, a.datum
having sum(normaal_min) > 0
      or sum(normaal_uur) > 0
      or sum(over_min) > 0
      or sum(over_uur) > 0
      or sum(reis_min) > 0
      or sum(reis_uur) > 0
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr636()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end as werk, datepart(hh,case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as uren, datepart(mi,case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end) as minuten from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id = 1 where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr637()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ld.labour_type_id as id from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'
union
(select id from fv_labour_type where external_id = '0708' and not exists (select uren from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'))
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr641()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$flow.lab$' as id, fv_medewerker.description, fv_labour.rostartdt from fv_labour inner join fv_medewerker on fv_labour.medewerker_id = fv_medewerker.id where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr643()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end as uren
from fv_labour
    left outer join fv_labour_detail ld
        on ld.labour_id = fv_labour.id
            and ld.labour_type_id = 10
where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr644()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end as uren,
    ld.labour_type_id
from fv_labour
    left outer join fv_labour_detail ld
        on ld.labour_id = fv_labour.id
            and not ld.labour_type_id in (1, 2, 3, 10)
where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr707()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end as uren
from fv_labour
    left outer join fv_labour_detail ld
        on ld.labour_id = fv_labour.id
            and ld.labour_type_id = 2
where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr708()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end as uren
from fv_labour
    left outer join fv_labour_detail ld
        on ld.labour_id = fv_labour.id
            and ld.labour_type_id = 3
where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement274Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description
from    fv_labour_type
where    isactive = 1
    and not id in (1, 2, 3, 10)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement275()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set rostartdt = '$sub.dtlabour$', roenddt = '$sub.dtlabour$' where id = '$sub.txtlabid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement276()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail where labour_id = '$sub.txtlabid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement277()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$sub.txtlabid$', '00000000-0000-0000-0000-000000000000', 1, -1, '$flow.dttm1$'
from fv_engineer
where id = 0
    and substring('$sub.tm1$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement278()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$sub.txtlabid$', '00000000-0000-0000-0000-000000000000', 2, -1, '$flow.dttm2$'
from fv_engineer
where id = 0
    and substring('$sub.tm2$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement279()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$sub.txtlabid$', '00000000-0000-0000-0000-000000000000', 10, -1, '$flow.dttm10$'
from fv_engineer
where id = 0
    and substring('$sub.tm10$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement280()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$sub.txtlabid$', '00000000-0000-0000-0000-000000000000', 3, -1, '$flow.dttm3$'
from fv_engineer
where id = 0
    and substring('$sub.tm3$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement281()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
select newid(), '$sub.txtlabid$', '00000000-0000-0000-0000-000000000000', '$sub.cb4$', -1, '$flow.dttm4$'
from fv_engineer
where id = 0
    and substring('$sub.tm4$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr645()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select signature from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement282()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set signature = '$sub.signature$' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement283()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  case when len(convert(nvarchar(5), signature)) > 3 then 1
             else case when coalesce(fv_activity.ishandtekeningverplicht, 0) != 1
                       then 1
                       else 0
                  end
        end as isproceedbuttonenabled
from    fv_debrief
        inner join fv_activity on fv_debrief.activity_id = fv_activity.id
where   fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr646()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end as werk from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id = 1 where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr647()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ld.labour_type_id as id from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'
union
(select id from fv_labour_type where external_id = '0708' and not exists (select uren from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'))
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr649()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$flow.lab$' as id, rostartdt from fv_labour where id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr650()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end as uren from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id = 2 where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr651()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when ld.uren is null then '1900-01-01t00:00:00' else ld.uren end as uren from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement284Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_labour_type where isactive=1 and id > 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement285()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set rostartdt = '$sub.dtlabour$', roenddt='$sub.dtlabour$' where id = '$sub.txtlabid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement286()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail where labour_id = '$sub.txtlabid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement287()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$sub.txtlabid$','00000000-0000-0000-0000-000000000000',1,-1,substring('$sub.dtlabour$',1,11) + substring('$sub.tm1$',12,8) from fv_engineer where id = 0 and substring('$sub.tm1$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement288()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$sub.txtlabid$','00000000-0000-0000-0000-000000000000',2,-1,substring('$sub.dtlabour$',1,11) + substring('$sub.tm2$',12,8) from fv_engineer where id = 0 and substring('$sub.tm2$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement289()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$sub.txtlabid$','00000000-0000-0000-0000-000000000000',id,-1,substring('$sub.dtlabour$',1,11) + substring('$sub.tm3$',12,8) from fv_labour_type where id = 0 and substring('$sub.tm3$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr679()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'true' as def from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement290Component3594()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select distinct fv_customer.id,
    fv_customer.external_id,
    fv_customer.customername as oms,
    fv_customer.customer_main_id,
    fv_customer_main.name,
    fv_customer_main.name2
from    fv_customer
    inner join fv_customer_main
        on fv_customer.customer_main_id = fv_customer_main.id
    left outer join fv_serviceobject
        on fv_customer.id = fv_serviceobject.customer_id
where    len(fv_customer.external_id) = case when '$sub.chmain$' = 'true' then 8 else len(fv_customer.external_id) end
    and fv_customer.isactive = 1
    and fv_customer.external_id like '$sub.txtfp$%'
    and fv_customer.customername like '%$sub.txtname$%'
    and fv_serviceobject.description like '$sub.txtequipzoek$%'
    and '0' = '1'
order by fv_customer.external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement291()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitytype_id= 0 where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement292()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set capability_id= case when '0'='' then null else '0' end, productgroep_id= case when '0'='' then null else '0' end where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement293()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set customer_main_id=$sub.grdfp3.klant$, customer_id = $sub.grdfp3.id$, functieplaatsnaam = '$sub.grdfp3.name$', description = '$form.txtdescnw$', opdrachtnummer = '$form.txtopdrnr$', name='$sub.grdfp3.klantname$', name_2='$sub.grdfp3.klantname2$' where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr660()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select substring('$flow.sb$',1,8) + '.docx' as sb, '$flow.sb$' as fp  from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr677()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(fv_customer.notes, cm.notes) as responsetijd,
        coalesce(fv_customer.responsetoelichting, cm.responsetoelichting) as responsetoelichting,
        coalesce(fv_customer_addition.klantcontacten,
                 parentcustomer.klantcontacten,
                 parentparentcustomer.klantcontacten) as klantcontacten,
        coalesce(fv_customer_addition.internecontacten,
                 parentcustomer.internecontacten,
                 parentparentcustomer.internecontacten) as internecontacten,
        coalesce(fv_customer_addition.onderaannemers,
                 parentcustomer.onderaannemers,
                 parentparentcustomer.onderaannemers) as onderaannemers
from    fv_customer
        left outer join fv_customer cm on cm.external_id = substring(fv_customer.external_id, 1, 8)
        left outer join fv_customer_addition on fv_customer.id = fv_customer_addition.customer_id
        left outer join fv_customer_addition parentcustomer on parentcustomer.customer_id = fv_customer.parent_customer_id
        left outer join fv_customer_addition parentparentcustomer on parentparentcustomer.customer_id in ( select   cp.parent_customer_id
                                                                                                           from     fv_customer cp
                                                                                                           where    cp.id = fv_customer.parent_customer_id )
where   fv_customer.external_id = '$flow.sb$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement294()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement295()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement296()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestelling (id,sonummer,straat,naam,naam2,huisnummer,postcode,plaats,land) select '$flow.bestel_id$','$form.txtso$',street,name,name_2,housenumber,zip,city,'nl' from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr670()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$sub.grdzoeklev4.totaal$' as totaal from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement297Component3661()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description, external_id + '
' + description + '
' + coalesce(straat,'') + ' ' + coalesce(huisnummer,'') + '
' + coalesce(postcode,'') + ' ' + coalesce(plaats,'') + '
tel: ' + coalesce(telefoon,'') + '
fax: ' + coalesce(fax,'') as totaal from fv_supplier where isactive = 1 and description like '%'+'$sub.txtzoek$' + '%' and 0=1

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement298()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activity where planstartdt < dateadd(dd,-1,getdate()) and activitytype_id in (select id from fv_activitytype where billable=0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement299()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour where not activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement300()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail where not activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement301()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activitystatus where not activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement302()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief where not activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement303()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debriefoperations where not activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement304()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where not activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement305()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_customer_addition where not customer_id in (select customer_id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr678()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$flow.sbdet$' as opm from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr684()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select       'ordernr: ' + coalesce(fv_activity.serviceordernumber,'') + '
' + 'werkbon: ' + coalesce(convert(nvarchar,fv_activity.sub_id),'') + '
' + 'datum: ' + convert(nvarchar,getdate(),105) + '

' + 'omschrijving: 
' + coalesce (fv_activity.description, '') as samenvatting
from         fv_activity
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr685()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select      fv_debrief.notes
from         fv_debrief 
where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr737()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  ds.rostatusdt as enddt
from fv_activity a
left outer join  fv_debrief_status ds on ds.external_id = a.external_id and ds.sub_id = a.sub_id
and ds.activitystatustype_id in (59, 150, 157)
where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr686()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select extra_notes from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr687()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select       'ordernr: ' + coalesce(fv_activity.serviceordernumber,'') + '
' + 'werkbon: ' + coalesce(convert(nvarchar,fv_activity.sub_id),'') + '
' + 'datum: ' + convert(nvarchar,getdate(),105) + '

' + 'omschrijving: 
' + coalesce (fv_activity.description, '') as samenvatting
from         fv_activity
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr688()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select      fv_debrief.notes
from         fv_debrief 
where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr689()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr690()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activitystatus where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr691()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_serviceorder where id not in (select serviceorder_id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr692()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select serviceordernumber, sub_id from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr694()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  a.notes,
        a.description,
        a.samenvatting
from    fv_activity a
where   a.id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr695()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(bestel_autorisatie,0) as bestel_autorisatie,
    coalesce(ontvangst_autorisatie,0) as ontvangst_autorisatie
from    fv_engineer
where    id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement306()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_orderrequest");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement307()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_orderrequest");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement308()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement309()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr696()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    getdate() as nu,
    dateadd(minute, 1, getdate()) as morgen,
    '1900-01-01 08:00' as acht_uur,
    '0' as def,
    newid() as new_act_id,
    convert(nvarchar(4000),fv_debrief.notes)
from    fv_debrief
where    fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'
union
select    getdate() as nu,
    dateadd(minute, 1, getdate()) as morgen,
    '1900-01-01 08:00' as acht_uur,
    '0' as def,
    newid() as new_act_id,
    null
from fv_engineer
where id=0 and not exists(select * from    fv_debrief
where    fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement310Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_cancelreason.id,
    fv_cancelreason.description
from    fv_cancelreason
where    fv_cancelreason.isactive = 1
order by fv_cancelreason.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement311()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief 
set restduur=(0*60)+0,
send_email = null
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement312()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -4, '$flow.newstatusdt$'), 0, 150, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement313()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -3, '$flow.newstatusdt$'), 0, 120, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement314()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    activitystatustype_id = 120,
    maxstatusdt = dateadd(second, -3, '$flow.newstatusdt$')
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement315()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, herpland_door_naam, nlsfb_id)
select    '$flow.newactivity_id$', '$flow.newstatusdt$', 152, external_id, sub_id, engineer_id, '$flow.datum$',
    dateadd(minute, datediff(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, 0, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    case when len('$flow.opmerking2$') > 999 then substring('$flow.opmerking2$', 0, 999) else '$flow.opmerking2$' end, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, '$app.username$', nlsfb_id
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement316()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -2, '$flow.newstatusdt$'), 0, 30, '$flow.newactivity_id$'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement317()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
select    newid(), 0, '$flow.newstatusdt$', 0, 152, '$flow.newactivity_id$', '$flow.opmerking$',
    case when '$flow.reden$'='' then null else '$flow.reden$' end
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement318()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_photo (id, activity_id, description, filename, radiostatus_id, isactive, path)
select newid(), '$flow.newactivity_id$', description, filename, 2, isactive, path from fv_debrief_photo where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement319()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_emaillist set activity_id = '$flow.newactivity_id$' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr701()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'true' as def, customer_main_id from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement320Component3976()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_customer.id,
    fv_customer.external_id,
    coalesce(fv_customer.customername + '
', '') + coalesce(fv_customer.street, '') + ' ' + coalesce(fv_customer.city, '') as opm,
    fv_customer.customer_main_id,
    fv_customer_main.name,
    fv_customer_main.name2,
    fv_customer.customername as oms
from fv_customer
    inner join fv_customer_main
        on fv_customer.customer_main_id=fv_customer_main.id
where    len(fv_customer.external_id) = case when '$sub.chmain$'='true' then 8 else len(fv_customer.external_id) end
    and fv_customer.isactive=1
    and fv_customer.external_id like '$sub.txtfp$'+'%'
    and fv_customer.customername like '%$sub.txtname$%'
    and fv_customer.city like '$sub.txtcity$'+'%'
    and fv_customer.street like '$sub.txtstreet$'+'%'
    and '0'='1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement321()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    activitytype_id = 0,
--activitytype_id = case when '$form.cbtype$'='' then null else  '$form.cbtype$' end,
    capability_id = case when '0'='' then null else '0' end,
    productgroep_id = case when '0'='' then null else '0' end,
    customer_main_id = $sub.grdfp2.klant$,
    customer_id = $sub.grdfp2.id$,
    functieplaatsnaam = '$sub.grdfp2.name$',
    description = '$form.txtdescnw$',
    opdrachtnummer = '$form.txtopdrnr$',
    name='$sub.grdfp2.klantname$',
    name_2='$sub.grdfp2.klantname2$'
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement322()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  case when opdrachtnummer is null then 1
             else 0
        end as isopdrachtnummerleeg
from    fv_activity
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr702()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_debrief.signaturedt, getdate()) as nu, fv_debrief.signature, 1 as def, fv_debrief.opdrachtnummer, fv_debrief.name_signature, coalesce(fv_debrief.email, fv_contact.email) as email, fv_debrief.send_specificatie
from fv_activity
inner join fv_debrief on fv_activity.id = fv_debrief.activity_id
left outer join fv_contact on fv_activity.contact_id = fv_contact.id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement323()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update fv_debrief
set    email = '$form.txtemail$'
    ,send_email = 1
    ,send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end
    ,opdrachtnummer = '$form.txtopdrachtnr$'
    ,name_signature = '$form.txtparaafnaam$'
    ,signaturedt = substring('$form.datsig$',1,11) + substring('$form.timesig$',12,8)
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement324()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update fv_debrief
set    email = '$form.txtemail$'
    ,send_email = 1
    ,send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end
    ,opdrachtnummer = '$form.txtopdrachtnr$'
    ,name_signature = '$form.txtparaafnaam$'
    ,signaturedt = substring('$form.datsig$',1,11) + substring('$form.timesig$',12,8)
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement325()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -4, '$flow.newstatusdt$'), 0, 150, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement326()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -3, '$flow.newstatusdt$'), 0, 120, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement327()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    activitystatustype_id = 120,
    maxstatusdt = dateadd(second, -3, '$flow.newstatusdt$')
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement328()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id)
select    '$flow.newactivity_id$', '$flow.newstatusdt$', 152, external_id, sub_id, engineer_id, '$flow.datum$',
    dateadd(minute, datediff(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, 0, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    case when len('$flow.opmerking2$') > 999 then substring('$flow.opmerking2$', 0, 999) else '$flow.opmerking2$' end, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement329()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -2, '$flow.newstatusdt$'), 0, 30, '$flow.newactivity_id$'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement330()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
select    newid(), 0, '$flow.newstatusdt$', 0, 152, '$flow.newactivity_id$', '$flow.opmerking$',
    case when '$flow.reden$'='' then null else '$flow.reden$' end
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement331()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  sum(case when coalesce(message, '') = ''
                      and coalesce(keurregistratie, '0') != '0' then 0
                 else 1
            end) as verstuurd
from    fv_declaratie
where   werkdt = convert(datetime, '$flow.werkdatum$')
        and engineer_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr711()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    convert(nvarchar, convert(datetime, '$flow.werkdatum$'), 105) as datum,
    '$flow.declaratie_change$' as ordernr,
    '$flow.orderoms$' as description
from    fv_engineer
where    id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr712()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr,
    d.aantal,
    d.id,
    d.omschrijving
from    fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
where    d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and lm.veldindicatie = 'normaal'
    and d.activity_id is null
    and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr713()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id,
    d.reisurentvt
from fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
where d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and d.activity_id is null
    and lm.veldindicatie = 'reis'
    and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr714()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id
from fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
where d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and d.activity_id is null
    and lm.veldindicatie = 'overuren 1en2'
    and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr715()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id,
    d.overurentvt,

    d.consignatie
from fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
where d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and d.activity_id is null
    and lm.veldindicatie = 'over'
    and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr716()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id
from fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
where d.werkdt = convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = 0
    and d.activity_id is null
    and lm.veldindicatie = 'reis binnen werktijd'
    and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement332Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    lm.id,
    l.description
from    fv_looncomponent l
    inner join fv_looncomponent_mapping lm
        on lm.looncomponent_id = l.id
where    lm.veldindicatie = 'reis'
    and lm.isactive = 1
    and l.isactive = 1
order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement333Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    lm.id,
    l.description
from    fv_looncomponent l
    inner join fv_looncomponent_mapping lm
        on lm.looncomponent_id = l.id
where    lm.veldindicatie = 'over'
    and lm.isactive = 1
    and l.isactive = 1
order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement334()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert  into fv_declaratie ( id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms )
select  newid(), lm.id, convert(datetime, '$flow.werkdatum$'), '$sub.tmuren$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', '$sub.txtdesc$'
from    fv_looncomponent_mapping lm
    inner join fv_looncomponent lc 
        on lm.looncomponent_id = lc.id
        and lm.veldindicatie = 'normaal'
        and substring('$sub.tmuren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement335()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set aantal = '$sub.tmuren$', rubricering='$sub.txtordrnr$', omschrijving = '$sub.txtopm$', orderoms = '$sub.txtdesc$' where id = '$sub.txtdeclidn$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement336()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidn$' and substring(convert(nvarchar,aantal,108),1,5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement337()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert  into fv_declaratie (   id,   looncomponent_mapping_id,   werkdt,   aantal,   engineer_id,   prestatiesoort,   rubricering,   omschrijving,   orderoms )
select  newid(), lm.id, convert(datetime, '$flow.werkdatum$'), '$sub.tmreisuren$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', '$sub.txtdesc$'         
from    fv_looncomponent_mapping lm
    inner join fv_looncomponent lc 
        on lm.looncomponent_id = lc.id
        and lm.veldindicatie = 'reis binnen werktijd'
        and substring('$sub.tmreisuren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement338()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set aantal = '$sub.tmreisuren$', rubricering='$sub.txtordrnr$', omschrijving = '$sub.txtopm$', orderoms='$sub.txtdesc$' where id = '$sub.txtdeclidnr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement339()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidnr$' and substring(convert(nvarchar,aantal,108),1,5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement340()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert  into fv_declaratie ( id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms, reisurentvt )
select  newid(), lm.id, convert(datetime, '$flow.werkdatum$'), '$sub.tmoverigeuren$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', '$sub.txtdesc$', case when '$sub.chkreisuren$' = 'true' then 1 else 0 end
    from    fv_looncomponent_mapping lm
        inner join fv_looncomponent lc 
            on lm.looncomponent_id = lc.id
            and lm.id = case when '0' = '' then null else 0+0    end
            and substring('$sub.tmoverigeuren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement341()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie
set looncomponent_mapping_id = case when '0' = '' then null else 0+0 end, 
    aantal = '$sub.tmoverigeuren$', 
    rubricering = '$sub.txtordrnr$', 
    omschrijving = '$sub.txtopm$', 
     
    reisurentvt = case when '$sub.chkreisuren$' = 'true' then 1 else 0 end, 
    orderoms = '$sub.txtdesc$'
where id = '$sub.txtdeclidr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement342()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidr$' and ((substring(convert(nvarchar,aantal,108),1,5)='00:00') or (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement343()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, overurentvt, consignatie, orderoms) 
select  newid(),  lm.id,  convert(datetime, '$flow.werkdatum$'),  '$sub.tmoveruren$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$',case when '$sub.chkoveruren$' = 'true' then 1 else 0 end, case when '$sub.chkconsignatie$' = 'true' then 1 else 0 end, '$sub.txtdesc$' 
from fv_looncomponent_mapping lm 
    inner join fv_looncomponent lc 
        on lm.looncomponent_id = lc.id 
            and lm.veldindicatie = 'overuren 1en2' 
            and substring('$sub.tmoveruren$',12,5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement344()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie 
set aantal='$sub.tmoveruren$', 
    omschrijving = '$sub.txtopm$', 
    rubricering='$sub.txtordrnr$', 
    overurentvt = case when '$sub.chkoveruren$' = 'true' then 1 else 0 end,
    consignatie = case when '$sub.chkconsignatie$' = 'true' then 1 else 0 end,
    orderoms='$sub.txtdesc$' 
where id = '$sub.txtdeclido$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement345()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclido$' and ((substring(convert(nvarchar,aantal,108),1,5)='00:00') or (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement346()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms, overurentvt, consignatie) 
select  newid(),  lm.id,  convert(datetime,'$flow.werkdatum$'),  '$sub.tmoverextrauren$', 0, lc.prestatiesoort, '$sub.txtordrnr$', '$sub.txtopm$', '$sub.txtdesc$', case when '$sub.chkoveruren$' = 'true' then 1 else 0 end, case when '$sub.chkconsignatie$' = 'true' then 1 else 0 end from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.id = case when '0'='' then null else 0+0 end and substring('$sub.tmoverextrauren$',12,5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement347()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie 
set looncomponent_mapping_id = case when '0'='' then null else 0+0 end, 
    aantal='$sub.tmoverextrauren$', 
    rubricering='$sub.txtordrnr$', 
    omschrijving = '$sub.txtopm$', 
    

    overurentvt = case when '$sub.chkoveruren$' = 'true' then 1 else 0 end,

    consignatie = case when '$sub.chkconsignatie$' = 'true' then 1 else 0 end,
    orderoms = '$sub.txtdesc$'
 where id = '$sub.txtdeclidoe$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement348()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtdeclidoe$' and ((substring(convert(nvarchar,aantal,108),1,5)='00:00') or (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement349()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where werkdt = convert(datetime,'$flow.werkdatum$') and engineer_id = 0 and rubricering = '$flow.declaratie$' and activity_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement350()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt, rostatusdt, engineer_id ,radiostatus_id)
select newid(), id, external_id, sub_id, 50, getdate(), '$flow.startdt$', 0, 0 from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and 50 not in (select activitystatustype_id from fv_debrief_status where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr718()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(ds.rostatusdt, d.startdt) as startdt, getdate() as now
from fv_debrief d
left outer join fv_activity a on d.activity_id = a.id
left outer join  fv_debrief_status ds on ds.external_id = a.external_id and ds.sub_id = a.sub_id
and ds.activitystatustype_id = 50
where d.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr726()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus
set alterdstatusdt = '$flow.startdt$',
    radiostatus_id = 0
where  0 = 1
and activity_id = '00000000-0000-0000-0000-000000000000'
and activitystatustype_id = 50");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr727()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus
set alterdstatusdt = '29-8-2012 21:55:00',
    radiostatus_id = 0
where  0+0 = 0
and activity_id = '00000000-0000-0000-0000-000000000000'
and activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr728()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief
set startdt = '$flow.startdt$'
where  0 = 1
and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement351()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  convert(nvarchar, coalesce(min(ds.statusdt),
                                   dateadd(year, 1, getdate())), 126) as debrief_statusdt
from    fv_debrief_status ds
        inner join fv_activity a on a.external_id = ds.external_id
                                    and a.sub_id = ds.sub_id
                                    and a.activitystatustype_id not in ( 120, 125, 60, 62 )
where   ds.activitystatustype_id = 59
        and not exists ( select 0
                         from   fv_activitystatus acts
                         where  acts.activity_id = a.id
                                and acts.activitystatustype_id in ( 120, 125, 60, 62 ) )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement352()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete  from fv_tmp_werkbonmateriaal
where   not exists ( select *
                     from   fv_activity a
                     where  a.activitystatustype_id = 144
                            and a.sub_id = fv_tmp_werkbonmateriaal.werkbonid )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement353()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_param_mobile where description in('desktop photo path','mobile photo path','camera working folder','dispatch photo path')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement354()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_param_mobile (
    id,
    senttoclient,
    notes,
    description,
    paramvalue
) values ( 
    /* id - int */ 1,
    /* senttoclient - int */ 1,
    /* notes - varchar(255) */ null,
    /* description - varchar(50) */ 'desktop photo path',
    /* paramvalue - varchar(250) */ 'c:\tensing\fieldvision prod\media\' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement355()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_param_mobile (
    id,
    senttoclient,
    notes,
    description,
    paramvalue
) values ( 
    /* id - int */ 2,
    /* senttoclient - int */ 1,
    /* notes - varchar(255) */ null,
    /* description - varchar(50) */ 'camera working folder',
    /* paramvalue - varchar(250) */ '%userprofile%\my pictures\' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement356()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_param_mobile (
    id,
    senttoclient,
    notes,
    description,
    paramvalue
) values ( 
    /* id - int */ 3,
    /* senttoclient - int */ 1,
    /* notes - varchar(255) */ null,
    /* description - varchar(50) */ 'mobile photo path',
    /* paramvalue - varchar(250) */ 'c:\tensing\fieldvision prod\media\' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement357()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_param_mobile (
    id,
    senttoclient,
    notes,
    description,
    paramvalue
) values ( 
    /* id - int */ 4,
    /* senttoclient - int */ 1,
    /* notes - varchar(255) */ null,
    /* description - varchar(50) */ 'dispatch photo path',
    /* paramvalue - varchar(250) */ 'd:\win32app\fieldvision\media\' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement358()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as aantal
from information_schema.columns
where table_name = 'fv_debrief_status'
and column_name = 'rostatusdt'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement359()
        {
            var statement = MacroScope.Factory.CreateStatement(@"alter table fv_debrief_status add rostatusdt datetime");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement360()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_commfield where fieldname = 'rostatusdt' and tableid = 52");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement361()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (fieldid, fieldname, fieldtype, tableid) values (10, 'rostatusdt', 135, 52)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement362()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as aantal
from fv_commtable
where tablename = 'fv_param_mobile'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement363()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_commfield where tableid = 56;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement364()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_commtable where tableid = 56;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement365()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commtable (tableid, tablename, sendwithactivity, sendwithserviceorder, sendwithcustomer, client2server, sendwithlocation) values (56, n'fv_param_mobile', null, null, null, null, null);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement366()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (tableid, fieldid, fieldname, fieldtype) values (56, 0, n'id', 3);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement367()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (tableid, fieldid, fieldname, fieldtype) values (56, 1, n'notes', 200);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement368()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (tableid, fieldid, fieldname, fieldtype) values (56, 2, n'description', 200);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement369()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (tableid, fieldid, fieldname, fieldtype) values (56, 3, n'paramvalue', 200);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement370()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as aantal
from fv_commtable
where tablename = 'fv_version_clientdb'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement371()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_commfield where tableid = 57;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement372()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_commtable where tableid = 57;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement373()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commtable (tableid, tablename, sendwithactivity, sendwithserviceorder, sendwithcustomer, client2server, sendwithlocation) values (57, n'fv_version_clientdb', null, null, null, null, null);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement374()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (tableid, fieldid, fieldname, fieldtype) values (57, 0, n'id', 3);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement375()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (tableid, fieldid, fieldname, fieldtype) values (57, 1, n'clientdb_date', 135);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement376()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (tableid, fieldid, fieldname, fieldtype) values (57, 2, n'clientdb_version', 202);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement377()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_version_clientdb (id,clientdb_version,clientdb_date) values (     /* id - int */ 1,/* clientdb_version - nvarchar(100) */ n'werkbon 2010 fase 1',    /* clientdb_date - datetime */ '2012-4-24' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement378()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as aantal
from information_schema.columns
where table_name = 'fv_paraafstatus'
and column_name = 'canescape'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement379()
        {
            var statement = MacroScope.Factory.CreateStatement(@"alter table fv_paraafstatus add canescape int default 0;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement380()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_paraafstatus set external_id = 'klantakkoord', description = 'klant accoord voor gezien' where id = 1;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement381()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_paraafstatus set external_id = 'klantnietakkoord', description = 'klant niet accoord', canescape = 1 where id = 2;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement382()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_paraafstatus set external_id = 'klantnietaanwezig', description = 'niemand aanwezig om te tekenen', canescape = 1 where id = 3;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement383()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_commfield (tableid, fieldid, fieldname, fieldtype) values (34, 9, n'canescape', 3);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement384()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_version_clientdb (id,clientdb_version,clientdb_date) values (     /* id - int */ 3,/* clientdb_version - nvarchar(100) */ n'werkbon 2010 fase 2',    /* clientdb_date - datetime */ '2012-5-22' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement385()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update
    fv_activity
set 
    activitystatustype_id = 30
where
    activitystatustype_id = 59
    and not exists ( select
                        0 as debrief_statusdt
                     from
                        fv_debrief_status ds
                        inner join fv_activity a1
                            on a1.external_id = ds.external_id
                               and a1.sub_id = ds.sub_id
                               and a1.id = fv_activity.id
                     where
                        ds.activitystatustype_id = 59 )
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr719()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  case when coalesce(isafmeldbonvoorklantverplicht, 0) = 1 then 1 else 0 end as isafmeldbonvoorklantverplicht,
        case when coalesce(isafmeldbonvoorklantverplicht, 0) = 2 then 1 else 0 end as isafmeldbonvoorklantoptie,
        case coalesce(isantidaterentoegestaan, 1) when 0 then 1 else 0 end as isantidaterenniettoegestaan,
        coalesce(isequipmentscannenverplicht, 0) as isequipmentscannenverplicht,
        case when coalesce(ishandtekeningverplicht, 0) = 1 then 1 else 0 end as ishandtekeningverplicht,
        case when coalesce(ishandtekeningverplicht, 0) = 2 then 1 else 0 end as ishandtekeningoptie,
        coalesce(isnlsfbcodeverplicht, 0) as isnlsfbcodeverplicht,
        coalesce(isurenspecificatieverplicht, 0) as isurenspecificatieverplicht
from    fv_activity
where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement386Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  l1.emailto
from    fv_emaillist l1
where   l1.id in ( select   min(id)
                   from     fv_emaillist l2
                   where    l1.activity_id = l2.activity_id
                            and l1.emailto = l2.emailto )
        and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr720()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select       'ordernr: ' + coalesce(fv_activity.serviceordernumber,'') + '
' + 'werkbon: ' + coalesce(convert(nvarchar,fv_activity.sub_id),'') + '
' + 'datum: ' + convert(nvarchar,getdate(),105) + '

' + 'omschrijving: 
' + coalesce (fv_activity.description, '') as samenvatting
from         fv_activity
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr721()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select      fv_debrief.notes
from         fv_debrief 
where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr723()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    getdate() as nu,
    dateadd(day, 1, getdate()) as morgen,
    '1900-01-01 08:00' as acht_uur,
    '0' as def,
    newid() as new_act_id,
    convert(nvarchar(4000),fv_debrief.notes)
from    fv_debrief
where    fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'
union
select    getdate() as nu,
    dateadd(day, 1, getdate()) as morgen,
    '1900-01-01 08:00' as acht_uur,
    '0' as def,
    newid() as new_act_id,
    null
from fv_engineer
where id=0 and not exists(select * from    fv_debrief
where    fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr738()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  fv_medewerker.description from fv_debrief inner join fv_medewerker on fv_debrief.vervolg_medewerker_id = fv_medewerker.id where fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement387Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_cancelreason.id,
    fv_cancelreason.description
from    fv_cancelreason
where    fv_cancelreason.isactive = 1
order by fv_cancelreason.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement388()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select e.id from fv_debrief d
inner join fv_medewerker m on d.vervolg_medewerker_id = m.id
inner join fv_engineer e on m.external_id = e.external_id
where    d.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement389()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief 
set restduur=(0*60)+0,
send_email = null
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement390()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -4, '$flow.newstatusdt$'), 0, 150, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement391()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -3, '$flow.newstatusdt$'), 0, 120, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement392()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    activitystatustype_id = 120,
    maxstatusdt = dateadd(second, -3, '$flow.newstatusdt$')
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement393()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, herpland_door_naam, nlsfb_id)
select    '$flow.newactivity_id$', '$flow.newstatusdt$', 30, external_id, sub_id, 0, '$flow.datum$',
    dateadd(minute, datediff(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, 0, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    case when len('$flow.opmerking2$') > 999 then substring('$flow.opmerking2$', 0, 999) else '$flow.opmerking2$' end, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, '$app.username$', nlsfb_id
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement394()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -2, '$flow.newstatusdt$'), 0, 30, '$flow.newactivity_id$'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement395()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
select    newid(), 0, '$flow.newstatusdt$', 0, 152, '$flow.newactivity_id$', '$flow.opmerking$',
    case when '$flow.reden$'='' then null else '$flow.reden$' end
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement396()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when count(quantity)=0 then '0' else '1' end as materiaalingevoerd from fv_materialmutation where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr730()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr731()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sub_id from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr732()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(bestel_autorisatie,0) as bestel_autorisatie, coalesce(ontvangst_autorisatie,0) as ontvangst_autorisatie from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr733()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_activity.serviceordernumber,'') as sonr
from fv_activity 
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement397()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_werkbonmateriaal
where exists (select * from fv_activity where fv_activity.sub_id = fv_tmp_werkbonmateriaal.werkbonid
and fv_activity.id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement398Component4178()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  fv_tmp_werkbonmateriaal.id,
        fv_tmp_werkbonmateriaal.external_id,
        werkbonid,
        fabrikant,
        leverancier,
        aantal,
        artikelnummer,
        coalesce(artikelnummer, '') + '/' + coalesce(omschrijving, '') + '/'
        + coalesce(leverancier, '') as omschrijving,
        '' as empty,
        0 as is_mutated
from    fv_tmp_werkbonmateriaal
        inner join fv_activity on fv_activity.sub_id = fv_tmp_werkbonmateriaal.werkbonid
where not exists (select * from fv_materialmutation where fv_activity.id = fv_materialmutation.activity_id
and fv_materialmutation.wbm_id = fv_tmp_werkbonmateriaal.external_id)
and fv_activity.id = '00000000-0000-0000-0000-000000000000'
union
select  fv_tmp_werkbonmateriaal.id,
        fv_tmp_werkbonmateriaal.external_id,
        werkbonid,
        fabrikant,
        leverancier,
        aantal,
        artikelnummer,
        coalesce(artikelnummer, '') + '/' + coalesce(omschrijving, '') + '/'
        + coalesce(leverancier, '') as omschrijving,
        '' as empty,
        1
from    fv_tmp_werkbonmateriaal
        inner join fv_activity on fv_activity.sub_id = fv_tmp_werkbonmateriaal.werkbonid
where exists (select * from fv_materialmutation where fv_activity.id = fv_materialmutation.activity_id
and fv_materialmutation.wbm_id = fv_tmp_werkbonmateriaal.external_id)
and fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement399Component4187()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     coalesce(bestelnr,'') + '/' + coalesce(description,'') + '/' + coalesce(supplier_name,'') as omsch, quantity, type, id,'' as empty
from         fv_materialmutation
where     type in ('d','o','a') and activity_id = '00000000-0000-0000-0000-000000000000'
and material_id is null
union
select     coalesce(fv_material.bestelnr,'') + '/' + coalesce(fv_materialmutation.description,'') + '/' + coalesce(fv_supplier.description,'') as omsch, fv_materialmutation.quantity, type, fv_materialmutation.id,'' as empty
from         fv_materialmutation inner join
                      fv_material on fv_materialmutation.material_id = fv_material.id left outer join
                      fv_supplier on fv_material.supplier_id = fv_supplier.id
where     (fv_materialmutation.type = 'a') and  activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement400()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,radiostatus_id,type,supplier_name, wbm_id, quantity, bestelnr, description, purchaseorderpositie) select '$flow.mat_id$','00000000-0000-0000-0000-000000000000',getdate(),-1,'a', leverancier, external_id,     aantal, artikelnummer, omschrijving, purchaseorder from fv_tmp_werkbonmateriaal where id = '$flow.prog_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement401()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement402()
        {
            var statement = MacroScope.Factory.CreateStatement(@"drop table fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement403()
        {
            var statement = MacroScope.Factory.CreateStatement(@"create table fv_tmp_bestelling(balie int null , huisnummer nvarchar(50) null , id uniqueidentifier rowguidcol constraint pk_fv_tmp_bestelling primary key , land nvarchar(50) null , leveranciernummer nvarchar(50) null , naam nvarchar(50) null , naam2 nvarchar(50) null , onderaanneming int null , plaats nvarchar(50) null , postcode nvarchar(50) null , sonummer nvarchar(50) null , straat nvarchar(50) null , werkbon int null )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement404()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement405()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestelling (id,sonummer,werkbon,straat,naam,naam2,huisnummer,postcode,plaats,land) select '$flow.bestel_id$',serviceordernumber,sub_id,street,name,name_2,housenumber,zip,city,'nl' from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement406()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement407()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr734()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id as deb_photo_id, 
    notes as deb_photo_notes
from fv_debrief_photo
where id = '$flow.photoid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr736()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_photo set radiostatus_id = 0 
where activity_id = '00000000-0000-0000-0000-000000000000'
and radiostatus_id = -1 and isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement408Component4194()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    fv_debrief_photo.id,
    coalesce(filename, '') as filename,
    coalesce(fv_param_mobile.paramvalue, '\program files\fvdnet\media\') + coalesce(path, '') as filepath,
    fv_debrief_photo.notes as photo_remark,
    coalesce(fv_debrief_photo.radiostatus_id,-1) as radiostatus_id
from
    fv_debrief_photo
    left outer join fv_param_mobile
        on fv_param_mobile.description = 'mobile photo path'
where 
    activity_id = '00000000-0000-0000-0000-000000000000'
    and isactive = 1


");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement409()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_photo set isactive = 0, radiostatus_id = -1 where id = '$flow.photoid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement410()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_photo set notes = '$sub.txtphotoremark$', radiostatus_id = -1 where id = '$flow.photoid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement411()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_debrief
set    vervolg_medewerker_id = $sub.grdzoekmdw.id$
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement412Component4240()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    m.id,
    m.external_id,
    m.description
from    fv_medewerker m
inner join fv_engineer e on m.external_id = e.external_id
where    m.isactive = 1 and e.isactive = 1
    and m.description like '$sub.txtzoek$' + '%'
    and '0' = '1'
order by m.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement413()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as isfunctiehersteld from fv_debrief_status
where activity_id in ( select a.id from fv_activity a
inner join fv_activity b on
a.external_id = b.external_id
and a.sub_id = b.sub_id
where b.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement414()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select   planner_id
  from    fv_activity
  where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr739()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    getdate() as nu,
    fv_activity.id
from    fv_activity
where    fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr740()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(ontvangst_autorisatie, 0) as ontvangst_autorisatie
from    fv_engineer
where    id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr741()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    getdate() as nu,
    dateadd(minute, 1, getdate()) as morgen,
    '1900-01-01 08:00' as acht_uur,
    '0' as def,
    newid() as new_act_id,
    convert(nvarchar(4000),fv_debrief.notes)
from    fv_debrief
where    fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'
union
select    getdate() as nu,
    dateadd(minute, 1, getdate()) as morgen,
    '1900-01-01 08:00' as acht_uur,
    '0' as def,
    newid() as new_act_id,
    null
from fv_engineer
where id=0 and not exists(select * from    fv_debrief
where    fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement415()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -4, '$flow.newstatusdt$'), 0, 150, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement416()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -3, '$flow.newstatusdt$'), 0, 120, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement417()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    activitystatustype_id = 120,
    maxstatusdt = dateadd(second, -3, '$flow.newstatusdt$')
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement418()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, herpland_door_naam, nlsfb_id)
select    '$flow.newactivity_id$', '$flow.newstatusdt$', 0, external_id, sub_id, engineer_id, '$flow.datum$',
    dateadd(minute, datediff(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, 0, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    case when len('$flow.opmerking2$') > 999 then substring('$flow.opmerking2$', 0, 999) else '$flow.opmerking2$' end, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, '$app.username$', nlsfb_id
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement419()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -2, '$flow.newstatusdt$'), 0, 30, '$flow.newactivity_id$'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement420()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
select    newid(), 0, '$flow.newstatusdt$', 0, 0, '$flow.newactivity_id$', '$flow.opmerking$',
    case when '$flow.reden$'='' then null else '$flow.reden$' end
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement421()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_photo (id, activity_id, description, filename, radiostatus_id, isactive, path)
select newid(), '$flow.newactivity_id$', description, filename, 2, isactive, path from fv_debrief_photo where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement422()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_emaillist set activity_id = '$flow.newactivity_id$' where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement423()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from   fv_debrief_status
where         exists (select * from fv_activity a where a.external_id = fv_debrief_status.external_id
                                    and a.sub_id = fv_debrief_status.sub_id
                                    and a.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 50 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement424()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update  fv_debrief_status set activity_id = '$flow.newactivity_id$', activitystatustype_id = 0
where         exists (select * from fv_activity a where a.external_id = fv_debrief_status.external_id
                                    and a.sub_id = fv_debrief_status.sub_id
                                    and a.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr742()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select getdate() as nu, id, 0 as def from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement425()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief 
set restduur=(0*60)+0,
send_email = null
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement426()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from   fv_debrief_status
where         exists (select * from fv_activity a where a.external_id = fv_debrief_status.external_id
                                    and a.sub_id = fv_debrief_status.sub_id
                                    and a.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 50 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement427()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update  fv_debrief_status set activitystatustype_id = 157, radiostatus_id = 0
where         exists (select * from fv_activity a where a.external_id = fv_debrief_status.external_id
                                    and a.sub_id = fv_debrief_status.sub_id
                                    and a.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement428()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  case when opdrachtnummer is null then 1
             else 0
        end as isopdrachtnummerleeg
from    fv_activity
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr743()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_debrief.signaturedt, getdate()) as nu, fv_debrief.signature, 1 as def, fv_debrief.opdrachtnummer, fv_debrief.name_signature, coalesce(fv_debrief.email, fv_contact.email) as email, fv_debrief.send_specificatie
from fv_activity
inner join fv_debrief on fv_activity.id = fv_debrief.activity_id
left outer join fv_contact on fv_activity.contact_id = fv_contact.id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement429()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update fv_debrief
set    email = '$form.txtemail$'
    ,send_email = 1
    ,send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end
    ,opdrachtnummer = '$form.txtopdrachtnr$'
    ,name_signature = '$form.txtparaafnaam$'
    ,signaturedt = substring('$form.datsig$',1,11) + substring('$form.timesig$',12,8)
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement430()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update fv_debrief
set    email = '$form.txtemail$'
    ,send_email = 1
    ,send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end
    ,opdrachtnummer = '$form.txtopdrachtnr$'
    ,name_signature = '$form.txtparaafnaam$'
    ,signaturedt = substring('$form.datsig$',1,11) + substring('$form.timesig$',12,8)
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement431()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -4, '$flow.newstatusdt$'), 0, 150, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement432()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -3, '$flow.newstatusdt$'), 0, 120, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement433()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    activitystatustype_id = 120,
    maxstatusdt = dateadd(second, -3, '$flow.newstatusdt$')
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement434()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id)
select    '$flow.newactivity_id$', '$flow.newstatusdt$', 159, external_id, sub_id, 0, '$flow.datum$',
    dateadd(minute, datediff(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, 0, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    case when len('$flow.opmerking2$') > 999 then substring('$flow.opmerking2$', 0, 999) else '$flow.opmerking2$' end, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement435()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -2, '$flow.newstatusdt$'), 0, 30, '$flow.newactivity_id$'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement436()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
select    newid(), 0, '$flow.newstatusdt$', 0, 159, '$flow.newactivity_id$', '$flow.opmerking$',
    case when '$flow.reden$'='' then null else '$flow.reden$' end
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement437()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  case when opdrachtnummer is null then 1
             else 0
        end as isopdrachtnummerleeg
from    fv_activity
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatementQueryNr744()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select coalesce(fv_debrief.signaturedt, getdate()) as nu, fv_debrief.signature, 1 as def, fv_debrief.opdrachtnummer, fv_debrief.name_signature, coalesce(fv_debrief.email, fv_contact.email) as email, fv_debrief.send_specificatie
from fv_activity
inner join fv_debrief on fv_activity.id = fv_debrief.activity_id
left outer join fv_contact on fv_activity.contact_id = fv_contact.id
where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement438()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update fv_debrief
set    email = '$form.txtemail$'
    ,send_email = 1
    ,send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end
    ,opdrachtnummer = '$form.txtopdrachtnr$'
    ,name_signature = '$form.txtparaafnaam$'
    ,signaturedt = substring('$form.datsig$',1,11) + substring('$form.timesig$',12,8)
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement439()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update fv_debrief
set    email = '$form.txtemail$'
    ,send_email = 1
    ,send_specificatie = case when '$form.chspec$' = 'true' then 1 else 0 end
    ,opdrachtnummer = '$form.txtopdrachtnr$'
    ,name_signature = '$form.txtparaafnaam$'
    ,verholpen = 0
    ,verholpendt = '29-8-2012 21:55:00'
    ,signaturedt = substring('$form.datsig$',1,11) + substring('$form.timesig$',12,8)
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement440()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -4, '$flow.newstatusdt$'), 0, 150, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement441()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -3, '$flow.newstatusdt$'), 0, 120, '00000000-0000-0000-0000-000000000000'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement442()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    activitystatustype_id = 120,
    maxstatusdt = dateadd(second, -3, '$flow.newstatusdt$')
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement443()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id)
select    '$flow.newactivity_id$', '$flow.newstatusdt$', 157, external_id, sub_id, engineer_id, '$flow.datum$',
    dateadd(minute, datediff(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, 0, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    case when len('$flow.opmerking2$') > 999 then substring('$flow.opmerking2$', 0, 999) else '$flow.opmerking2$' end, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement444()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
select    newid(), 0, dateadd(second, -2, '$flow.newstatusdt$'), 0, 30, '$flow.newactivity_id$'
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement445()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
select    newid(), 0, '$flow.newstatusdt$', 0, 157, '$flow.newactivity_id$', '$flow.opmerking$',
    case when '$flow.reden$'='' then null else '$flow.reden$' end
from fv_engineer
where  id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement446()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from   fv_debrief_status
where         exists (select * from fv_activity a where a.external_id = fv_debrief_status.external_id
                                    and a.sub_id = fv_debrief_status.sub_id
                                    and a.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 50 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement447()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update  fv_debrief_status set activity_id = '$flow.newactivity_id$', activitystatustype_id = 157
where         exists (select * from fv_activity a where a.external_id = fv_debrief_status.external_id
                                    and a.sub_id = fv_debrief_status.sub_id
                                    and a.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 59 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement448()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement449()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement450()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement451()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement452()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement453()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement454()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'gewerkte uren detail' then 1 else 0 end
from fv_engineer
where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement455()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 't' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement456()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement457()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement458()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement459()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'b' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement460()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'go' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement461()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement462()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement463()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement464()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement465()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement466()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and activitytype_id = 2 and '0' = 'r'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement467()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and '0' = 'r'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement468()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement469()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_activity where id = '00000000-0000-0000-0000-000000000000' and coalesce(serviceordernumber,'')=''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement470()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'u' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement471()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'e' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement472()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'm' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement473()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 't' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement474()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement475()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and activitytype_id = 2 and '0' = 'a'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement476()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and '0' = 'a'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement477()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement478()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement479()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'f' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement480()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement481()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'b' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement482()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement483()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement484()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement485()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'f' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement486()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement487()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement488()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'u' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement489()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'e' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement490()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'm' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement491()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 't' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement492()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement493()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and activitytype_id = 2 and '0' = 'a'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement494()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and '0' = 'a'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement495()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 't' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement496()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement497()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement498()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement499()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'b' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement500()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'go' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement501()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'gewerkte uren detail' then 1 else 0 end
from fv_engineer
where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement502()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement503()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement504()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement505()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement506()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement507()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and activitytype_id = 2 and '0' = 'r'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement508()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and '0' = 'r'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement509()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement510()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement511()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement512()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement513()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement514()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement515()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement516()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement517()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'f' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement518()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement519()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'b' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement520()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement521()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement522()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement523()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'f' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement524()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement525()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement526()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'u' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement527()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'e' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement528()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'm' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement529()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 't' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement530()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement531()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and '0' = 'a'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement532()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '00000000-0000-0000-0000-000000000000' and '0' = 'f'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement533()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'gewerkte uren detail' then 1 else 0 end
from fv_engineer
where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement534()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 't' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement535()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement536()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement537()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement538()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'b' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement539()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'go' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement540()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement541()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement542()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(ishandtekeningverplicht, 0) as ishandtekeningverplicht
from    fv_activity
where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement543()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(isafmeldbonvoorklantverplicht, 0) as isafmeldbonvoorklantverplicht
from    fv_activity
where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement544()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 0+0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement545()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement546()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(ishandtekeningverplicht, 0) as ishandtekeningverplicht
from    fv_activity
where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement547()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(isafmeldbonvoorklantverplicht, 0) as isafmeldbonvoorklantverplicht
from    fv_activity
where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement548()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement549()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement550()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement551()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement552()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'f' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement553()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement554()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'b' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement555()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement556()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement557()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement558()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'f' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement559()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement560()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement561()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement562()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'p' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement563()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement564()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  coalesce(isafmeldbonvoorklantverplicht, 0) as isafmeldbonvoorklantverplicht
from    fv_activity
where   id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement565()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select activitystatustype_id from fv_activity where id = '00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement566()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'r' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement567()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'b' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement568()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'o' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement569()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement570()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement571()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'f' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement572()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement573()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'd' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement574()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when '0' = 'a' then 1 else 0 end from fv_engineer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }[TestMethod]
        public void TestSelectStatement575()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as aantal from fv_version_clientdb where clientdb_date >= '2012-5-22'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
    }
}