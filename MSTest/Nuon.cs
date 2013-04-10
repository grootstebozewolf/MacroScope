using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using MacroScope;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class Nuon
    {
        [TestMethod]
        public void TestSelectStatementQueryNr454()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(c.contacttitle + ' ', '') + coalesce(c.contactfirstname + ' ', '') + coalesce(c.contactsurname + ' ', '' ) + coalesce(c.bedrijfsnaam1, '') as name,
    ltrim(coalesce(a.street,'') + ' ' + coalesce(a.housenumber,'') + ' ' + coalesce(a.housenumbertext,'') + ' ' + coalesce(a.zip,'') + ' ' + coalesce(a.city,'')) as a_adress,
    a.phone,
    ltrim(str(s.totaal_algemeen,10,2)) as total_open,
    a.notes as cancelnotes,
    ltrim(coalesce(c.street,'') + ' ' + coalesce(c.housenumber,'') + ' ' + coalesce(c.housenumbertext,'') + ' ' + coalesce(c.city,'')) as c_adres
from    fv_activity a
    inner join fv_serviceobject s
        on a.serviceobject_id=s.id
    left outer join fv_customer c
        on c.id = 0
where    a.id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr461()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, getdate(), 50, 0
 from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr461Output()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, getdate(), 50, 0
 from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            Assert.AreEqual(@"INSERT INTO fv_activitystatus(id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
SELECT newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), 50, 0
FROM fv_activity
WHERE id = '00000000-0000-0000-0000-000000000000'", stringifier.ToSql());
        }
        [TestMethod]
        public void TestSelectStatementQueryNr462()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour
(id, activity_id, engineer_id, startdt, rostartdt, labourstatus_id, radiostatus_id)
select
newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), getdate(), 2, -1 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and not exists (select id from fv_labour where enddt is null and labourstatus_id = 2 and activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr488()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=50 where id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr665()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief
set    voldaan_contant = 0,
    voldaan_pin = 0,
    voldaan_totaal = 0,
    verifydt = getdate()
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr666()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_financial where activity_id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2491()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select h.id,h.contactdt as contactdt, h.contacttype as contacttype, substring(h.notes,0,50) as notes from  fv_contacthistorie h where h.customer_id = 0 order by h.contactdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr416()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_activity
set    activitystatustype_id = 0,
    maxstatusdt = getdate(),
    notes = ''
where    fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr418()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id,engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id,cancelnotes,cancelreason_id)
select newid(),4, getdate(),0, 0, '00000000-0000-0000-0000-000000000000','','0'
from fv_engineer
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr527()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select activitystatustype_id from fv_cancelreason where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr621()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set notes = '', marker = null where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr622()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr662()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set radiostatus_id = 0, enddt=getdate(), roenddt=getdate() where enddt is null and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr664()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_financial where activity_id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr685()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set voldaan_contant=0, voldaan_pin=0,voldaan_totaal=0,radiostatus_id= case when 0 = 150 then 0 else -1 end, cancelreason_id=0, notes = case when 0 = 150 then 'klant is niet bezocht, graag meesturen met volgend pakket.' else '' end where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr687()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, radiostatus_id, activity_id,engineer_id) select newid(), -1,id,4 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and not exists (select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr754()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_agenda
set    activitystatustype_id = 0
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_cancelreason where isactive = 1 and external_id not like 'a%'  and external_id not like 'k%'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr508()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select h.contactdt as contactdt, h.contacttype as contacttype, h.contactaction as action, h.contactstatus as status, h.notes as notes, h.attachment as attachment from  fv_contacthistorie h where h.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr463()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(c.contacttitle + ' ', '') + coalesce(c.contactfirstname + ' ', '') + coalesce(c.contactsurname + ' ', '' ) + coalesce(c.bedrijfsnaam1, '') as name,
    ltrim(str(s.totaal_algemeen,10,2)) as total_open,
    c.external_id as cusext,
    s.external_id as serext
from    fv_activity a
    inner join fv_serviceobject s on a.serviceobject_id=s.id
    left outer join fv_customer c on c.id = 0
where    a.id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2509()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_financial.id, substring(fv_financial.description,1,3) as description, fv_financial.incassostap as aanmaan, ltrim(str(fv_financial.factuurbedrag,10,2)) as factuurbedrag, ltrim(str(fv_financial.openstaand,10,2)) as openstaand, 
                      fv_financial.factuurdt
from         fv_financial
where fv_financial.serviceobject_id = 0 and coalesce(fv_financial.openstaand,0)<>0
order by fv_financial.factuurdt");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr510()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  ltrim(str(s.totaal_direct_opeisbaar, 10, 2)) as direct,
        ltrim(str(s.totaal_overig, 10, 2)) as overig,
        case when s.id is null then fv_agenda.totaal_algemeen
             else ltrim(str(s.totaal_algemeen, 10, 2))
        end as totaal,
        s.betaalwijze as betaalwijze,
        s.aanmaanmethode as aanmaan,
        st.description as type,
        case when s.id is null then fv_agenda.wijzigingsdt
             else s.wijzigingsdt
        end as laatste,
        case when s.id is null
             then coalesce(fv_agenda.name + ' ', '')
                  + coalesce(fv_agenda.leverings_adres, '')
             else coalesce(a.name, c.bedrijfsnaam1) + ' '
                  + ltrim(coalesce(a.street, '') + ' '
                          + coalesce(a.housenumber, '') + ' '
                          + coalesce(a.housenumbertext, '') + ' '
                          + coalesce(a.zip, '') + ' ' + coalesce(a.city, ''))
        end as adres,
        fv_soortpand.description as soortpand,
        coalesce(s.external_id, '') as cr,
        c.external_id as zpnummer,
        c.bankaccount,
        c.collday,
        c.collectionstrategy,
        c.creditrating,
        s.has_openamountothers
from    fv_agenda
        left outer join fv_activity a on fv_agenda.activity_id = a.id
        left outer join fv_serviceobject s on a.serviceobject_id = s.id
        left outer join fv_serviceobjecttype st on s.serviceobjecttype_id = st.id
        left outer join fv_customer c on c.id = 0
        left outer join fv_soortpand on coalesce(c.soortpand_id, s.soortpand_id) = fv_soortpand.id
where   fv_agenda.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_telwerk.id,
    fv_telwerk.telwerk_nr as external_id,
    fv_meter.metertype as description,
    fv_telwerk.telwerktype as tw,
    fv_telwerk.stand,
    fv_opnamesoort.notes
from    fv_meter
inner join fv_telwerk
    on fv_meter.id = fv_telwerk.meter_id
left outer join fv_opnamesoort
    on fv_telwerk.opnamesoort = fv_opnamesoort.description
where    fv_meter.serviceobject_id = 0
order by fv_meter.metertype, fv_telwerk.opnamedt desc, fv_telwerk.telwerktype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr511()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select f.factuurnummer as factuurnummer, f.documentnummer as documentnummer, f.factuurdt as docdt, f.vervaldt as vervaldt, f.description as omschrijving, f.incassostap as aanmaanfase, ltrim(str(f.factuurbedrag,10,2)) as bedrag, ltrim(str(f.openstaand,10,2)) as openstaand, f.notes as producten from fv_financial f where f.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3089()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_financial.id, fv_financial.factuurnummer, fv_financial.betaaldt, ltrim(str(fv_financial.betaalbedrag,10,2)) as betaalbedrag, fv_financial.betaalwijze as description
from         fv_financial inner join fv_financial f on f.id = 0 and f.factuurnummer = fv_financial.factuurnummer and fv_financial.documentnummer = f.documentnummer and (coalesce (fv_financial.betaalbedrag, 0) > 0) and not fv_financial.vereffeningsdocument is null and fv_financial.serviceobject_id = 0 order by fv_financial.betaaldt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr466()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(a.name,c.bedrijfsnaam1) as name,
    ltrim(str(s.totaal_algemeen,10,2)) as total_open,
    c.external_id as cusext,
    s.external_id as serext
from    fv_activity a
    inner join fv_serviceobject s
        on a.serviceobject_id=s.id
    left outer join fv_customer c
        on c.id = 0
where    a.id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2530()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_financial.id, fv_financial.factuurnummer, fv_financial.betaaldt, ltrim(str(fv_financial.betaalbedrag,10,2)) as betaalbedrag, substring(fv_financial.betaalwijze,1,4)  as description
from         fv_financial
where     fv_financial.vereffeningsdocument is not null and fv_financial.serviceobject_id = 0 and not fv_financial.betaalbedrag=0 and not fv_financial.factuurbedrag=0 order by fv_financial.betaaldt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr512()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select f.documentnummer as documentnummer, f.factuurnummer as factuurnummer, f.factuurdt as factuurdt, f.vervaldt as vervaldt, f.description as notasoort,ltrim(str(f.factuurbedrag,10,2)) as factuurbedrag, f.betaaldt as betaaldt,ltrim(str(f.betaalbedrag,10,2)) as betaalbedrag, 
ltrim(str(f.openstaand,10,2)) as openstaand, f.betaalwijze as betaalwijze from fv_financial f where f.id = 0
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr469()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(a.name,c.bedrijfsnaam1) as name,
    ltrim(str(s.totaal_algemeen,10,2)) as total_open,
    c.external_id as cusext,
    s.external_id as serext
from    fv_activity a
    inner join fv_serviceobject s on a.serviceobject_id=s.id
    left outer join fv_customer c on c.id = 0
where    a.id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2555()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_telwerk.id, fv_telwerk.telwerk_nr, fv_meter.metertype as description, fv_telwerk.telwerktype as tw, fv_telwerk.stand, fv_opnamesoort.notes
from         fv_meter inner join
                      fv_telwerk on fv_meter.id = fv_telwerk.meter_id left outer join fv_opnamesoort on fv_telwerk.opnamesoort = fv_opnamesoort.description
where fv_meter.serviceobject_id = 0
order by fv_meter.metertype, fv_telwerk.opnamedt desc, fv_telwerk.telwerktype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr475()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_telwerk.telwerk_nr as external_id,fv_meter.metertype as description, fv_telwerk.telwerktype as tw, fv_telwerk.opnamedt, fv_telwerk.stand, 
                      fv_telwerk.opnamesoort as opnamesoort, fv_telwerk.opnamereden
from         fv_meter inner join
                      fv_telwerk on fv_meter.id = fv_telwerk.meter_id
where fv_telwerk.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2569()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_meter.id, fv_meter.metertype as description, fv_meter.aansluitingstatus as st, fv_afsluitreden.description as reden, fv_afsluitwijze.description as wijze, 
                      fv_afsluitbaarheid.description as afsluitbaarheid
from         fv_meter left outer join
                      fv_afsluitreden on fv_meter.afsluitreden_id = fv_afsluitreden.id left outer join
                      fv_afsluitwijze on fv_meter.afsluitwijze_id = fv_afsluitwijze.id left outer join
                      fv_afsluitbaarheid on fv_meter.afsluitbaarheid_id = fv_afsluitbaarheid.id
where fv_meter.serviceobject_id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr476()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_serviceobject.external_id, fv_meter.external_id as installatienr, fv_meter.metertype as description, fv_meter.opdrachtstatus as opdrst, 
                     fv_meter.aansluitingstatus as aansluitingstatus, fv_afsluitreden.description as reden, fv_afsluitwijze.description as wijze, 
                      fv_afsluitbaarheid.description as afsluitbaarheid
from         fv_meter inner join
                      fv_serviceobject on fv_meter.serviceobject_id = fv_serviceobject.id left outer join
                      fv_afsluitwijze on fv_meter.afsluitwijze_id = fv_afsluitwijze.id left outer join
                      fv_afsluitbaarheid on fv_meter.afsluitbaarheid_id = fv_afsluitbaarheid.id left outer join
                      fv_afsluitreden on fv_meter.afsluitreden_id = fv_afsluitreden.id
where fv_meter.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr472()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
                coalesce(a.name,c.bedrijfsnaam1) as name,
                ltrim(coalesce(a.street,'') + ' ' + coalesce(a.housenumber,'') + ' ' + coalesce(a.housenumbertext,'') + ' ' + coalesce(a.zip,'') + ' ' + coalesce(a.city,'')) as a_adress, '' as c_adres,
                a.phone,                ltrim(str(s.totaal_algemeen,10,2)) as total_open                from fv_activity a inner join fv_serviceobject s on a.serviceobject_id=s.id left outer join fv_customer c on c.id = 0
        where 
                a.id='00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr473()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id from fv_customer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr474()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id from fv_serviceobject where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2590()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select h.id,h.contactdt as contactdt, h.contacttype as contacttype, substring(h.notes,0,50) as notes from  fv_contacthistorie h where h.customer_id = 0 order by h.contactdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr486()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, getdate(), 55, 0
 from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr487()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=55 where id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr489()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, radiostatus_id, activity_id, engineer_id, verifydt)
select    newid(), -1, id, 4, getdate()
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000'
    and not exists (select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr661()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_financial where betaald_bedrag = 0 and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement2()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set voldaan_contant = 0, voldaan_pin = 0, voldaan_totaal = 0 + 0, contant_afgedragen = 0, pin_afgedragen = 0, actief = 1 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr490()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
                coalesce(a.name,c.bedrijfsnaam1) as name,
                ltrim(coalesce(a.street,'') + ' ' + coalesce(a.housenumber,'') + ' ' + coalesce(a.housenumbertext,'') + ' ' + coalesce(a.zip,'') + ' ' + coalesce(a.city,'')) as a_adress, '' as c_adres,
                a.phone,
            ltrim(str(s.totaal_algemeen,10,2)) as total_open,
'0' as def
from fv_activity a inner join fv_serviceobject s on a.serviceobject_id=s.id left outer join fv_customer c on c.id = 0
        where 
                a.id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr491()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id from fv_customer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr492()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id from fv_serviceobject where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr504()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_financial (id,activity_id,radiostatus_id,financial_id,serviceobject_id,betaald_bedrag,engineer_id,marker) select newid(), '00000000-0000-0000-0000-000000000000',-1,id,0,0,4,case when coalesce(fv_financial.openstaand,0)<0 then 1 else 0 end
from         fv_financial where fv_financial.serviceobject_id = 0 and coalesce(fv_financial.openstaand,0)>0 and fv_financial.id not in (select financial_id from fv_debrief_financial where activity_id='00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3388()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_financial.id, substring(fv_financial.description,1,3) as description, fv_financial.incassostap as aanmaan, ltrim(str(fv_financial.factuurbedrag,10,2)) as factuurbedrag, ltrim(str(fv_financial.openstaand,10,2)) as openstaand, 
                      fv_financial.factuurdt
from         fv_financial
where fv_financial.serviceobject_id = 0 and coalesce(fv_financial.openstaand,0)<>0
order by fv_financial.factuurdt");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr505()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    a.name,
    ltrim(coalesce(a.street,'') + ' ' + coalesce(a.housenumber,'') + ' ' + coalesce(a.housenumbertext,'') + ' ' + coalesce(a.zip,'') + ' ' + coalesce(a.city,'')) as a_adress,
    '' as c_adres,
    a.phone,
    ltrim(str(s.totaal_algemeen,10,2)) as total_open,
    ltrim(str(voldaan_totaal,10,2)) as voldaan_totaal,
    ltrim(str(s.totaal_algemeen - voldaan_totaal,10,2)) as rest_saldo
from    fv_activity a
    inner join fv_serviceobject s
        on a.serviceobject_id = s.id
    left outer join fv_debrief
        on a.id = fv_debrief.activity_id 
where    a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr515()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     ltrim(str(sum(fv_debrief_financial.betaald_bedrag),10,2)) as totaal
from         fv_financial inner join
                      fv_debrief_financial on fv_financial.id = fv_debrief_financial.financial_id and fv_debrief_financial.activity_id = '00000000-0000-0000-0000-000000000000'
where fv_debrief_financial.marker=0 and coalesce(fv_financial.openstaand,0)<>0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement12()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_financial set marker = case when marker = 0 then 1 else 0 end, betaald_bedrag = 0 where id = '$form.grdfinancial324.id$' and not exists (select fv_financial.id from fv_financial inner join fv_debrief_financial on fv_debrief_financial.financial_id = fv_financial.id and fv_debrief_financial.id='$form.grdfinancial324.id$' and fv_financial.openstaand <0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2649()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_financial.factuurdt, ltrim(str(fv_financial.openstaand,10,2)) as openstaand, substring(fv_financial.description,1,4) as description, ltrim(str(fv_debrief_financial.betaald_bedrag,10,2)) as betaald_bedrag, case when fv_debrief_financial.marker=0 then '' else 'n' end as marker, 
                      fv_debrief_financial.id
from         fv_financial inner join
                      fv_debrief_financial on fv_financial.id = fv_debrief_financial.financial_id and fv_debrief_financial.activity_id = '00000000-0000-0000-0000-000000000000'
where fv_financial.serviceobject_id = 0 and coalesce(fv_financial.openstaand,0)>0
order by fv_financial.factuurdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr495()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
                coalesce(a.name,c.bedrijfsnaam1) as name,
                ltrim(coalesce(a.street,'') + ' ' + coalesce(a.housenumber,'') + ' ' + coalesce(a.housenumbertext,'') + ' ' + coalesce(a.zip,'') + ' ' + coalesce(a.city,'')) as a_adress, '' as c_adres,
                a.phone,
                ltrim(str(s.totaal_algemeen,10,2)) as total_open,
getdate() as now            from fv_activity a inner join fv_serviceobject s on a.serviceobject_id=s.id left outer join fv_customer c on c.id = 0
        where 
                a.id='00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr496()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_customer.external_id + ' / ' + fv_serviceobject.external_id as zp from fv_customer inner join fv_serviceobject on fv_customer.id = 0 and fv_serviceobject.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr497()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
                ltrim(coalesce(a.street,'') + ' ' + coalesce(a.housenumber,'') + ' ' + coalesce(a.housenumbertext,'') + ' ' + coalesce(a.zip,'') + ' ' + coalesce(a.city,'')) as a_adress    from fv_activity a 
        where 
                a.id='00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr498()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, getdate(), 60, 0
 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and '' <> 'actiebinnend'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr499()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=60 where id = '00000000-0000-0000-0000-000000000000' and '' <> 'actiebinnend'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr500()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief
set voldaandt = getdate(), afhandelingstype_id = 1
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr643()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_financial where betaald_bedrag = 0 and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr654()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and  activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr761()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_agenda
set    activitystatustype_id = 60
    ,status = 'gereed'
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2661()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_financial.factuurdt, ltrim(str(fv_debrief_financial.betaald_bedrag,10,2)) as openstaand, fv_financial.id
from         fv_financial inner join
                      fv_debrief_financial on fv_financial.id = fv_debrief_financial.financial_id and fv_debrief_financial.betaald_bedrag > 0
where fv_debrief_financial.activity_id = '00000000-0000-0000-0000-000000000000'
order by fv_financial.factuurdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr513()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when 1 = 1 then 0 else null end as openb, case when 1 = 1 then 0 else null end as voorstel,  null as gewijzigd from fv_engineer where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr514()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_debrief.voldaan_totaal - sum(fv_debrief_financial.betaald_bedrag) as totaal
from         fv_financial inner join
                      fv_debrief_financial on fv_financial.id = fv_debrief_financial.financial_id  inner join fv_debrief on fv_debrief.activity_id = fv_debrief_financial.activity_id and fv_debrief.activity_id = '00000000-0000-0000-0000-000000000000'
where fv_debrief_financial.marker=0 and coalesce(fv_financial.openstaand,0)>0 and fv_financial.serviceobject_id = 0
group by fv_debrief.voldaan_totaal
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2669()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_financial.factuurdt, ltrim(str(fv_financial.openstaand,10,2)) as openstaand, substring(fv_financial.description,1,5) as description, ltrim(str(coalesce(fv_debrief_financial.betaald_bedrag,0),10,2)) as betaald_bedrag, case when fv_debrief_financial.marker=0 then '' else 'v' end as marker, 
                      fv_debrief_financial.id
from         fv_financial inner join
                      fv_debrief_financial on fv_financial.id = fv_debrief_financial.financial_id and fv_debrief_financial.activity_id = '00000000-0000-0000-0000-000000000000'
where fv_financial.serviceobject_id = 0 and coalesce(fv_financial.openstaand,0)>0 and fv_debrief_financial.marker=0
order by fv_financial.factuurdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement13()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_financial set betaald_bedrag = replace('$form.txtgewijzigd$', ',' , '.') where id                                                     = '$form.grdfinancial326.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr516()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
                coalesce(a.name,c.bedrijfsnaam1) as name,
                ltrim(coalesce(a.street,'') + ' ' + coalesce(a.housenumber,'') + ' ' + coalesce(a.housenumbertext,'') + ' ' + coalesce(a.zip,'') + ' ' + coalesce(a.city,'')) as a_adress, '' as c_adres,
                a.phone,
                ltrim(str(s.totaal_algemeen,10,2)) as total_open,
getdate() as now            from fv_activity a inner join fv_serviceobject s on a.serviceobject_id=s.id left outer join fv_customer c on c.id = 0
        where 
                a.id='00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr517()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_customer.external_id + ' / ' + fv_serviceobject.external_id as zp from fv_customer inner join fv_serviceobject on fv_customer.id = 0 and fv_serviceobject.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr518()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
                ltrim(coalesce(a.street,'') + ' ' + coalesce(a.housenumber,'') + ' ' + coalesce(a.housenumbertext,'') + ' ' + coalesce(a.zip,'') + ' ' + coalesce(a.city,'')) as a_adress    from fv_activity a 
        where 
                a.id='00000000-0000-0000-0000-000000000000'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr519()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     ltrim(str(sum(fv_debrief_financial.betaald_bedrag),10,2)) as total, getdate() as now
from         fv_financial inner join
                      fv_debrief_financial on fv_financial.id = fv_debrief_financial.financial_id and fv_debrief_financial.betaald_bedrag > 0
where fv_debrief_financial.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr526()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set voldaandt = getdate() where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent10()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_financial.factuurdt, ltrim(str(fv_debrief_financial.betaald_bedrag,10,2)) as openstaand, fv_financial.id
from         fv_financial inner join
                      fv_debrief_financial on fv_financial.id = fv_debrief_financial.financial_id and fv_debrief_financial.betaald_bedrag > 0
where fv_debrief_financial.activity_id = '00000000-0000-0000-0000-000000000000'
order by fv_financial.factuurdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr520()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     ltrim(str(s.totaal_algemeen - sum(coalesce(fv_debrief_financial.betaald_bedrag,0)),10,2)) as total_open, 'false' as vervolg, getdate()+1 as now
                from fv_activity a inner join fv_debrief_financial on a.id = '00000000-0000-0000-0000-000000000000' and fv_debrief_financial.activity_id = a.id inner join fv_serviceobject s on s.id = a.serviceobject_id group by s.totaal_algemeen
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr521()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select    newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), 59, 0
from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and '' != 'actiebinnend'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr522()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_activity
set    maxstatusdt = getdate(),
    activitystatustype_id = 59
where    id = '00000000-0000-0000-0000-000000000000'
    and '' != 'actiebinnend'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr523()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief
set    notes = '$form.txtnotes328$'
        + case when '$form.cb_vervolg$' = 'false' then N'
vervolgafspraak op ' + convert(nvarchar(10), convert(datetime, '03/09/2012 14:18:00'), 105) + N' tussen '
            + convert(nvarchar(5), convert(datetime, '03/09/2012 14:18:00'), 114) + N' en '
            + convert(nvarchar(5), convert(datetime, '03/09/2012 14:18:00'), 114) + N' uur.'
        else '' end,
    afhandelingstype_id = 1
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr540()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_financial where betaald_bedrag = 0 and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr609()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activity (id, planstartdt, planenddt, engineer_id, serviceorder_id, activitytype_id, activitystatustype_id, external_id, sub_id, maxstatusdt, name, street, housenumber, housenumbertext, zip, city, phone, serviceobject_id, customer_id, notes, customerexternal_id)
select '00000000-0000-0000-0000-000000000000', '03/09/2012 14:18:00', '03/09/2012 14:18:00', 4, '00000000-0000-0000-0000-000000000000', activitytype_id, 35, external_id, coalesce(sub_id, 0) + 1, getdate(), name, street, housenumber, housenumbertext, zip, city, phone, serviceobject_id, customer_id, notes + ' ' + '$sub.txtnotes328$', customerexternal_id
from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and '$form.cb_vervolg$' = 'false'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr610()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id,engineer_id,activity_id,activitystatustype_id,statusdt, radiostatus_id) select newid(),4,'00000000-0000-0000-0000-000000000000',30,dateadd(ss, -2, getdate()),0 from fv_engineer where id = 4 and '$sub.cb_vervolg$' = 'false'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr611()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id,engineer_id,activity_id,activitystatustype_id,statusdt, radiostatus_id) select newid(),4,'00000000-0000-0000-0000-000000000000',35,getdate(),0 from fv_engineer where id = 4 and '$sub.cb_vervolg$' = 'false'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr617()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and  activitystatustype_id = 59 and exists (select id from fv_activitystatus where activity_id = '00000000-0000-0000-0000-000000000000' and  activitystatustype_id = 59)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr691()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activity
    (id, planstartdt, planenddt, engineer_id, serviceorder_id, activitytype_id, activitystatustype_id, external_id, sub_id, maxstatusdt, name, street, housenumber, housenumbertext, zip, city, phone, serviceobject_id, customer_id, notes, customerexternal_id)
select '00000000-0000-0000-0000-000000000000', '03/09/2012 14:18:00', '03/09/2012 14:18:00', 4, '00000000-0000-0000-0000-000000000000', activitytype_id, 35, external_id, coalesce(sub_id,0)+1, getdate(), name, street, housenumber, housenumbertext, zip, city, phone, serviceobject_id, customer_id, notes + ' ' + '$sub.txtnotes328$', customerexternal_id
from fv_activity
where id = '00000000-0000-0000-0000-000000000000'
    and '$sub.cb_vervolg$' = 'false'
    and not exists (select id from fv_activity where id = '00000000-0000-0000-0000-000000000000' and activitystatustype_id = 35 and maxstatusdt > dateadd(mi, -1, getdate()))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr692()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
    (id,engineer_id,activity_id,activitystatustype_id,statusdt, radiostatus_id)
select newid(),4,'00000000-0000-0000-0000-000000000000',30,dateadd(ss, -2, getdate()),0
from fv_engineer
where id = 4
    and '$sub.cb_vervolg$' = 'false'
    and not exists (select id from fv_activitystatus where activity_id = '00000000-0000-0000-0000-000000000000' and activitystatustype_id = 30 and statusdt > dateadd(mi, -1, getdate()))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr693()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
    (id, engineer_id, activity_id, activitystatustype_id, statusdt, radiostatus_id)
select newid(), 4, '00000000-0000-0000-0000-000000000000', 35, getdate(), 0
from fv_engineer
where id = 4
    and '$sub.cb_vervolg$' = 'false'
    and not exists (select id from fv_activitystatus where activity_id = '00000000-0000-0000-0000-000000000000' and activitystatustype_id = 35 and statusdt > dateadd(mi, -1, getdate()))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr734()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus set vervolg = case when '$sub.cb_vervolg$' = 'false' then 1 else 0 end where activity_id = '00000000-0000-0000-0000-000000000000' and  activitystatustype_id = 59 and exists (select id from fv_activitystatus where activity_id = '00000000-0000-0000-0000-000000000000' and  activitystatustype_id = 59)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr758()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_agenda
( id, activity_id, activitytype, activitytype_id, status,
    activitystatustype_id, street, housenumber, housenumbertext,
    city, zip, planstartdt, totaal_algemeen, wijzigingsdt,
    [name], leverings_adres, serviceorder_id, customer_id, serviceobject_id,
    engineer_id, phone, notes, zpnummer)
select    act.id, act.id,
    substring(at.description, 0, 23),
    at.id,
    null,
    act.activitystatustype_id,
    c.street,
    c.housenumber,
    c.housenumbertext,
    c.city,
    c.zip,
    act.planstartdt,
    ltrim(str(so.totaal_algemeen, 10, 2)),
    so.wijzigingsdt,
    coalesce(c.contactsurname + ' ', '' ) + coalesce(c.bedrijfsnaam1, ''),
    coalesce(act.street + ' ', '') + coalesce(act.housenumber + ' ', '') + coalesce(act.housenumbertext + ' ', '') + coalesce(act.zip + ' ', '') + coalesce(act.city, ''),
    act.serviceorder_id,
    so.customer_id,
    act.serviceobject_id,
    act.engineer_id,
    c.phone,
    act.notes,
    c.external_id
from    fv_activity act
    inner join fv_activitytype at on act.activitytype_id = at.id
    left outer join fv_serviceobject so on act.serviceobject_id = so.id
    left outer join fv_customer c on so.customer_id = c.id
where act.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr762()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_agenda
set    activitystatustype_id = 59
    ,status = 'gereed'
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent20()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_redendeelbetaling where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }

        [TestMethod]
        public void TestSelectStatement32()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief 
set    radiostatus_id = -5, 
    afhandelingstype_id = 2, 
    cancelreason_id = 0, 
    notes = case 0 
            when 2 then N'kaart achtergelaten. aankondiging afsluiting.' 
            when 3 then N'kaart bij klant achtergelaten. doorsturen naar deurwaarder.' 
            when 4 then N'kaart achtergelaten. nieuw bezoek gepland.' 
            when 91 then N'kaart achtergelaten. aankondiging beëindiging levering/geen deurwaarder.' 
        end +  
        case when 0 = 4 then N' 
vervolgafspraak op ' + convert(nvarchar(10), convert(datetime, '03/09/2012 14:18:00'), 105) + N' tussen ' + convert(nvarchar(5), convert(datetime, '03/09/2012 14:18:00'), 114) + N' en ' + convert(nvarchar(5), convert(datetime, '05/10/2012 14:18:00'), 114) + N' uur.' 
            else '' 
        end 
where    activity_id = '00000000-0000-0000-0000-000000000000' 
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }

        [TestMethod]
        public void TestSelectStatement32Reduced()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief 
set    radiostatus_id = -5, 
    afhandelingstype_id = 2, 
    cancelreason_id = 0, 
    notes = case 0 
            when 2 then N'kaart achtergelaten. aankondiging afsluiting.' 
            when 3 then N'kaart bij klant achtergelaten. doorsturen naar deurwaarder.' 
            when 4 then N'kaart achtergelaten. nieuw bezoek gepland.' 
            when 91 then N'kaart achtergelaten. aankondiging beëindiging levering/geen deurwaarder.' 
        end +  
        case when 0 = 4 then N' 
vervolgafspraak op ' + convert(nvarchar(10), convert(datetime, '03/09/2012 14:18:00'), 105) + N' tussen ' + convert(nvarchar(5), convert(datetime, '03/09/2012 14:18:00'), 114) + N' en ' + convert(nvarchar(5), convert(datetime, '05/10/2012 14:18:00'), 114) + N' uur.' 
            else N'' 
        end 
where    activity_id = '00000000-0000-0000-0000-000000000000' 
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement112()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter  
        set radiostatus_id = 0  
        where activity_id= '00000000-0000-0000-0000-000000000000'  
        and exists (select id from fv_debrief_meter where activity_id= '00000000-0000-0000-0000-000000000000') 
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr528()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    c.external_id + ' / ' + s.external_id as zp,
    ltrim(str(s.totaal_algemeen,10,2)) as total_open,
    getdate() as now
from    fv_customer c
    inner join fv_serviceobject s on c.id = 0 and s.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr530()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id from fv_cancelreason where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr531()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id, cancelreason_id)
select    newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), 60, 0, 0
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000'
    and '' != 'actiebinnend'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr532()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=60 where id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr535()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set radiostatus_id = 0, enddt=getdate(), roenddt=getdate() where enddt is null and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr614()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activity (id,planstartdt,planenddt,engineer_id,serviceorder_id,activitytype_id,activitystatustype_id,external_id,sub_id,maxstatusdt,name,street,housenumber, housenumbertext, zip, city, phone,serviceobject_id,customer_id,notes,customerexternal_id)
select '00000000-0000-0000-0000-000000000000','03/09/2012 14:18:00','05/10/2012 14:18:00',4,'00000000-0000-0000-0000-000000000000',activitytype_id,35,external_id,coalesce(sub_id,0)+1,getdate(),name,street,housenumber, housenumbertext, zip, city, phone,serviceobject_id,customer_id,notes,customerexternal_id
from fv_activity
where id = '00000000-0000-0000-0000-000000000000' and '$sub.txtkaartexternal$' = 'k3'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr615()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id,engineer_id,activity_id,activitystatustype_id,statusdt, radiostatus_id) select newid(),4,'00000000-0000-0000-0000-000000000000',30,dateadd(ss, -2, getdate()),0 from fv_engineer where id = 4  and '$sub.txtkaartexternal$' = 'k3'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr616()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id,engineer_id,activity_id,activitystatustype_id,statusdt, radiostatus_id) select newid(),4,'00000000-0000-0000-0000-000000000000',35,getdate(),0 from fv_engineer where id = 4  and '$sub.txtkaartexternal$' = 'k3'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr618()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_activitystatus
set    radiostatus_id = 0
where    activity_id = '00000000-0000-0000-0000-000000000000'
    and activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr755()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_agenda
set    activitystatustype_id = 60
    ,status = 'gereed'
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr757()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_agenda
( id, activity_id, activitytype, activitytype_id, status,
    activitystatustype_id, street, housenumber, housenumbertext,
    city, zip, planstartdt, totaal_algemeen, wijzigingsdt,
    [name], leverings_adres, serviceorder_id, customer_id, serviceobject_id,
    engineer_id, phone, notes, zpnummer)
select    act.id, act.id,
    substring(at.description, 0, 23),
    at.id,
    null,
    act.activitystatustype_id,
    c.street,
    c.housenumber,
    c.housenumbertext,
    c.city,
    c.zip,
    act.planstartdt,
    ltrim(str(so.totaal_algemeen, 10, 2)),
    so.wijzigingsdt,
    coalesce(c.contactsurname + ' ', '' ) + coalesce(c.bedrijfsnaam1, ''),
    coalesce(act.street + ' ', '') + coalesce(act.housenumber + ' ', '') + coalesce(act.housenumbertext + ' ', '') + coalesce(act.zip + ' ', '') + coalesce(act.city, ''),
    act.serviceorder_id,
    so.customer_id,
    act.serviceobject_id,
    act.engineer_id,
    c.phone,
    act.notes,
    c.external_id
from    fv_activity act
    inner join fv_activitytype at on act.activitytype_id = at.id
    left outer join fv_serviceobject so on act.serviceobject_id = so.id
    left outer join fv_customer c on so.customer_id = c.id
where act.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr766()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief
set    radiostatus_id = -5,
    afhandelingstype_id = 2,
    cancelreason_id = 0,
    notes = case 0
            when 2 then N'kaart achtergelaten. aankondiging afsluiting.'
            when 3 then N'kaart bij klant achtergelaten. doorsturen naar deurwaarder.'
            when 4 then N'kaart achtergelaten. nieuw bezoek gepland.'
            when 91 then N'kaart achtergelaten. aankondiging beëindiging levering/geen deurwaarder.'


        end + 
        case when 0 = 4 then N'
vervolgafspraak op ' + convert(nvarchar(10), convert(datetime, '03/09/2012 14:18:00'), 105) + N' tussen ' + convert(nvarchar(5), convert(datetime, '03/09/2012 14:18:00'), 114) + N' en ' + convert(nvarchar(5), convert(datetime, '05/10/2012 14:18:00'), 114) + N' uur.'
            else ''
        end
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr767()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter 
        set radiostatus_id = 0 
        where activity_id= '00000000-0000-0000-0000-000000000000' 
        and exists (select id from fv_debrief_meter where activity_id= '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent30()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_cancelreason where isactive = 1 and substring(external_id,1,1)='k'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr538()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief
set    radiostatus_id = -5,
    afhandelingstype_id = case when coalesce(afhandelingstype_id, 0) = 0 then 5 else afhandelingstype_id end,
    notes = '$sub.txtnotes332$'
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr539()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set radiostatus_id = 0, enddt=getdate(), roenddt=getdate() where enddt is null and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr547()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and exists (select fv_debrief_telwerk.id from fv_debrief_telwerk
inner join fv_telwerk on fv_telwerk.id = fv_debrief_telwerk.telwerk_id
and fv_telwerk.meter_id = fv_debrief_meter.meter_id
and fv_debrief_telwerk.activity_id = fv_debrief_meter.activity_id 
and fv_debrief_telwerk.stand is not null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr548()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_telwerk set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and fv_debrief_telwerk.stand is not null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr619()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr635()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select    newid(),
    '00000000-0000-0000-0000-000000000000',
    4,
    getdate(),
    59,
    0
from    fv_activity
where    id = '00000000-0000-0000-0000-000000000000'
    and not exists (select activity_id from fv_activitystatus where activitystatustype_id = 59 and activity_id = fv_activity.id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr636()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=59 where id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr644()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_financial set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and exists (select id from fv_debrief_financial where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr759()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_agenda
set    activitystatustype_id = 59
    ,status = 'gereed'
where    id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent40()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    id,
    description
from    fv_cancelreason 
where    isactive = 1
    and substring(external_id, 1, 1) = 'a'
order by external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr549()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_customer.external_id + ' / ' + fv_serviceobject.external_id as zp from fv_customer inner join fv_serviceobject on fv_customer.id = 0 and fv_serviceobject.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr590()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set afhandelingstype_id = 3, actief=1 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr639()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_meter where activity_id = '00000000-0000-0000-0000-000000000000' and fv_debrief_meter.afsluitbaarheid_id is null and fv_debrief_meter.afsluitwijze_id is null and not exists (select id from fv_debrief_telwerk where meter_id = fv_debrief_meter.meter_id and activity_id = '00000000-0000-0000-0000-000000000000' and not stand is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr640()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_telwerk where activity_id = '00000000-0000-0000-0000-000000000000' and stand is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3352()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     t.id, substring(t.telwerk_nr,1,10) as external_id,fv_meter.metertype as description, t.telwerktype as tw, floor(t.stand) as vstand,floor(fv_debrief_telwerk.stand) as hstand
from         fv_meter inner join
                      fv_telwerk t on fv_meter.id = t.meter_id and not (fv_meter.metertype='e' or fv_meter.metertype='g') left outer join fv_debrief_telwerk on fv_debrief_telwerk.telwerk_id = t.id and fv_debrief_telwerk.activity_id = '00000000-0000-0000-0000-000000000000'
where t.opnamedt in (select     max(opnamedt) from         fv_telwerk where t.meter_id = fv_telwerk.meter_id and t.telwerktype = fv_telwerk.telwerktype) 
and fv_meter.serviceobject_id = 0 order by fv_meter.metertype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent50()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_meter.metertype as product, ah.description as afsluitbaarheid,aw.description as afsluitwijze, fv_debrief_meter.id
from         fv_debrief_meter inner join
                      fv_meter on fv_debrief_meter.meter_id = fv_meter.id and not (fv_meter.metertype='e' or fv_meter.metertype='g') left outer join fv_afsluitbaarheid ah on fv_debrief_meter.afsluitbaarheid_id=ah.id left outer join fv_afsluitwijze aw on fv_debrief_meter.afsluitwijze_id=aw.id
where     fv_debrief_meter.activity_id = '00000000-0000-0000-0000-000000000000' order by fv_meter.metertype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr556()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_customer.external_id + ' / ' + fv_serviceobject.external_id as zp,'false' as def from fv_customer inner join fv_serviceobject on fv_customer.id = 0 and fv_serviceobject.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr557()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$form.txtnotes334$' where activity_id = '00000000-0000-0000-0000-000000000000' and 0 = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr558()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, dateadd(ss,5,getdate()), 60, 0 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and 0=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr559()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=60 where id = '00000000-0000-0000-0000-000000000000' and 0=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr563()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_meter (id, activity_id, meter_id, radiostatus_id, engineer_id, afsluitdt) select newid(),'00000000-0000-0000-0000-000000000000',id,-1,4,getdate() from fv_meter where serviceobject_id = 0 and not exists (select id from fv_debrief_meter where activity_id='00000000-0000-0000-0000-000000000000' and meter_id = fv_meter.id) and 0=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr620()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr641()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_telwerk where activity_id = '00000000-0000-0000-0000-000000000000' and stand is null and 0=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr658()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id,cancelnotes)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, dateadd(ss,-2,getdate()), 59, 0, '$form.txtnotes334$'
 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and 0=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr760()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_agenda
set    activitystatustype_id = 60
    ,status = 'gereed'
where    id = '00000000-0000-0000-0000-000000000000'
    and 0 = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3355()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     t.id, substring(t.telwerk_nr,1,10) as external_id,fv_meter.metertype as description, t.telwerktype as tw, floor(t.stand) as vstand,floor(fv_debrief_telwerk.stand) as hstand
from         fv_meter inner join
                      fv_telwerk t on fv_meter.id = t.meter_id and not (fv_meter.metertype='e' or fv_meter.metertype='g') left outer join fv_debrief_telwerk on fv_debrief_telwerk.telwerk_id = t.id and fv_debrief_telwerk.activity_id = '00000000-0000-0000-0000-000000000000'
where t.opnamedt in (select     max(opnamedt) from         fv_telwerk where t.meter_id = fv_telwerk.meter_id and t.telwerktype = fv_telwerk.telwerktype) 
and fv_meter.serviceobject_id = 0 order by fv_meter.metertype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent22()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_registratiecontrole where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr443()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_agenda.name,
    fv_agenda.leverings_adres as a_adress,
    coalesce(fv_agenda.street + ' ', '') + coalesce(fv_agenda.housenumber + ' ', '') + coalesce(fv_agenda.housenumbertext, '') as c_adres,
    fv_agenda.phone,
    fv_agenda.totaal_algemeen as total_open,
    fv_agenda.zip,
    fv_agenda.city
from    fv_agenda
where    fv_agenda.activity_id = '$sub.id_act$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2777()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    h.id,
    h.contactdt as contactdt,
    h.contacttype as contacttype,
    substring(h.notes, 0, 50) as notes
from  fv_contacthistorie h
    inner join fv_serviceorder s on s.customer_id = h.customer_id
    inner join fv_activity a on a.serviceorder_id = s.id and a.id = '$sub.id_act$'
order by h.contactdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr730()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_temp");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr731()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_temp (id, activity_id, code, pc_naam, adres, openstaand, zip, housenumber, marker)
select    newid() as id,
    fv_agenda.activity_id,
    substring(fv_activitytype.external_id, 1, 2) + ' '
        + convert(nchar(1), fv_activitytype.sortorder)
        + space(10-len(coalesce(fv_agenda.zip, '')))
        + convert(nvarchar, coalesce(fv_agenda.zip, ''))
        + space(10-len(coalesce(fv_agenda.housenumber, '')))
        + convert(nvarchar, coalesce(fv_agenda.housenumber, ''))
        + substring(convert(nchar(36), fv_agenda.activity_id), 1, 10)
    as code,
    substring(coalesce(fv_agenda.zip + ' ', '') + substring(fv_agenda.name, 1, 7), 0, 50) as pc_naam,
    substring(coalesce(fv_agenda.street + ' ', '') + coalesce(fv_agenda.housenumber + ' ', '') + coalesce(fv_agenda.housenumbertext + ' ', '') + coalesce(fv_agenda.city, ''), 0, 50) as adres,
    fv_agenda.totaal_algemeen as openstaand,
    fv_agenda.zip,
    fv_agenda.housenumber,
    null as marker
from    fv_agenda
    inner join fv_activitytype
        on fv_agenda.activitytype_id = fv_activitytype.id
where    fv_agenda.engineer_id = 4
    and fv_agenda.activitystatustype_id in (30, 170)
order by fv_activitytype.sortorder, fv_agenda.zip, fv_agenda.housenumber");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr732()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as aantal
from fv_temp");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr763()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    count(0) as aantal
from fv_agenda
where fv_agenda.engineer_id = 4
    and fv_agenda.activitystatustype_id in (35, 40, 50, 55, 140, 160)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr587()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  ltrim(str(sum(voldaan_contant), 10, 2)) as contant,
        ltrim(str(sum(voldaan_pin), 10, 2)) as pin
from    fv_debrief
where   contant_afgedragen = 0
        and exists ( select id
                     from   fv_activitystatus
                     where  activitystatustype_id in ( 59, 60 )
                            and activity_id = fv_debrief.activity_id )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent110()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  a.id,
        c.external_id + ' ' + s.external_id as zpcr,
        ltrim(str(d.voldaan_contant, 10, 2)) as voldaan_contant,
        ltrim(str(d.voldaan_pin, 10, 2)) as voldaan_pin
from    fv_debrief d
        inner join fv_activity a on a.id = d.activity_id
                                    and d.contant_afgedragen = 0
        inner join fv_serviceobject s on s.id = a.serviceobject_id
        inner join fv_serviceorder so on so.id = a.serviceorder_id
        inner join fv_customer c on c.id = so.customer_id
where   exists ( select id
                 from   fv_activitystatus
                 where  activitystatustype_id in (59,60)
                        and activity_id = a.id )
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr588()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ltrim(str(sum(voldaan_contant),10,2)) as contant, 'false' as def from fv_debrief where contant_afgedragen = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement14()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set contant_afgedragen = 1 where contant_afgedragen = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3418()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    id as activity_id,
    '' as status,
    '' as name,
    '' as a_adress
from    fv_engineer
where    id = -1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr594()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    case fv_agenda.activitystatustype_id
        when 30 then 'werkvoorraad'
        when 35 then 'gepland - ' + convert(nvarchar(10), fv_agenda.planstartdt, 105)
        when 59 then 'gereed'
        when 60 then 'gereed'
    end as status,
    fv_agenda.name,
    coalesce(fv_agenda.street + ' ', '') + coalesce(fv_agenda.housenumber + ' ', '') + coalesce(fv_agenda.housenumbertext, '') as a_adress,
    fv_agenda.zip,
    fv_agenda.city,
    fv_agenda.phone,
    fv_activity.changedt,
    fv_soortpand.description as soortpand,
    case when fv_serviceobject.id is null then fv_agenda.totaal_algemeen else ltrim(str(fv_serviceobject.totaal_algemeen,10,2)) end as total_open,
    fv_agenda.activitystatustype_id,
    fv_agenda.activity_id,
    fv_agenda.serviceorder_id,
    fv_agenda.customer_id,
    fv_agenda.serviceobject_id,
    case when fv_activity.id is null then 1 else fv_activitytype.flow_id end as flow_id
from    fv_agenda
    left outer join fv_activity
        on fv_agenda.activity_id = fv_activity.id
    left outer join fv_serviceobject
        on fv_activity.serviceobject_id = fv_serviceobject.id
    inner join fv_activitytype
        on fv_agenda.activitytype_id = fv_activitytype.id
    left outer join fv_soortpand
        on fv_serviceobject.soortpand_id = fv_soortpand.id
where    fv_agenda.activity_id = '$flow.order_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr595()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select max(h.contactdt) as contactdt from  fv_contacthistorie h inner join fv_serviceorder s on s.customer_id = h.customer_id inner join fv_activity a on a.serviceorder_id = s.id and a.id = '$sub.grdresult.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement15()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
    select newid(), id, 4, getdate(), 35, 0
    from fv_activity
    where id = '$sub.grdresult.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement26()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity
    set planstartdt = getdate(), maxstatusdt = getdate(), activitystatustype_id = 35
    where id = '$sub.grdresult.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement3()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus
    set radiostatus_id = 0
    where activitystatustype_id = 30 and activity_id = '$sub.grdresult.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement4()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_agenda
    set activitystatustype_id = 35, planstartdt = getdate()
    where activity_id = '$sub.grdresult.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement5()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_request (id, activity_id, engineer_id, updatedt, serviceobject_id, customer_id, updatetype_id, radiostatus_id)
select newid(), a.id, 4, s.wijzigingsdt, a.serviceobject_id, sorder.customer_id, ut.id, 0
from 
    fv_activity a
    inner join fv_serviceorder sorder on a.serviceorder_id = sorder.id
    inner join fv_serviceobject s on s.id = a.serviceobject_id
    cross join fv_updatetype ut
where a.id = '$sub.grdresult.id$' and ut.id in (1,2)
union all
select newid(), a.id, 4, ch.collectiondt, a.serviceobject_id, sorder.customer_id, 3, 0
from 
    (
        select    fv_activity.customer_id as customer_id, coalesce(max(collectiondt), convert(datetime, 0)) as collectiondt
        from    fv_activity
        left outer join fv_collectionhistorie on fv_activity.customer_id = fv_collectionhistorie.customer_id
        group by  fv_activity.customer_id        
    ) ch
    inner join fv_activity a on a.customer_id = ch.customer_id
    inner join fv_serviceorder sorder on a.serviceorder_id = sorder.id
    inner join fv_serviceobject s on s.id = a.serviceobject_id
where a.id = '$sub.grdresult.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr448()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select customername from fv_customer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr449()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, coalesce(street + ' '  + housenumber + ' ' + housenumbertext,street + ' '  + housenumber,street,'') as adres, zip, city, contact, phone, mobilephone,notes from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr450()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set enddt = getdate(), roenddt = getdate(), mileage = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and labourstatus_id = 3");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr451()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select mileage from fv_labour where rostartdt in (select max(rostartdt) from fv_labour)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr452()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)  select '4', getdate(), 0, 40, '00000000-0000-0000-0000-000000000000' from fv_engineer  where not exists  (select id from fv_activitystatus where activity_id = '00000000-0000-0000-0000-000000000000' and activitystatustype_id = 40) and id = '4'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr453()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitystatustype_id = 40, maxstatusdt=getdate()  where (fv_activity.id = '00000000-0000-0000-0000-000000000000') and activitystatustype_id not in (40,50)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr589()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) as aantal from fv_debrief where fv_debrief.actief = 1 and fv_debrief.afhandelingstype_id = 3");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr591()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ltrim(str(sum(s.totaal_algemeen),10,2)) as bedrag from fv_debrief inner join fv_activity a on a.id = fv_debrief.activity_id inner join fv_serviceobject s on s.id = a.serviceobject_id where fv_debrief.actief = 1 and fv_debrief.afhandelingstype_id = 3 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr592()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    count(*) as aantal
from    fv_debrief
where    fv_debrief.actief = 1
/*    and fv_debrief.afhandelingstype_id = 1*/
    and coalesce(voldaan_totaal, 0) != 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr593()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    ltrim(str(sum(voldaan_totaal), 10, 2)) as bedrag
from    fv_debrief
where    fv_debrief.actief = 1
    --and fv_debrief.afhandelingstype_id = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement16()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set actief=0 where actief = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent120()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_meter.metertype as product, ah.description as afsluitbaarheid,aw.description as afsluitwijze, fv_debrief_meter.id
from         fv_debrief_meter inner join
                      fv_meter on fv_debrief_meter.meter_id = fv_meter.id and not (fv_meter.metertype='e' or fv_meter.metertype='g') left outer join fv_afsluitbaarheid ah on ah.id = fv_debrief_meter.afsluitbaarheid_id left outer join fv_afsluitwijze aw on aw.id = fv_debrief_meter.afsluitwijze_id
where     fv_debrief_meter.activity_id = '00000000-0000-0000-0000-000000000000' order by fv_meter.metertype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr550()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_telwerk.id,
    fv_telwerk.telwerk_nr as external_id,
    fv_meter.metertype as description,
    fv_telwerk.telwerktype as tw,
    fv_telwerk.stand,
    floor(fv_debrief_telwerk.stand) as hstand,
    ceiling(fv_telwerk.stand) as vstand,
    fv_telwerk.opnamesoort as opnamesoort
from    fv_telwerk
    inner join fv_meter
        on fv_telwerk.meter_id = fv_meter.id
    left outer join fv_debrief_telwerk
        on fv_debrief_telwerk.telwerk_id = fv_telwerk.id
            and fv_debrief_telwerk.activity_id = '00000000-0000-0000-0000-000000000000'
where fv_telwerk.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement17()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_telwerk set stand = '$sub.txthstand$', verifydt = getdate() where telwerk_id = 0 and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr457()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_agenda.notes
from fv_agenda
where fv_agenda.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr455()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    case when fv_customer.id is null
        then fv_agenda.name
        else coalesce(ltrim(coalesce(fv_customer.contacttitle + ' ', '') + coalesce(fv_customer.contactfirstname + ' ', '') + coalesce(fv_customer.midname1 + ' ', '') + coalesce(fv_customer.contactsurname, '')), fv_customer.bedrijfsnaam1)
    end as customername,
    case when fv_customer.id is null
        then ltrim(coalesce(fv_agenda.street, '') + ' ' + coalesce(fv_agenda.housenumber, '') + ' ' + coalesce(fv_agenda.housenumbertext, '') + ' ' + coalesce(fv_agenda.zip, '') + ' ' + coalesce(fv_agenda.city, ''))
        else ltrim(coalesce(fv_customer.street, '') + ' ' + coalesce(fv_customer.housenumber, '') + ' ' + coalesce(fv_customer.housenumbertext, '') + ' ' + coalesce(fv_customer.zip, '') + ' ' + coalesce(fv_customer.city, ''))
    end as c_adress,
    ltrim(coalesce(fv_customer.postbus_street, '') + ' ' + coalesce(fv_customer.postbus_zip, '') + ' ' + coalesce(fv_customer.postbus_city, '')) as p_adress,
    ltrim(coalesce(fv_customer.fac_street, '') + ' ' + coalesce(fv_customer.fac_housenumber, '') + ' ' + coalesce(fv_customer.fac_housenumbertext, '') + ' ' + coalesce(fv_customer.fac_zip, '') + ' ' + coalesce (fv_customer.fac_city, '')) as f_adress
from    fv_agenda
    left outer join fv_customer on fv_agenda.customer_id = fv_customer.id
where    fv_agenda.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr623()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '8:00' as start, '12:00' as eind from fv_engineer where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent130()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_activitytype where billable = 0 and isactive = 1
order by id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement27()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_serviceorder (id,orderdt,mainengineer_id,external_id,customer_id) select '00000000-0000-0000-0000-000000000000','03/09/2012 14:18:00',4,null,0 from fv_engineer where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement83()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activity (id,planstartdt,planenddt,engineer_id,serviceorder_id,activitytype_id,activitystatustype_id,external_id,sub_id,maxstatusdt,customer_id,notes)
select '00000000-0000-0000-0000-000000000000','03/09/2012 14:18:00','05/10/2012 14:18:00',4,'00000000-0000-0000-0000-000000000000',0,35,null,0,getdate(),0,'$sub.txtnotes350$' from fv_engineer where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement84()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id,engineer_id,activity_id,activitystatustype_id,statusdt, radiostatus_id) select newid(),4,'00000000-0000-0000-0000-000000000000',30,dateadd(ss, -2, getdate()),0 from fv_engineer where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement85()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id,engineer_id,activity_id,activitystatustype_id,statusdt, radiostatus_id) select newid(),4,'00000000-0000-0000-0000-000000000000',35,getdate(),0 from fv_engineer where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement86()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_agenda
(id, activity_id, activitytype, activitytype_id, status,
    activitystatustype_id, street, housenumber, housenumbertext,
    city, zip, planstartdt, totaal_algemeen, wijzigingsdt,
    [name], leverings_adres, serviceorder_id, customer_id, serviceobject_id,
    engineer_id, phone, notes, zpnummer)
select    act.id, act.id,
    substring(at.description, 0, 23),
    at.id,
    null,
    act.activitystatustype_id,
    c.street,
    c.housenumber,
    c.housenumbertext,
    c.city,
    c.zip,
    act.planstartdt,
    ltrim(str(so.totaal_algemeen, 10, 2)),
    so.wijzigingsdt,
    coalesce(c.contacttitle + ' ', '') + coalesce(c.contactfirstname + ' ', '') + coalesce(c.contactsurname + ' ', '' ) + coalesce(c.bedrijfsnaam1, ''),
    coalesce(act.street + ' ', '') + coalesce(act.housenumber + ' ', '') + coalesce(act.housenumbertext + ' ', '') + coalesce(act.zip + ' ', '') + coalesce(act.city, ''),
    act.serviceorder_id,
    so.customer_id,
    act.serviceobject_id,
    act.engineer_id,
    c.phone,
    coalesce(act.notes, '') + '$form.txtnotes350$',
    c.external_id
from    fv_activity act
    inner join fv_activitytype at on act.activitytype_id = at.id
    left outer join fv_serviceobject so on act.serviceobject_id = so.id
    left outer join fv_customer c on so.customer_id = c.id
where act.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr597()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, getdate(), 50, 0
 from fv_activity where id = '00000000-0000-0000-0000-000000000000'  and not exists (select id from fv_activitystatus where activitystatustype_id = 50 and activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr598()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour
(id, activity_id, engineer_id, startdt, rostartdt, labourstatus_id, radiostatus_id)
select
newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), getdate(), 2, -1 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and not exists (select id from fv_labour where enddt is null and labourstatus_id = 2 and activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr599()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=50 where id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr600()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, getdate(), 60, 0
 from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr601()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=60 where id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr603()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, radiostatus_id, activity_id, engineer_id)
select newid(), -1, id, 4 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and not exists (select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr625()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_activitytype.description, fv_activity.city, fv_activity.notes from fv_activity inner join fv_activitytype on fv_activity.activitytype_id = fv_activitytype.id where fv_activity.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr765()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_agenda
set    activitystatustype_id = 60,
    [status] = 'gereed'
where     activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr569()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_customer.external_id + ' / ' + fv_serviceobject.external_id as zp, 'false' as def from fv_customer inner join fv_serviceobject on fv_customer.id = 0 and fv_serviceobject.id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr575()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, radiostatus_id, activity_id,engineer_id) select newid(), -1,id,4 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and not exists (select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr576()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, getdate(), 60, 0 from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr577()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=60 where id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr578()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief
set    afhandelingstype_id = 4
where    activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr605()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus
(id,activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(),
'00000000-0000-0000-0000-000000000000', 4, getdate(), 55, 0
 from fv_activity where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr606()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt=getdate(), activitystatustype_id=55 where id = '00000000-0000-0000-0000-000000000000' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2944()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     t.id, substring(t.telwerk_nr,1,10) as external_id,fv_meter.metertype as description, t.telwerktype as tw, floor(t.stand) as vstand,floor(fv_debrief_telwerk.stand) as hstand
from         fv_meter inner join
                      fv_telwerk t on fv_meter.id = t.meter_id and not (fv_meter.metertype='e' or fv_meter.metertype='g') left outer join fv_debrief_telwerk on fv_debrief_telwerk.telwerk_id = t.id and fv_debrief_telwerk.activity_id = '00000000-0000-0000-0000-000000000000'
where t.opnamedt in (select     max(opnamedt) from         fv_telwerk where t.meter_id = fv_telwerk.meter_id and t.telwerktype = fv_telwerk.telwerktype) 
and fv_meter.serviceobject_id = 0 order by fv_meter.metertype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent60()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_meter.metertype as product, ah.description as afsluitbaarheid, case when fv_debrief_meter.aansluitingstatus = 1 then 'v' else '' end as heraangesloten, fv_debrief_meter.id
from         fv_debrief_meter inner join
                      fv_meter on fv_debrief_meter.meter_id = fv_meter.id and not (fv_meter.metertype='e' or fv_meter.metertype='g') left outer join fv_afsluitbaarheid ah on ah.id = fv_debrief_meter.afsluitbaarheid_id
where     fv_debrief_meter.activity_id = '00000000-0000-0000-0000-000000000000' order by fv_meter.metertype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr483()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(a.name,c.bedrijfsnaam1) as name,
    ltrim(str(s.totaal_algemeen,10,2)) as total_open,
    c.external_id as cusext,
    s.external_id as serext
from    fv_activity a
    inner join fv_serviceobject s on a.serviceobject_id=s.id
    left outer join fv_customer c on c.id = 0
where    a.id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr567()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_meter (id, activity_id, meter_id, radiostatus_id, engineer_id,afsluitdt,aansluitingstatus) select newid(),'00000000-0000-0000-0000-000000000000',id,-1,4,getdate(),0 from fv_meter where serviceobject_id = 0 and not exists (select id from fv_debrief_meter where activity_id='00000000-0000-0000-0000-000000000000' and meter_id = fv_meter.id) and 'dummy'=''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr568()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_telwerk (id, activity_id, telwerk_id, radiostatus_id, engineer_id) select newid(),'00000000-0000-0000-0000-000000000000',id,-1,4 from fv_telwerk t where meter_id in (select id from fv_meter where serviceobject_id=0) and not exists (select id from fv_debrief_telwerk where activity_id='00000000-0000-0000-0000-000000000000' and telwerk_id =t.id) and 'dummy'=''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr624()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief (id, radiostatus_id, activity_id,engineer_id) select newid(), -1,id,4 from fv_activity where id = '00000000-0000-0000-0000-000000000000' and not exists (select id from fv_debrief where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3001()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_telwerk.id, fv_telwerk.telwerk_nr as external_id, fv_meter.metertype as description, fv_telwerk.telwerktype as tw, fv_telwerk.stand, fv_opnamesoort.notes
from         fv_meter inner join
                      fv_telwerk on fv_meter.id = fv_telwerk.meter_id left outer join fv_opnamesoort on fv_telwerk.opnamesoort = fv_opnamesoort.description
where fv_meter.serviceobject_id = 0
order by fv_meter.metertype, fv_telwerk.opnamedt desc, fv_telwerk.telwerktype");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr480()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 
                coalesce(a.name,c.bedrijfsnaam1) as name,
ltrim(str(s.totaal_algemeen,10,2)) as total_open
                from fv_activity a inner join fv_serviceobject s on a.serviceobject_id=s.id left outer join fv_customer c on c.id = 0
        where 
                a.id='00000000-0000-0000-0000-000000000000'

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr481()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id from fv_customer where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr482()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id from fv_serviceobject where id = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr564()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_meter (id, activity_id, meter_id, radiostatus_id, engineer_id,afsluitdt,aansluitingstatus) select newid(),'00000000-0000-0000-0000-000000000000',id,-1,4,getdate(),0 from fv_meter where serviceobject_id = 0 and not exists (select id from fv_debrief_meter where activity_id='00000000-0000-0000-0000-000000000000' and meter_id = fv_meter.id) and 'dummy'=''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr565()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief_telwerk (id, activity_id, telwerk_id, radiostatus_id, engineer_id) select newid(),'00000000-0000-0000-0000-000000000000',id,-1,4 from fv_telwerk t where meter_id in (select id from fv_meter where serviceobject_id=0) and not exists (select id from fv_debrief_telwerk where activity_id='00000000-0000-0000-0000-000000000000' and telwerk_id =t.id) and 'dummy'=''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3013()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select h.id,h.contactdt as contactdt, h.contacttype as contacttype, substring(h.notes,0,50) as notes from  fv_contacthistorie h where h.customer_id = 0 order by h.contactdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr586()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ltrim(str(sum(voldaan_pin),10,2)) as totaal_pin from fv_debrief where pin_afgedragen = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement18()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set pin_afgedragen = 1 where pin_afgedragen = 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr736()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set radiostatus_id = -5 where activity_id = '00000000-0000-0000-0000-000000000000' and 0=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr737()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set radiostatus_id = 0, enddt=getdate(), roenddt=getdate() where enddt is null and activity_id = '00000000-0000-0000-0000-000000000000' and 0=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr738()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_telwerk set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and 0=0 and not stand is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr739()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_financial set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and 0=0 and exists (select id from fv_debrief_financial where activity_id = '00000000-0000-0000-0000-000000000000')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr740()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and 0=0 and exists (select fv_debrief_telwerk.id from fv_debrief_telwerk
inner join fv_telwerk on fv_telwerk.id = fv_debrief_telwerk.telwerk_id
and fv_telwerk.meter_id = fv_debrief_meter.meter_id
and fv_debrief_telwerk.activity_id = fv_debrief_meter.activity_id 
and fv_debrief_telwerk.stand is not null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr626()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_agenda.name,
    fv_agenda.leverings_adres as a_adress,
    fv_agenda.phone,
    fv_agenda.totaal_algemeen as total_open,
    fv_agenda.notes as cancelnotes,
    ltrim(coalesce(fv_agenda.street, '') + ' ' + coalesce(fv_agenda.housenumber, '') + ' ' + coalesce(fv_agenda.housenumbertext, '') + ' ' + coalesce(fv_agenda.city, '')) as c_adres,
    fv_agenda.activitystatustype_id
from    fv_agenda
where    fv_agenda.activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3172()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select h.id,h.contactdt as contactdt, h.contacttype as contacttype, substring(h.notes,0,50) as notes from  fv_contacthistorie h where h.customer_id = 0 order by h.contactdt desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr637()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select     fv_meter.metertype as product, fv_debrief_meter.afsluitbaarheid_id,fv_debrief_meter.afsluitwijze_id
from         fv_debrief_meter inner join
                      fv_meter on fv_debrief_meter.meter_id = fv_meter.id
where     fv_debrief_meter.id = '$sub.grdproducten333.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent70()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_afsluitwijze where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent80()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_afsluitbaarheid where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement93()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set afsluitwijze_id = case when '$sub.cb_afsluitw$' = '' then null when '$sub.cb_afsluitw$' = 'null' then null else '$sub.cb_afsluitw$' end, afsluitbaarheid_id = case when '$sub.cb_afsluitbaarheid370$' = '' then null when '$sub.cb_afsluitbaarheid370$' = 'null' then null else '$sub.cb_afsluitbaarheid370$' end  where id = '$sub.grdproducten333.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement33()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set afsluitwijze_id = null  where id = '$sub.grdproducten333.id$' and afsluitwijze_id=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement95()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set afsluitbaarheid_id = null  where id = '$sub.grdproducten333.id$' and afsluitbaarheid_id=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr638()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_meter.metertype as product,
    case when fv_debrief_meter.aansluitingstatus = 1 then 'true' else 'false' end as status,
    fv_debrief_meter.afsluitbaarheid_id
from    fv_debrief_meter
    inner join fv_meter
        on fv_debrief_meter.meter_id = fv_meter.id
where    fv_debrief_meter.id = '$sub.grdproducten352.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent190()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_afsluitbaarheid where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement28()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set aansluitingstatus = case when '$sub.cb_heraangesloten$' = 'true' then 1 else 0 end where id = '$sub.grdproducten352.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr653()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    fv_meter.metertype as product,
    fv_debrief_meter.afsluitbaarheid_id,
    fv_debrief_meter.afsluitwijze_id
from    fv_debrief_meter
    inner join fv_meter
        on fv_debrief_meter.meter_id = fv_meter.id
where    fv_debrief_meter.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent180()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    id,
    description
from    fv_afsluitbaarheid
where    isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement29()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set afsluitbaarheid_id = 0 where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr660()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select case when 1 + $flow.van$ = 1 then 1 else 0 end as start, case when 10 + $flow.van$ >= count(*) then 1 else 0 end as eind, getdate() as nu from fv_temp");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement19()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_temp set marker = case when marker = 1 then 0 else 1 end where id = '$sub.grdwerk.temp_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent2()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select
    t.id as temp_id, 
    t.activity_id as id,
    substring(t.code, 1, 2) as cde,
    t.pc_naam,
    t.adres,
    case when t.marker = 1 then 'v' else '' end as marker,
    t.openstaand,
    t.zip,
    t.housenumber,
    substring(t.code,4,31) as ord
from
    fv_temp t
    inner join fv_temp t1
        on substring(t.code,4,31) >= substring(t1.code,4,31)
group by
    t.id, 
    t.activity_id,
    t.code,
    t.pc_naam,
    t.adres,
    t.marker,
    t.openstaand,
    t.zip,
    t.housenumber 
having count(*) >= 1+ $flow.van$ and count(*) <= 10 + $flow.van$
order by ord");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement193()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), activity_id, 4, dateadd(second, -2, '$sub.dt_now375$'), 30, 0
from fv_temp
where marker = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement193Reduced()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_activitystatus (statusdt)
select dateadd(second, -2, '$sub.dt_now375$')
from fv_temp
where marker = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement94()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
select newid(), activity_id, 4, '$sub.dt_now375$', 35, 0
from fv_temp
where marker = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement195()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_activity
set    fv_activity.planstartdt = '$sub.dt_plan375$',
    fv_activity.maxstatusdt = '$sub.dt_now375$',
    fv_activity.activitystatustype_id = 35
where
    fv_activity.id in (select activity_id from fv_temp where marker = 1)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement66()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
update    fv_agenda
set    fv_agenda.planstartdt = '$sub.dt_plan375$',
    fv_agenda.activitystatustype_id = 35
where
    fv_agenda.activity_id in (select activity_id from fv_temp where marker = 1)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement21()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
delete from fv_activity 
where    activitystatustype_id in (30, 35, 140, 170)
    and planstartdt > dateadd(hour, $form.txtopschoonday$, getdate())
    and not exists (select activity_id from fv_activitystatus where radiostatus_id != 2 and activity_id = fv_activity.id)
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    paramvalue
from    fv_param_mobile
where    id = 5");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr695()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_serviceorder
where    not exists (select id from fv_activity where serviceorder_id = fv_serviceorder.id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr696()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_financial
where    not exists (select id from fv_activity where id = fv_debrief_financial.activity_id)
    and radiostatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr697()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_geldafdracht
where    not exists (select id from fv_activity where id = fv_debrief_geldafdracht.activity_id)
    and radiostatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr698()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_meter
where    not exists (select id from fv_activity where id = fv_debrief_meter.activity_id)
    and radiostatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr699()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief_telwerk
where    not exists (select id from fv_activity where id = fv_debrief_telwerk.activity_id)
    and radiostatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr700()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour
where    not exists (select id from fv_activity where id = fv_labour.activity_id)
    and radiostatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr701()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activitystatus
where    not exists (select id from fv_activity where id = fv_activitystatus.activity_id)
    and coalesce(radiostatus_id, 2) = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr702()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_serviceobject
where    not exists (select id from fv_activity where serviceobject_id = fv_serviceobject.id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr703()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_financial
where    not exists (select id from fv_serviceobject where id = fv_financial.serviceobject_id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr704()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_meter
where    not exists (select id from fv_serviceobject where id = fv_meter.serviceobject_id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr705()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_telwerk
where    not exists (select id from fv_meter where id = fv_telwerk.meter_id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr706()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_customer
where    not exists (select id from fv_serviceorder where customer_id = fv_customer.id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr707()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_contacthistorie
where    not exists (select id from fv_customer where id = fv_contacthistorie.customer_id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr710()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activity 
where    activitystatustype_id in (59, 60, 120, 125, 150, 190)
    and not exists (select activity_id from fv_debrief where fv_debrief.activity_id = fv_activity.id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr712()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_request where radiostatus_id in (1, 2)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr764()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_sendorder
where radiostatus_id != 0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr773()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_collectionhistorie
where    not exists (select id from fv_customer where id = fv_collectionhistorie.customer_id)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement30()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_request (id, activity_id, engineer_id, updatedt, serviceobject_id, customer_id, updatetype_id, radiostatus_id)
select newid(), fv_agenda.activity_id, '4', fv_agenda.wijzigingsdt, fv_agenda.serviceobject_id, fv_agenda.customer_id,
fv_updatetype.id, 0 from fv_agenda inner join fv_activitytype on fv_agenda.activitytype_id = fv_activitytype.id and fv_activitytype.billable = 1,
fv_updatetype where fv_updatetype.id in ( 1, 2 ) and fv_agenda.planstartdt < dateadd(hour, 81, getdate()) and fv_agenda.engineer_id = '4'
and ( ( fv_agenda.activitystatustype_id > 30 and fv_agenda.activitystatustype_id < 59 ) or fv_agenda.activitystatustype_id in ( 140, 160 ) )
union all select newid(), fv_agenda.activity_id, '4', coalesce(a.collectiondt, convert(datetime, 0)), fv_agenda.serviceobject_id,
fv_agenda.customer_id, 3, 0 from ( select fv_agenda.customer_id as customer_id, coalesce(max(collectiondt), convert(datetime, 0)) as collectiondt
from fv_agenda left outer join fv_collectionhistorie on fv_agenda.customer_id = fv_collectionhistorie.customer_id inner join fv_activitytype
on fv_agenda.activitytype_id = fv_activitytype.id and fv_activitytype.billable = 1 group by  fv_activity.customer_id) a inner join fv_agenda
on fv_agenda.customer_id = a.customer_id where fv_agenda.planstartdt < dateadd(hour, 81, getdate()) and fv_agenda.engineer_id = '4'
and ( ( fv_agenda.activitystatustype_id > 30 and fv_agenda.activitystatustype_id < 59 ) or fv_agenda.activitystatustype_id in ( 140, 160 ))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement22()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_agenda 
where    activitystatustype_id in (120, 125, 150, 190)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement23()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_agenda 
where    datediff(dd, coalesce(planstartdt, getdate()), getdate()) > $form.txtopschoon$ 
    and activitystatustype_id in (59, 60)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement103()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_debrief  
where (coalesce(pin_afgedragen, 1) = 1  
    and coalesce(contant_afgedragen, 1) = 1 
    and datediff(dd, coalesce(txstartdt, getdate()), getdate()) > $form.txtopschoon$ 
    and radiostatus_id = 2) 
      or 
    (radiostatus_id = -1  
     and activity_id in (select id from fv_activity where activitystatustype_id in (120, 125, 150, 190)))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr751()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    paramvalue
from    fv_param_mobile
where    id = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr746()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_debrief
set    soortpand_id = case when '$form.cmbsoortpand$' = '' then null else $form.cmbsoortpand$+0 end,
soortobject_exported = 0
where    activity_id = '00000000-0000-0000-0000-000000000000' and case when '$form.cmbsoortpand$' = '' then null else $form.cmbsoortpand$+0 end is not null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr747()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    p.description as soortpand,
    coalesce(d.soortpand_id, s.soortpand_id, c.soortpand_id) as soortpand_id
from    fv_activity a
    inner join fv_debrief d on d.activity_id = a.id
    left outer join fv_customer c on c.id = 0
    left outer join fv_serviceobject s on s.id = a.serviceobject_id
    left outer join fv_soortpand p on coalesce(c.soortpand_id, s.soortpand_id) = p.id
where    a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent170()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    id,
    description
from    fv_soortpand
where    isactive = 1
order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr748()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    getdate() as now
from    fv_engineer
where    id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr768()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as aantal
    from fv_debrief
    where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement24()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activity (id, planstartdt, planenddt, engineer_id, serviceorder_id, activitytype_id, activitystatustype_id, external_id, sub_id, maxstatusdt, name, street, housenumber, housenumbertext, zip, city, phone, serviceobject_id, customer_id, notes, customerexternal_id) 
select    '00000000-0000-0000-0000-000000000000', '03/09/2012 14:18:00', '05/10/2012 14:18:00', 4, '00000000-0000-0000-0000-000000000000', activitytype_id, 35, external_id, coalesce(sub_id,0)+1, getdate(), name, street, housenumber, housenumbertext, zip, city, phone, serviceobject_id, customer_id, coalesce(notes, '') + '$form.txtdoorpnotes$', customerexternal_id 
from fv_activity 
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement25()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, engineer_id, activity_id, activitystatustype_id, statusdt, radiostatus_id) 
select newid(), 4, '00000000-0000-0000-0000-000000000000', 30, dateadd(ss, -2, getdate()), 0 
from fv_engineer 
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement43()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, engineer_id, activity_id, activitystatustype_id, statusdt, radiostatus_id) 
select newid(), 4, '00000000-0000-0000-0000-000000000000', 35, getdate(), 0 
from fv_engineer 
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement44()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set radiostatus_id = 0, enddt = getdate(), roenddt = getdate() where enddt is null and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement45()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debrief 
                (id, activity_id, engineer_id, radiostatus_id, afhandelingstype_id, cancelreason_id, notes) 
            values      
                (newid(), '00000000-0000-0000-0000-000000000000', 4, -5, 2, 0, 'doorgepland. $form.txtdoorpnotes$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement46()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief 
set radiostatus_id = -5, afhandelingstype_id = 2, cancelreason_id = 0, notes = 'doorgepland. $form.txtdoorpnotes$' 
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement47()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement48()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 60 where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement49()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_agenda set activitystatustype_id = 60 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement50()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id) 
values (newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), 60, 0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement51()
        {
            var statement = MacroScope.Factory.CreateStatement(@" 
insert into fv_agenda 
(id, activity_id, activitytype, activitytype_id, status, 
    activitystatustype_id, street, housenumber, housenumbertext, 
    city, zip, planstartdt, totaal_algemeen, wijzigingsdt, 
    [name], leverings_adres, serviceorder_id, customer_id, serviceobject_id, 
    engineer_id, phone, notes, zpnummer) 
select    act.id, act.id, 
    substring(at.description, 0, 23), 
    at.id, 
    null, 
    act.activitystatustype_id, 
    c.street, 
    c.housenumber, 
    c.housenumbertext, 
    c.city, 
    c.zip, 
    act.planstartdt, 
    ltrim(str(so.totaal_algemeen, 10, 2)), 
    so.wijzigingsdt, 
    coalesce(c.contacttitle + ' ', '') + coalesce(c.contactfirstname + ' ', '') + coalesce(c.contactsurname + ' ', '' ) + coalesce(c.bedrijfsnaam1, ''), 
    coalesce(act.street + ' ', '') + coalesce(act.housenumber + ' ', '') + coalesce(act.housenumbertext + ' ', '') + coalesce(act.zip + ' ', '') + coalesce(act.city, ''), 
    act.serviceorder_id, 
    so.customer_id, 
    act.serviceobject_id, 
    act.engineer_id, 
    c.phone, 
    coalesce(act.notes, '') + '$form.txtdoorpnotes$', 
    c.external_id 
from    fv_activity act 
    inner join fv_activitytype at on act.activitytype_id = at.id 
    left outer join fv_serviceobject so on act.serviceobject_id = so.id 
    left outer join fv_customer c on so.customer_id = c.id 
where act.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement53()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_sendorder (id, activity_id, radiostatus_id)
values (newid(), '00000000-0000-0000-0000-000000000000', 0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement122()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_request (id, activity_id, engineer_id, updatedt, serviceobject_id, customer_id, updatetype_id, radiostatus_id)
select newid(), a.id, 4, s.wijzigingsdt, a.serviceobject_id, sorder.customer_id, ut.id, 0
from 
    fv_activity a
    inner join fv_serviceorder sorder on a.serviceorder_id = sorder.id
    inner join fv_serviceobject s on s.id = a.serviceobject_id
    cross join fv_updatetype ut
where a.id = '00000000-0000-0000-0000-000000000000' and ut.id in (1,2)
union all
select newid(), a.id, 4, ch.collectiondt, a.serviceobject_id, sorder.customer_id, 3, 0
from 
    (
        select fv_activity.customer_id as customer_id, coalesce(max(collectiondt), convert(datetime, 0)) as collectiondt
        from        fv_activity
                            left outer join fv_collectionhistorie on fv_activity.customer_id = fv_collectionhistorie.customer_id
        group by  fv_activity.customer_id        
    ) ch
    inner join fv_activity a on a.customer_id = ch.customer_id
    inner join fv_serviceorder sorder on a.serviceorder_id = sorder.id
    inner join fv_serviceobject s on s.id = a.serviceobject_id
where a.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent200()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    substring(fv_activitytype.external_id,1,2) as code,
    coalesce(substring(fv_agenda.name, 1, 25) + ' ', '')
        + '
' + coalesce(fv_agenda.street + ' ', '')
        + coalesce(fv_agenda.housenumber + ' ', '')
        + coalesce(fv_agenda.housenumbertext + ' ', '')
        + '
' + coalesce(fv_agenda.city + ' ', '')
    as naw,
    fv_agenda.planstartdt
from fv_agenda
    inner join fv_activitytype on fv_agenda.activitytype_id = fv_activitytype.id
where fv_agenda.engineer_id = 4
    and ((fv_agenda.activitystatustype_id > 30 and fv_agenda.activitystatustype_id < 60) or fv_agenda.activitystatustype_id in (140, 160))
    and not exists (select id from fv_activitystatus where activitystatustype_id in (59, 60, 120, 125) and activity_id = fv_agenda.activity_id)
order by fv_agenda.planstartdt");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr741()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_financial set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr742()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set radiostatus_id = -5 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr743()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set radiostatus_id = 0, enddt = getdate(), roenddt = getdate() where enddt is null and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr744()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set radiostatus_id = 0 where activity_id= '00000000-0000-0000-0000-000000000000'and exists (select fv_debrief_telwerk.id from fv_debrief_telwerk
inner join fv_telwerk on fv_telwerk.id = fv_debrief_telwerk.telwerk_id
and fv_telwerk.meter_id = fv_debrief_meter.meter_id
and fv_debrief_telwerk.activity_id = fv_debrief_meter.activity_id 
and fv_debrief_telwerk.stand is not null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr745()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_telwerk set radiostatus_id = 0 where activity_id= '00000000-0000-0000-0000-000000000000' and stand is not null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activity (id, planstartdt, planenddt, engineer_id, serviceorder_id, activitytype_id, activitystatustype_id, external_id, sub_id, maxstatusdt, name, street, housenumber, housenumbertext, zip, city, phone, serviceobject_id, customer_id, notes, customerexternal_id)
select    '00000000-0000-0000-0000-000000000000', '03/09/2012 14:18:00', '05/10/2012 14:18:00', 4, '00000000-0000-0000-0000-000000000000', activitytype_id, 35, external_id, coalesce(sub_id,0)+1, getdate(), name, street, housenumber, housenumbertext, zip, city, phone, serviceobject_id, customer_id, coalesce(notes, '') + '$form.txtdoorpfnotes$', customerexternal_id
from fv_activity
where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement1032()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, engineer_id, activity_id, activitystatustype_id, statusdt, radiostatus_id)
select newid(), 4, '00000000-0000-0000-0000-000000000000', 30, dateadd(ss, -2, getdate()), 0
from fv_engineer
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement203()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, engineer_id, activity_id, activitystatustype_id, statusdt, radiostatus_id)
select newid(), 4, '00000000-0000-0000-0000-000000000000', 35, getdate(), 0
from fv_engineer
where id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement34()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set radiostatus_id = 0, enddt = getdate(), roenddt = getdate() where enddt is null and activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement35()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief
set radiostatus_id = -5, afhandelingstype_id = 2, cancelreason_id = 0, notes = 'doorgepland. $form.txtdoorpfnotes$'
where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement36()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement7()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set maxstatusdt = getdate(), activitystatustype_id = 60 where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement8()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update    fv_agenda set activitystatustype_id = 60 ,status = 'gereed' where id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement9()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
values (newid(), '00000000-0000-0000-0000-000000000000', 4, getdate(), 60, 0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement10()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
insert into fv_agenda
( id, activity_id, activitytype, activitytype_id, status,
    activitystatustype_id, street, housenumber, housenumbertext,
    city, zip, planstartdt, totaal_algemeen, wijzigingsdt,
    [name], leverings_adres, serviceorder_id, customer_id, serviceobject_id,
    engineer_id, phone, notes, zpnummer)
select    act.id, act.id,
    substring(at.description, 0, 23),
    at.id,
    null,
    act.activitystatustype_id,
    c.street,
    c.housenumber,
    c.housenumbertext,
    c.city,
    c.zip,
    act.planstartdt,
    ltrim(str(so.totaal_algemeen, 10, 2)),
    so.wijzigingsdt,
    coalesce(c.contactsurname + ' ', '' ) + coalesce(c.bedrijfsnaam1, ''),
    coalesce(act.street + ' ', '') + coalesce(act.housenumber + ' ', '') + coalesce(act.housenumbertext + ' ', '') + coalesce(act.zip + ' ', '') + coalesce(act.city, ''),
    act.serviceorder_id,
    so.customer_id,
    act.serviceobject_id,
    act.engineer_id,
    c.phone,
    coalesce(act.notes, '') + 'Test notes',
    c.external_id
from    fv_activity act
    inner join fv_activitytype at on act.activitytype_id = at.id
    left outer join fv_serviceobject so on act.serviceobject_id = so.id
    left outer join fv_customer c on so.customer_id = c.id
where act.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatement10SelectOnly()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    
    substring(at.description, 0, 23)
from    fv_activity act
    inner join fv_activitytype at on act.activitytype_id = at.id
    left outer join fv_serviceobject so on act.serviceobject_id = so.id
    left outer join fv_customer c on so.customer_id = c.id
where act.id = '00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr749()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    getdate() as now
from    fv_engineer
where    id = 4");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr769()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    coalesce(c.contacttitle + ' ', '') + coalesce(c.contactfirstname + ' ', '') + coalesce(c.contactsurname + ' ', '' ) + coalesce(c.bedrijfsnaam1, '') as name,
    ltrim(str(s.totaal_algemeen,10,2)) as total_open,
    c.external_id as cusext,
    s.external_id as serext
from    fv_activity a
    inner join fv_serviceobject s on a.serviceobject_id=s.id
    left outer join fv_customer c on c.id = 0
where    a.id='00000000-0000-0000-0000-000000000000'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent210()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  id,
    type as ia,
        collectiondt as datum,
        notes as tekst
from    fv_collectionhistorie
where customer_id = 0
order by collectiondt desc
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr770()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  id,
    description as ia,
        collectiondt as datum,
        notes as tekst,
        employee,
        attachment
from    fv_collectionhistorie
where id = $form.grdincassoacties.id$
order by collectiondt
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr771()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_meter set radiostatus_id = 0 where activity_id= '00000000-0000-0000-0000-000000000000' and exists (select fv_debrief_telwerk.id from fv_debrief_telwerk
inner join fv_telwerk on fv_telwerk.id = fv_debrief_telwerk.telwerk_id
and fv_telwerk.meter_id = fv_debrief_meter.meter_id
and fv_debrief_telwerk.activity_id = fv_debrief_meter.activity_id 
and fv_debrief_telwerk.stand is not null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementQueryNr772()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_telwerk set radiostatus_id = 0 where activity_id = '00000000-0000-0000-0000-000000000000' and stand is not null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3541()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    maxwerk.id,
    fv_telwerk.telwerk_nr as external_id,
    fv_meter.metertype as description,
    fv_telwerk.telwerktype as tw,
    fv_telwerk.stand,
    floor(fv_debrief_telwerk.stand) as hstand,
    ceiling(fv_telwerk.stand) as vstand,
    fv_telwerk.opnamesoort as opnamesoort
from    fv_telwerk
    inner join fv_meter on fv_telwerk.meter_id = fv_meter.id
                    and fv_meter.isactive = 1
    inner join fv_debrief_telwerk on fv_debrief_telwerk.telwerk_id = fv_telwerk.id
                    and fv_debrief_telwerk.activity_id = '00000000-0000-0000-0000-000000000000'
        inner join fv_telwerk maxwerk on maxwerk.meter_id = fv_meter.id
                                         and maxwerk.telwerktype = fv_telwerk.telwerktype
                                         and maxwerk.isactive = 1
                                         and maxwerk.id in (
                                         select top ( 1 )
                                                tw.id
                                         from   fv_telwerk tw
                                         where  tw.meter_id = fv_meter.id
                                                and tw.telwerktype = fv_telwerk.telwerktype
                                                and tw.telwerk_nr = fv_telwerk.telwerk_nr
                        and tw.isactive = 1
                                         order by tw.opnamedt desc )
where fv_telwerk.isactive = 1 and fv_meter.metertype in ('e','g','s','t')
order by fv_meter.metertype,
        fv_telwerk.telwerktype,
        fv_telwerk.opnamedt desc,
        fv_telwerk.stand desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
        [TestMethod]
        public void TestSelectStatementComponent3541Reduced()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select    maxwerk.id,
    fv_telwerk.telwerk_nr as external_id,
    fv_meter.metertype as description,
    fv_telwerk.telwerktype as tw,
    fv_telwerk.stand,
    floor(fv_debrief_telwerk.stand) as hstand,
    ceiling(fv_telwerk.stand) as vstand,
    fv_telwerk.opnamesoort as opnamesoort
from    fv_telwerk
    inner join fv_meter on fv_telwerk.meter_id = fv_meter.id
                    and fv_meter.isactive = 1
    inner join fv_debrief_telwerk on fv_debrief_telwerk.telwerk_id = fv_telwerk.id
                    and fv_debrief_telwerk.activity_id = '00000000-0000-0000-0000-000000000000'
        inner join fv_telwerk maxwerk on maxwerk.meter_id = fv_meter.id
                                         and maxwerk.telwerktype = fv_telwerk.telwerktype
                                         and maxwerk.isactive = 1
                                         and maxwerk.id in (
                                         select top  1 
                                                tw.id
                                         from   fv_telwerk tw
                                         where  tw.meter_id = fv_meter.id
                                                and tw.telwerktype = fv_telwerk.telwerktype
                                                and tw.telwerk_nr = fv_telwerk.telwerk_nr
                        and tw.isactive = 1
                                         order by tw.opnamedt desc )
where fv_telwerk.isactive = 1 and fv_meter.metertype in ('e','g','s','t')
order by fv_meter.metertype,
        fv_telwerk.telwerktype,
        fv_telwerk.opnamedt desc,
        fv_telwerk.stand desc");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var stringifier = new Stringifier();
            statement.Traverse(stringifier);
            //stringifier.ToSql()
        }
    }
}
