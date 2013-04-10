using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using MacroScope;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class UnitTestDot
    {

        [TestMethod]
        public void TestSelectStatement1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS IsFunctieHersteld FROM fv_debrief_status
WHERE activity_id IN ( SELECT a.id FROM fv_activity a
INNER JOIN fv_activity b ON
a.external_id = b.external_id
AND a.sub_id = b.sub_id
WHERE b.id = '$flow.activity_id$')
AND activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
b -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement2()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT   planner_id
  FROM    fv_activity
  WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement3()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS IsFunctieHersteld FROM fv_debrief_status
WHERE activity_id IN ( SELECT a.id FROM fv_activity a
INNER JOIN fv_activity b ON
a.external_id = b.external_id
AND a.sub_id = b.sub_id
WHERE b.id = '$flow.activity_id$')
AND activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
b -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr490()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    getdate() as nu,
    fv_activity.id
FROM    fv_activity
WHERE    fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr698()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    COALESCE(ontvangst_autorisatie, 0) AS ontvangst_autorisatie
FROM    fv_engineer
WHERE    id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr354()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    fv_customer_main.external_id,
    fv_activity.name,
    fv_activity.name_2,
    Coalesce(fv_activity.street, '') + '
' + COALESCE(fv_activity.zip, '') + ' ' +  COALESCE(fv_activity.city, '') + '
' + CASE WHEN fv_activity.fax IS NULL THEN ''
        ELSE 'FAX: '
    END + COALESCE(fv_activity.fax,'') as overig,
    COALESCE(fv_activity.contactpersoon, '') + COALESCE(' ' + fv_activity.contactpersoon_phone, '') as contact,
    fv_customer.external_id AS functieplaatscode,
    fv_customer.customername AS functieplaatsnaam,
    COALESCE(fv_customer.street, '') + '
' + COALESCE(fv_customer.zip, '') + ' ' + COALESCE(fv_customer.city, '') AS functieplaatsadres
FROM    fv_activity
    LEFT OUTER JOIN fv_customer_main
        ON fv_activity.customer_main_id = fv_customer_main.id
    LEFT OUTER JOIN fv_customer
        ON fv_activity.customer_id = fv_customer.id
WHERE    fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer_main -> external_id;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> street;
fv_activity -> zip;
fv_activity -> city;
fv_activity -> fax;
fv_activity -> fax;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_customer -> external_id;
fv_customer -> customername;
fv_customer -> street;
fv_customer -> zip;
fv_customer -> city;
fv_activity -> customer_main_id;
fv_customer_main -> id;
fv_activity -> customer_id;
fv_customer -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr355()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_customer.external_id, fv_customer.notes, fv_customer.street + ' ' + fv_customer.zip + ' ' + fv_customer.city AS overig, 
                      fv_customer.verantwoordelijk
FROM         fv_customer
where id = $sub.txtFPID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer -> external_id;
fv_customer -> notes;
fv_customer -> street;
fv_customer -> zip;
fv_customer -> city;
fv_customer -> verantwoordelijk;
fv_customer -> id;
sub -> txtFPID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement4Component2170()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_history.id, fv_history.historydt, fv_history.description
FROM         fv_history inner join fv_activity on fv_activity.id = fv_history.activity_id
WHERE fv_activity.id = CONVERT(UNIQUEIDENTIFIER,'$flow.activity_id$') and fv_history.serviceobject_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_history -> id;
fv_history -> historydt;
fv_history -> description;
fv_activity -> id;
fv_history -> activity_id;
fv_activity -> id;
fv_history -> serviceobject_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr359()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_activity.aangemaakt_door_naam, fv_activity.herpland_door_naam, fv_activity.verantwoordelijk, fv_activity.planner_name, fv_region.description AS vestiging, fv_activity.melder, 
                      fv_activity.melder_phone, fv_activity.melddatum, fv_priority.description AS priority, fv_activity.meldkamernummer, fv_productgroep.description AS productgroep, fv_ordersoort.description AS ordersoort
FROM         fv_activity LEFT OUTER JOIN
                      fv_priority ON fv_activity.priority_id = fv_priority.id LEFT OUTER JOIN
                      fv_region ON fv_activity.region_id = fv_region.id LEFT OUTER JOIN
                      fv_productgroep ON fv_activity.productgroep_id = fv_productgroep.id LEFT OUTER JOIN fv_ordersoort on fv_activity.ordersoort_id = fv_ordersoort.id
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> aangemaakt_door_naam;
fv_activity -> herpland_door_naam;
fv_activity -> verantwoordelijk;
fv_activity -> planner_name;
fv_region -> description;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_activity -> melddatum;
fv_priority -> description;
fv_activity -> meldkamernummer;
fv_productgroep -> description;
fv_ordersoort -> description;
fv_activity -> priority_id;
fv_priority -> id;
fv_activity -> region_id;
fv_region -> id;
fv_activity -> productgroep_id;
fv_productgroep -> id;
fv_activity -> ordersoort_id;
fv_ordersoort -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr360()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select taken, normtijd from fv_activity  where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr356()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_history where id = $flow.hist_id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_history -> id;
flow -> hist_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr358()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    fv_serviceobject.external_id, fv_serviceobject.description, fv_customer.external_id AS functieplaats, fv_serviceobject.notes, fv_activity.customer_id
FROM    fv_activity
    LEFT OUTER JOIN fv_customer ON fv_activity.customer_id = fv_customer.id
    LEFT OUTER JOIN fv_serviceobject ON fv_activity.serviceobject_id = fv_serviceobject.id
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_serviceobject -> external_id;
fv_serviceobject -> description;
fv_customer -> external_id;
fv_serviceobject -> notes;
fv_activity -> customer_id;
fv_activity -> customer_id;
fv_customer -> id;
fv_activity -> serviceobject_id;
fv_serviceobject -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement5Component2179()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_history.id, fv_history.historydt, fv_history.description
FROM         fv_history inner join fv_activity on fv_activity.id = fv_history.activity_id
where fv_activity.id = '$flow.activity_id$' and NOT fv_history.serviceobject_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_history -> id;
fv_history -> historydt;
fv_history -> description;
fv_activity -> id;
fv_history -> activity_id;
fv_activity -> id;
fv_history -> serviceobject_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr395()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     verholpen, COALESCE(verholpendt,getdate()) as verholpendt, vervolgactie, vervolgactie_id, vervolgnotes, startdt
FROM         fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr396()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set verholpen=$form.lcverholpen$, verholpendt='$flow.verholpendt$', startdt='$flow.start$', vervolgactie=$form.lcVervolg$ where activity_id = '$flow.activity_id$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> verholpen;
form -> lcverholpen;
fv_debrief -> verholpendt;
fv_debrief -> startdt;
fv_debrief -> vervolgactie;
form -> lcVervolg;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement6()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE activitytype_id WHEN 1 THEN 1 WHEN 2 THEN 1 ELSE 0 END FROM fv_activity WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement7()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(fv_activity.IsNLSFBCodeVerplicht,0) IsNLSFBCodeVerplicht FROM fv_activity WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> IsNLSFBCodeVerplicht;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement8()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(fv_debrief.scannr,0) FROM fv_activity
        INNER JOIN fv_debrief ON fv_debrief.activity_id = fv_activity.id WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> scannr;
fv_debrief -> activity_id;
fv_activity -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement9()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT activitytype_id FROM fv_activity WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement10()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT activitytype_id FROM fv_activity WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement11()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(isafmeldbonvoorklantverplicht, 0)+COALESCE(ishandtekeningverplicht, 0) AS beidenietverplicht
FROM    fv_activity
WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr397()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_debriefoperations (id,activity_id,operations_id,radiostatus_id,done) select newid(),'$flow.activity_id$',id,-1,0 from fv_operations where id not in (select operations_id from fv_debriefoperations where activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debriefoperations -> id;
fv_debriefoperations -> activity_id;
fv_debriefoperations -> operations_id;
fv_debriefoperations -> radiostatus_id;
fv_debriefoperations -> done;
}
subgraph select {
fv_operations -> id;
subgraph select {
fv_debriefoperations -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr630()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set causecode_id = CASE WHEN '$form.cboOorzaak$' = '' THEN null ELSE $form.cboOorzaak$+0 END,
nlsfb_id = CASE WHEN '$form.cboNLSFB$' = '' THEN null ELSE $form.cboNLSFB$+0 END, vervolgactie=$form.lcVervolg$ where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> causecode_id;
form -> cboOorzaak;
fv_debrief -> nlsfb_id;
form -> cboNLSFB;
fv_debrief -> vervolgactie;
form -> lcVervolg;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr631()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(d.causecode_id,a.causecode_id) AS causecode_id, COALESCE(d.nlsfb_id,a.nlsfb_id) AS nlsfb_id, vervolgactie FROM fv_activity a INNER JOIN fv_debrief d
ON activity_id = a.id
WHERE a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> causecode_id;
a -> causecode_id;
d -> nlsfb_id;
a -> nlsfb_id;
fv_activity -> a;
fv_debrief -> d;
fv_activity -> activity_id;
a -> id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement12()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debriefoperations set done = CASE WHEN done = 0 THEN 1 ELSE 0 END where activity_id = '$flow.activity_id$' and operations_id = $form.grdOperations.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debriefoperations -> done;
fv_debriefoperations -> done;
fv_debriefoperations -> activity_id;
fv_debriefoperations -> operations_id;
form -> grdOperations;
grdOperations -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement13Component2206()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select o.id, o.description, CASE WHEN dop.done=1 THEN 'V' ELSE '' END as done, '' as empty from fv_operations o left outer join fv_debriefoperations dop on o.id = dop.operations_id and dop.activity_id = '$flow.activity_id$' AND o.isactive = 1 order by o.orderby");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
o -> id;
o -> description;
dop -> done;
fv_operations -> o;
fv_debriefoperations -> dop;
o -> id;
dop -> operations_id;
dop -> activity_id;
o -> isactive;
o -> orderby;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement14Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT id, external_id + ' ' + description
FROM fv_nlsfb
WHERE isactive = 1
ORDER BY external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_nlsfb -> isactive;
fv_nlsfb -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement15Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_causecode where isactive = 1
order by external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_causecode -> isactive;
fv_causecode -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement16()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CASE WHEN LEN(CONVERT(NVARCHAR(5), SIGNATURE)) > 3 THEN 1
             ELSE CASE WHEN COALESCE(fv_activity.ishandtekeningverplicht, 0) != 1
                       THEN 1
                       ELSE COALESCE(fv_paraafstatus.canescape, 0)
                  END
        END AS IsProceedButtonEnabled
FROM    fv_debrief
        INNER JOIN fv_activity ON fv_debrief.activity_id = fv_activity.id
    LEFT OUTER JOIN fv_paraafstatus ON fv_paraafstatus.id = $form.cboStatus$+0
WHERE   fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> ishandtekeningverplicht;
fv_paraafstatus -> canescape;
fv_debrief -> activity_id;
fv_activity -> id;
fv_paraafstatus -> id;
form -> cboStatus;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement17()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CASE WHEN opdrachtnummer IS NULL THEN 1
             ELSE 0
        END AS IsOpdrachtNummerLeeg
FROM    fv_activity
WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement18()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(isafmeldbonvoorklantverplicht, 0) AS isafmeldbonvoorklantverplicht
FROM    fv_activity
WHERE   fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr410()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select name_signature from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr411()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(signaturedt,getdate()) as nu, signature, 1 as def, opdrachtnummer from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr412()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE    fv_debrief
SET    opdrachtnummer = '$form.txtOpdrachtnr$',
    name_signature = '$form.txtName$',
    signaturedt = CASE WHEN '$flow.screen$' = 'P' THEN NULL ELSE '$flow.signaturedt$' END,
    paraafstatus_id = '$form.cboStatus$'
WHERE    activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> signaturedt;
fv_debrief -> paraafstatus_id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr724()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
SELECT NEWID(), '$flow.activity_id$', $app.userid$, getdate(), 54, 0
FROM fv_engineer
WHERE id = $app.userID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
app -> userID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement19Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT id, description FROM fv_paraafstatus WHERE isactive = 1 ORDER BY id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_paraafstatus -> isactive;
fv_paraafstatus -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement20()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set name_signature= '$form.txtName$', signaturedt= '$flow.signaturedt$',paraafstatus_id='$form.cboStatus$' where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> name_signature;
fv_debrief -> signaturedt;
fv_debrief -> paraafstatus_id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement21()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail  where labour_id in (select id from fv_labour where activity_id = '$flow.activity_id$' and enddt is null and labourstatus_id=2)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour_detail -> labour_id;
subgraph select {
fv_labour -> id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr398()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT fv_labour.id, rostartdt, COALESCE(roenddt, GETDATE()) AS nu, DATEPART(hh, CASE WHEN ld.uren IS NULL THEN '1900-01-01T' + CASE WHEN LEN(CONVERT(NVARCHAR, (CASE WHEN DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) < 0 THEN 0 ELSE (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) + CASE WHEN DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) % 15 > 0 THEN 15 ELSE 0 END) / 60 END))) = 1 THEN '0' ELSE '' END + CONVERT(NVARCHAR, (CASE WHEN DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) < 0 THEN 0 ELSE (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) + CASE WHEN DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) % 15 > 0 THEN 15 ELSE 0 END) / 60 END)) + ':' + CASE WHEN (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) - (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) / 60) * 60) < 10 THEN '00' WHEN (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) - (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) / 60) * 60) <= 15 THEN '15' WHEN (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) - (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) / 60) * 60) <= 30 THEN '30' WHEN (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) - (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) / 60) * 60) <= 45 THEN '45' ELSE '00' END + ':00' ELSE ld.uren END) AS uren, DATEPART(mi, CASE WHEN ld.uren IS NULL THEN '1900-01-01T' + CASE WHEN LEN(CONVERT(NVARCHAR, (CASE WHEN DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) < 0 THEN 0 ELSE (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) + CASE WHEN DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) % 15 > 0 THEN 15 ELSE 0 END) / 60 END))) = 1 THEN '0' ELSE '' END + CONVERT(NVARCHAR, (CASE WHEN DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) < 0 THEN 0 ELSE (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) + CASE WHEN DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) % 15 > 0 THEN 15 ELSE 0 END) / 60 END)) + ':' + CASE WHEN (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) - (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) / 60) * 60) < 10 THEN '00' WHEN (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) - (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) / 60) * 60) <= 15 THEN '15' WHEN (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) - (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) / 60) * 60) <= 30 THEN '30' WHEN (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) - (DATEDIFF(mi, rostartdt, COALESCE(roenddt, GETDATE())) / 60) * 60) <= 45 THEN '45' ELSE '00' END + ':00' ELSE ld.uren END) AS minuten FROM fv_labour LEFT OUTER JOIN fv_labour_detail ld ON ld.labour_id = fv_labour.id AND ld.labour_type_id = 1 WHERE fv_labour.activity_id = '$flow.activity_id$' AND enddt IS NULL AND labourstatus_id = 2 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> id;
ld -> uren;
ld -> uren;
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr400()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ld.labour_type_id as id from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.activity_id = '$flow.activity_id$' and enddt is null and labourstatus_id=2
UNION
(select id from fv_labour_type where external_id = '0708' and not exists (select uren from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.activity_id = '$flow.activity_id$' and enddt is null and labourstatus_id=2))
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> labour_type_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
fv_labour_type -> external_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr404()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$form.txtLabID$', '$flow.activity_id$', 1, -1, DATEADD(mi, $form.lcMinuten1$, DATEADD(hh, $form.lcUren1$, SUBSTRING(Convert(nvarchar, GETDATE(), 20), 1, 10) + 'T00:00:00'))
FROM fv_engineer
WHERE id = $app.userid$
    AND '$form.lcUren1$' + ':' + '$form.lcMinuten1$' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
form -> lcMinuten1;
form -> lcUren1;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr405()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren)
SELECT NEWID(), '$form.txtLabID$', '$flow.activity_id$', 10, -1, DATEADD(mi, $form.lcMinuten2$, DATEADD(hh, $form.lcUren2$, SUBSTRING(Convert(nvarchar, GETDATE(), 20), 1, 10) + 'T00:00:00'))
FROM fv_engineer
WHERE id = $app.userid$
    AND '$form.lcUren2$' + ':' + '$form.lcMinuten2$' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
form -> lcMinuten2;
form -> lcUren2;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr406()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$form.txtLabID$', '$flow.activity_id$', id, -1, DATEADD(mi, $form.lcMinuten3$, DATEADD(hh, $form.lcUren3$, SUBSTRING(CONVERT(NVARCHAR, GETDATE(), 20), 1, 10) + 'T00:00:00'))
FROM fv_labour_type
WHERE id = $form.cb3$
    AND '$form.lcUren3$' + ':' + '$form.lcMinuten3$' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
form -> lcMinuten3;
form -> lcUren3;
fv_labour_type -> id;
form -> cb3;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr546()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id,rostartdt,coalesce(roenddt,getdate()) as nu from fv_labour where activity_id = '$flow.activity_id$' and enddt is null and labourstatus_id=2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr547()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    CASE WHEN LEN(CONVERT(NVARCHAR, SUM(DATEPART(hh, uren)) + ( SUM(DATEPART(mi, uren)) / 60 ))) = 1 THEN '0' ELSE '' END
        + CONVERT(NVARCHAR, SUM(DATEPART(hh, uren)) + ( SUM(DATEPART(mi, uren)) / 60 )) + ':'
        + CASE WHEN LEN(CONVERT(NVARCHAR, ( SUM(DATEPART(mi, uren)) % 60 ))) = 1 THEN '0' ELSE '' END
        + CONVERT(NVARCHAR, ( SUM(DATEPART(mi, uren)) % 60 ))
    AS total
FROM fv_labour_detail
    INNER JOIN fv_labour
        ON fv_labour_detail.labour_id = fv_labour.id
WHERE    fv_labour.activity_id IN (SELECT a.id FROM fv_activity a INNER JOIN fv_activity b ON a.serviceorder_id = b.serviceorder_id WHERE b.id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> labour_id;
fv_labour -> id;
fv_labour -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> serviceorder_id;
b -> serviceorder_id;
b -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr549()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT
    DATEPART(hh, CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END) AS uren,
    DATEPART(mi, CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END) AS minuten
FROM fv_labour
    LEFT OUTER JOIN fv_labour_detail ld
        ON ld.labour_id = fv_labour.id
            AND ld.labour_type_id = 10
WHERE fv_labour.activity_id = '$flow.activity_id$'
    AND enddt IS NULL
    AND labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr550()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    DATEPART(hh, CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END) AS uren,
    DATEPART(mi, CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END) AS minuten,
    ld.labour_type_id
FROM fv_labour
    LEFT OUTER JOIN fv_labour_detail ld
        ON ld.labour_id = fv_labour.id
            AND NOT ld.labour_type_id IN (1, 2, 3, 10)
WHERE fv_labour.activity_id = '$flow.activity_id$'
    AND fv_labour.enddt IS NULL
    AND fv_labour.labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
ld -> uren;
ld -> uren;
ld -> labour_type_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr703()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$form.txtLabID$', '$flow.activity_id$', 2, -1, DATEADD(mi, $form.lcMinuten4$, DATEADD(hh, $form.lcUren4$, SUBSTRING(Convert(nvarchar, GETDATE(), 20), 1, 10) + 'T00:00:00'))
FROM fv_engineer
WHERE id = $app.userid$
    AND '$form.lcUren4$' + ':' + '$form.lcMinuten4$' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
form -> lcMinuten4;
form -> lcUren4;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr704()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$form.txtLabID$', '$flow.activity_id$', 3, -1, DATEADD(mi, $form.lcMinuten5$, DATEADD(hh, $form.lcUren5$, SUBSTRING(Convert(nvarchar, GETDATE(), 20), 1, 10) + 'T00:00:00'))
FROM fv_engineer
WHERE id = $app.userid$
    AND '$form.lcUren5$' + ':' + '$form.lcMinuten5$' <> '0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
form -> lcMinuten5;
form -> lcUren5;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr705()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT
    DATEPART(hh, CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END) AS uren,
    DATEPART(mi, CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END) AS minuten
FROM fv_labour
    LEFT OUTER JOIN fv_labour_detail ld
        ON ld.labour_id = fv_labour.id
            AND ld.labour_type_id = 2
WHERE fv_labour.activity_id = '$flow.activity_id$'
    AND enddt IS NULL
    AND labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr706()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT
    DATEPART(hh, CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END) AS uren,
    DATEPART(mi, CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END) AS minuten
FROM fv_labour
    LEFT OUTER JOIN fv_labour_detail ld
        ON ld.labour_id = fv_labour.id
            AND ld.labour_type_id = 3
WHERE fv_labour.activity_id = '$flow.activity_id$'
    AND enddt IS NULL
    AND labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestListQuerylstCheck()
        {
            var statement = MacroScope.Factory.CreateStatement(@"(select 1,'U heeft meer dan 24 uur opgegeven.',1 as sortorder from fv_activity a where a.id = '$flow.activity_id$' and (DATEPART(hh,convert(datetime,'$form.tm1$'))+DATEPART(hh,convert(datetime,'$form.tm2$'))+DATEPART(hh,convert(datetime,'$form.tm3$')))*60 + 
DATEPART(mi,convert(datetime,'$form.tm1$'))+DATEPART(mi,convert(datetime,'$form.tm2$'))+DATEPART(mi,convert(datetime,'$form.tm3$'))>(24*60)
) UNION (select 1, 'klaar', 9 as sortorder from fv_engineer where id = '$app.UserID$') order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> a;
a -> id;
fv_engineer -> id;
fv_engineer -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement22Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT id, description
FROM fv_labour_type
WHERE isactive = 1
    AND NOT id IN (1, 2, 3, 10)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_type -> isactive;
fv_labour_type -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr407()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     COALESCE(CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))+(sum(DATEPART(mi, fv_labour_detail.uren))/60))) = 1 THEN '0' ELSE '' END +  CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))+(sum(DATEPART(mi, fv_labour_detail.uren))/60)) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60))) = 1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60)),'00:00') AS normaal
FROM         fv_labour_detail right outer JOIN
                      fv_labour ON fv_labour_detail.labour_id = fv_labour.id and fv_labour_detail.labour_type_id = 1
WHERE     fv_labour.activity_id = '$flow.activity_id$' and not fv_labour.enddt is null and fv_labour.engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> labour_id;
fv_labour -> id;
fv_labour_detail -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr408()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     COALESCE(CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))+(sum(DATEPART(mi, fv_labour_detail.uren))/60))) = 1 THEN '0' ELSE '' END +  CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))+(sum(DATEPART(mi, fv_labour_detail.uren))/60)) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60))) = 1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60)),'00:00') AS normaal
FROM         fv_labour_detail right outer JOIN
                      fv_labour ON fv_labour_detail.labour_id = fv_labour.id and fv_labour_detail.labour_type_id = 2
WHERE    fv_labour.activity_id = '$flow.activity_id$' and not fv_labour.enddt is null and fv_labour.engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> labour_id;
fv_labour -> id;
fv_labour_detail -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr409()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     COALESCE(CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))+(sum(DATEPART(mi, fv_labour_detail.uren))/60))) = 1 THEN '0' ELSE '' END +  CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))+(sum(DATEPART(mi, fv_labour_detail.uren))/60)) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60))) = 1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60)),'00:00') AS normaal
FROM         fv_labour_detail right outer JOIN
                      fv_labour ON fv_labour_detail.labour_id = fv_labour.id and fv_labour_detail.labour_type_id not in (1,2)
WHERE fv_labour.activity_id = '$flow.activity_id$' and not fv_labour.enddt is null and fv_labour.engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> labour_id;
fv_labour -> id;
fv_labour_detail -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement23Component2284()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_labour.id, CONVERT(nvarchar,fv_labour.rostartdt,105) + ' ' + CASE WHEN LEN(convert(nvarchar,Datepart(hh,fv_labour.rostartdt)) )=1 THEN '0' ELSE '' END + convert(nvarchar,Datepart(hh,fv_labour.rostartdt)) + ':' + CASE WHEN LEN(convert(nvarchar,Datepart(mi,fv_labour.rostartdt)) )=1 THEN '0' ELSE '' END + convert(nvarchar,Datepart(mi,fv_labour.rostartdt)) as van_tot, CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))) AS normaal, CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail_1.uren))))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail_1.uren))) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail_1.uren))))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail_1.uren))) AS reis, CASE WHEN LEN(CONVERT(nvarchar, (SUM(DATEPART(HH, fv_labour_detail_2.uren)) + SUM(DATEPART(mi, fv_labour_detail_2.uren))/60)))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, (SUM(DATEPART(HH, fv_labour_detail_2.uren)) + SUM(DATEPART(mi, fv_labour_detail_2.uren))/60)) + ':' + CASE WHEN LEN(CONVERT(nvarchar, (SUM(DATEPART(mi,fv_labour_detail_2.uren))%60)))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, SUM(DATEPART(mi,fv_labour_detail_2.uren))%60) AS OVR,
1 AS CanChange
FROM fv_labour left outer join fv_labour_detail on fv_labour.id = fv_labour_detail.labour_id and fv_labour_detail.labour_type_id = 1 left outer join fv_labour_detail fv_labour_detail_1 on fv_labour.id = fv_labour_detail_1.labour_id and fv_labour_detail_1.labour_type_id = 2 left outer join fv_labour_detail fv_labour_detail_2 on fv_labour.id = fv_labour_detail_2.labour_id and fv_labour_detail_2.labour_type_id not in (1,2)
WHERE fv_labour.activity_id = '$flow.activity_id$' and not fv_labour.enddt is null and fv_labour.engineer_id = $app.userid$
group by fv_labour.id, fv_labour.rostartdt, fv_labour.roenddt
UNION
SELECT     fv_labour.id, CONVERT(nvarchar,fv_labour.rostartdt,105) + ' ' + CASE WHEN LEN(convert(nvarchar,Datepart(hh,fv_labour.rostartdt)) )=1 THEN '0' ELSE '' END + convert(nvarchar,Datepart(hh,fv_labour.rostartdt)) + ':' + CASE WHEN LEN(convert(nvarchar,Datepart(mi,fv_labour.rostartdt)) )=1 THEN '0' ELSE '' END + convert(nvarchar,Datepart(mi,fv_labour.rostartdt)) as van_tot, CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail.uren))) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))) AS normaal, CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail_1.uren))))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(HH, fv_labour_detail_1.uren))) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail_1.uren))))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail_1.uren))) AS reis, CASE WHEN LEN(CONVERT(nvarchar, (SUM(DATEPART(HH, fv_labour_detail_2.uren)) + SUM(DATEPART(mi, fv_labour_detail_2.uren))/60)))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, (SUM(DATEPART(HH, fv_labour_detail_2.uren)) + SUM(DATEPART(mi, fv_labour_detail_2.uren))/60)) + ':' + CASE WHEN LEN(CONVERT(nvarchar, (SUM(DATEPART(mi,fv_labour_detail_2.uren))%60)))=1 THEN '0' ELSE '' END + CONVERT(nvarchar, SUM(DATEPART(mi,fv_labour_detail_2.uren))%60) AS OVR,
0 AS CanChange
FROM fv_labour left outer join fv_labour_detail on fv_labour.id = fv_labour_detail.labour_id and fv_labour_detail.labour_type_id = 1 left outer join fv_labour_detail fv_labour_detail_1 on fv_labour.id = fv_labour_detail_1.labour_id and fv_labour_detail_1.labour_type_id = 2 left outer join fv_labour_detail fv_labour_detail_2 on fv_labour.id = fv_labour_detail_2.labour_id and fv_labour_detail_2.labour_type_id not in (1,2)
WHERE fv_labour.activity_id IN (select a.id from fv_activity a inner join fv_activity b on a.serviceorder_id = b.serviceorder_id where b.id = '$flow.activity_id$') and fv_labour.enddt is null and fv_labour.engineer_id = $app.userid$
group by fv_labour.id, fv_labour.rostartdt, fv_labour.roenddt

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> id;
fv_labour -> rostartdt;
fv_labour -> rostartdt;
fv_labour -> rostartdt;
fv_labour -> rostartdt;
fv_labour -> rostartdt;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail_1 -> uren;
fv_labour_detail_1 -> uren;
fv_labour_detail_1 -> uren;
fv_labour_detail_1 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> fv_labour_detail_1;
fv_labour -> id;
fv_labour_detail_1 -> labour_id;
fv_labour_detail_1 -> labour_type_id;
fv_labour_detail -> fv_labour_detail_2;
fv_labour -> id;
fv_labour_detail_2 -> labour_id;
fv_labour_detail_2 -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> engineer_id;
app -> userid;
fv_labour -> id;
fv_labour -> rostartdt;
fv_labour -> roenddt;
fv_labour -> id;
fv_labour -> rostartdt;
fv_labour -> rostartdt;
fv_labour -> rostartdt;
fv_labour -> rostartdt;
fv_labour -> rostartdt;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail_1 -> uren;
fv_labour_detail_1 -> uren;
fv_labour_detail_1 -> uren;
fv_labour_detail_1 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour_detail_2 -> uren;
fv_labour -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> fv_labour_detail_1;
fv_labour -> id;
fv_labour_detail_1 -> labour_id;
fv_labour_detail_1 -> labour_type_id;
fv_labour_detail -> fv_labour_detail_2;
fv_labour -> id;
fv_labour_detail_2 -> labour_id;
fv_labour_detail_2 -> labour_type_id;
fv_labour -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> serviceorder_id;
b -> serviceorder_id;
b -> id;
}
fv_labour -> enddt;
fv_labour -> engineer_id;
app -> userid;
fv_labour -> id;
fv_labour -> rostartdt;
fv_labour -> roenddt;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement24()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour (id, startdt, rostartdt, enddt, roenddt, radiostatus_id, activity_id, labourstatus_id, engineer_id) SELECT  '$flow.lab$', getdate(), getdate() , getdate(), getdate() ,  3, '$flow.activity_id$', 2, $app.userid$ FROM fv_engineer WHERE fv_engineer.id = $app.UserId$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour -> id;
fv_labour -> startdt;
fv_labour -> rostartdt;
fv_labour -> enddt;
fv_labour -> roenddt;
fv_labour -> radiostatus_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> engineer_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
app -> UserId;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement25()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail where labour_id = '$sub.grdUren.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour_detail -> labour_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement26()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour where id = '$sub.grdUren.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr437()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select getdate() as nu, id, 0 as def from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement27Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT fv_cancelreason.id, fv_cancelreason.description FROM fv_cancelreason WHERE fv_cancelreason.isactive = 1 ORDER BY fv_cancelreason.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_cancelreason -> id;
fv_cancelreason -> description;
fv_cancelreason -> isactive;
fv_cancelreason -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement28()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set planstartdt = '$flow.newdt$' where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> planstartdt;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement29()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set restduur=($sub.txtUren$*60)+$sub.lcMinuten$ where activity_id = '$flow.activity_id$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> restduur;
sub -> txtUren;
sub -> lcMinuten;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr436()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id,startdt,COALESCE(roenddt,getdate()) as nu from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id=2 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement30()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set roenddt = '$flow.enddt$' where activity_id = '$flow.activity_id$' and labourstatus_id=2 and enddt is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour -> roenddt;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr414()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT
    CASE WHEN LEN(CONVERT(nvarchar, SUM(DATEPART(HH, fv_labour_detail.uren)) + (SUM(DATEPART(mi, fv_labour_detail.uren)) / 60))) = 1 THEN '0' ELSE '' END
    +  CONVERT(nvarchar, SUM(DATEPART(HH, fv_labour_detail.uren)) + (SUM(DATEPART(mi, fv_labour_detail.uren)) / 60)) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60))) = 1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60)) AS normaal
FROM fv_labour_detail
    INNER JOIN fv_labour_type
        ON fv_labour_detail.labour_type_id = fv_labour_type.id
    INNER JOIN fv_labour
        ON fv_labour_detail.labour_id = fv_labour.id
WHERE fv_labour_type.id IN (2, 10)
    AND fv_labour.activity_id IN
        (SELECT a.id
            FROM fv_activity a
            INNER JOIN fv_activity b on a.serviceorder_id = b.serviceorder_id
            WHERE b.id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_type -> id;
fv_labour_detail -> labour_id;
fv_labour -> id;
fv_labour_type -> id;
fv_labour -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> serviceorder_id;
b -> serviceorder_id;
b -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr415()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT
    CASE WHEN LEN(CONVERT(nvarchar, SUM(DATEPART(HH, fv_labour_detail.uren)) + (SUM(DATEPART(mi, fv_labour_detail.uren)) / 60))) = 1 THEN '0' ELSE '' END
    +  CONVERT(nvarchar, SUM(DATEPART(HH, fv_labour_detail.uren)) + (SUM(DATEPART(mi, fv_labour_detail.uren)) / 60)) + ':' + CASE WHEN LEN(CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60))) = 1 THEN '0' ELSE '' END + CONVERT(nvarchar, sum(DATEPART(mi, fv_labour_detail.uren))-((sum(DATEPART(mi, fv_labour_detail.uren))/60)*60)) AS normaal
FROM fv_labour_detail
    INNER JOIN fv_labour_type
        ON fv_labour_detail.labour_type_id = fv_labour_type.id
    INNER JOIN fv_labour
        ON fv_labour_detail.labour_id = fv_labour.id
WHERE NOT fv_labour_type.id IN (2, 10)
    AND fv_labour.activity_id IN
        (SELECT a.id
            FROM fv_activity a
            INNER JOIN fv_activity b on a.serviceorder_id = b.serviceorder_id
            WHERE b.id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_type -> id;
fv_labour_detail -> labour_id;
fv_labour -> id;
fv_labour_type -> id;
fv_labour -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> serviceorder_id;
b -> serviceorder_id;
b -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr680()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'NB: ' + o.description as omschrijving from fv_operations o inner join fv_debriefoperations do on do.operations_id = o.id where do.activity_id = '$flow.activity_id$' and o.id = 9 and do.done=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
o -> description;
fv_operations -> o;
fv_debriefoperations -> do;
do -> operations_id;
o -> id;
do -> activity_id;
o -> id;
do -> done;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr682()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(overigekosten,'') + ' ' + COALESCE(convert(nvarchar,overigekosten_bedrag),'') as overig from fv_debrief  where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement31Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"    SELECT    fv_labour.rostartdt,
        fv_labour.roenddt,
        COALESCE(e.username, m.description) AS monteur,
        DATEADD(mi, SUM(DATEPART(hour, COALESCE(fv_labour_detail.uren, '1900-01-01T00:00:00'))) * 60
                + SUM(DATEPART(mi, COALESCE(fv_labour_detail.uren, '1900-01-01T00:00:00'))), '1900-01-01T00:00:00') AS tijd,
        CASE WHEN fv_labour_detail.labour_type_id IN (2, 10 ) THEN 'reis' ELSE 'werk' END AS type
    FROM    fv_labour
        LEFT OUTER JOIN fv_labour_detail
            ON fv_labour_detail.labour_id = fv_labour.id
--                AND fv_labour_detail.labour_type_id IN (2, 10 )
        LEFT OUTER JOIN fv_engineer e
            ON fv_labour.engineer_id = e.id
        LEFT OUTER JOIN fv_medewerker m
            ON fv_labour.medewerker_id = m.id
    WHERE    fv_labour.activity_id IN (SELECT  a.id FROM fv_activity a INNER JOIN fv_activity b ON a.serviceorder_id = b.serviceorder_id WHERE b.id = '$flow.activity_id$' )
    GROUP BY fv_labour.rostartdt,
            fv_labour.roenddt,
            e.username,
            m.description,
            CASE WHEN fv_labour_detail.labour_type_id IN (2, 10 ) THEN 'reis' ELSE 'werk' END
    HAVING  SUM(DATEPART(hour, COALESCE(fv_labour_detail.uren, '1900-01-01T00:00:00'))) * 60 + SUM(DATEPART(mi, COALESCE(fv_labour_detail.uren, '1900-01-01T00:00:00'))) <> 0
--UNION
--    SELECT    fv_labour.rostartdt,
--        fv_labour.roenddt,
--        COALESCE(e.username, m.description) AS monteur,
--        DATEADD(mi, SUM(DATEPART(hour, COALESCE(fv_labour_detail.uren, '1900-01-01T00:00:00'))) * 60
--            + SUM(DATEPART(mi, COALESCE(fv_labour_detail.uren, '1900-01-01T00:00:00'))), '1900-01-01T00:00:00') AS tijd,
--        'werk' AS type
--    FROM    fv_labour
--        LEFT OUTER JOIN fv_labour_detail
--            ON fv_labour_detail.labour_id = fv_labour.id
--                AND fv_labour_detail.labour_type_id NOT IN (2, 10 )
--        LEFT OUTER JOIN fv_engineer e
--            ON fv_labour.engineer_id = e.id
--        LEFT OUTER JOIN fv_medewerker m
--            ON fv_labour.medewerker_id = m.id
--    WHERE    fv_labour.activity_id IN (SELECT a.id FROM fv_activity a INNER JOIN fv_activity b ON a.serviceorder_id = b.serviceorder_id WHERE b.id = '$flow.activity_id$')
--    GROUP BY fv_labour.rostartdt,
--        fv_labour.roenddt,
--        e.username,
--        m.description
--    HAVING    SUM(DATEPART(hour, COALESCE(fv_labour_detail.uren, '1900-01-01T00:00:00'))) * 60 + SUM(DATEPART(mi, COALESCE(fv_labour_detail.uren, '1900-01-01T00:00:00'))) <> 0
ORDER BY rostartdt");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> rostartdt;
fv_labour -> roenddt;
e -> username;
m -> description;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> labour_id;
fv_labour -> id;
fv_engineer -> e;
fv_labour -> engineer_id;
e -> id;
fv_medewerker -> m;
fv_labour -> medewerker_id;
m -> id;
fv_labour -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> serviceorder_id;
b -> serviceorder_id;
b -> id;
}
fv_labour -> rostartdt;
fv_labour -> roenddt;
e -> username;
m -> description;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> uren;
fv_activity -> rostartdt;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr370()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_serviceobject.external_id, fv_serviceobject.description, fv_customer.external_id AS functieplaats, fv_customer.id,fv_serviceobject.id as eqid, 1 as sortorder
FROM         fv_serviceobject  LEFT OUTER JOIN
                      fv_customer ON fv_serviceobject.customer_id = fv_customer.id
where fv_serviceobject.external_id like '%$flow.EqExt$' and '$flow.EqExt$'<>''
UNION
SELECT '$flow.EqExt$' as external_id,'' as description,'' as functieplaats,null as id,null as eqid, 2 as sortorder from fv_debrief where activity_id = '$flow.activity_id$' and COALESCE(scannr,'')<>''
order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_serviceobject -> external_id;
fv_serviceobject -> description;
fv_customer -> external_id;
fv_customer -> id;
fv_serviceobject -> id;
fv_serviceobject -> customer_id;
fv_customer -> id;
fv_serviceobject -> external_id;
fv_debrief -> activity_id;
fv_debrief -> scannr;
fv_debrief -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr473()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select problemcode_id, causecode_id, solutioncode_id from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr492()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select s.external_id, s.description from fv_serviceobject s inner join fv_activity a on a.serviceobject_id = s.id where a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
s -> external_id;
s -> description;
fv_serviceobject -> s;
fv_activity -> a;
a -> serviceobject_id;
s -> id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr535()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set serviceobject_id = CASE WHEN '$form.txtEquipmentID$' = '' THEN null else '$form.txtEquipmentID$' END where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> serviceobject_id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr536()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set solutioncode_id= CASE WHEN '$form.cbSol$' = '' THEN null ELSE $form.cbSol$+0 END where activity_id = '$flow.activity_id$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> solutioncode_id;
form -> cbSol;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr537()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set scandt=getdate(),scannr=CASE WHEN '$form.txtEquipment$' = '' THEN null else '$form.txtEquipment$' END where activity_id = '$flow.activity_id$';");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> scandt;
fv_debrief -> scannr;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestListQuerylstCheck2()
        {
            var statement = MacroScope.Factory.CreateStatement(@"(select 1,'Equipment niet gevonden. Toch accepteren?',1 as sortorder from fv_engineer where id = $app.userid$ and '$form.txtEquipment$'<> '' and NOT EXISTS (select id from fv_serviceobject where external_id like '%$form.txtEquipment$')) UNION (select 1, 'klaar', 9 as sortorder from fv_engineer where id = '$app.UserID$') order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
fv_serviceobject -> external_id;
}
fv_engineer -> id;
fv_engineer -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement32Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_solutioncode where isactive = 1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_solutioncode -> isactive;
fv_solutioncode -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr497()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'true' as def, customer_main_id from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement33Component3031()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    fv_customer.id,
    fv_customer.external_id,
    fv_customer.customername AS oms,
    fv_customer.customer_main_id,
    fv_customer_main.name,
    fv_customer_main.name2
FROM    fv_customer
    INNER JOIN fv_customer_main
        ON fv_customer.customer_main_id=fv_customer_main.id
WHERE    LEN(fv_customer.external_id) = CASE WHEN '$sub.chMain$'='true' THEN 8 ELSE LEN(fv_customer.external_id) END
    AND fv_customer.isactive=1
    AND fv_customer.external_id LIKE '$sub.txtFP$'+'%'
    AND fv_customer.customername LIKE '%$sub.txtName$%'
    AND '$flow.zoek$'='1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer -> id;
fv_customer -> external_id;
fv_customer -> customername;
fv_customer -> customer_main_id;
fv_customer_main -> name;
fv_customer_main -> name2;
fv_customer -> customer_main_id;
fv_customer_main -> id;
fv_customer -> external_id;
fv_customer -> external_id;
fv_customer -> isactive;
fv_customer -> external_id;
fv_customer -> customername;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement34()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET    activitytype_id = $form.lcbType$,
--activitytype_id = CASE WHEN '$form.cbType$'='' THEN null ELSE  '$form.cbType$' END,
    capability_id = CASE WHEN '$form.cbArtikelGroep$'='' THEN null ELSE '$form.cbArtikelGroep$' END,
    productgroep_id = CASE WHEN '$form.cbProductgroep$'='' THEN null ELSE '$form.cbProductgroep$' END,
    customer_main_id = $sub.grdFP2.klant$,
    customer_id = $sub.grdFP2.id$,
    functieplaatsnaam = '$sub.grdFP2.name$',
    description = '$form.txtDescNW$',
    opdrachtnummer = '$form.txtOpdrnr$',
    name='$sub.grdFP2.klantname$',
    name_2='$sub.grdFP2.klantname2$'
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitytype_id;
form -> lcbType;
fv_activity -> capability_id;
fv_activity -> productgroep_id;
fv_activity -> customer_main_id;
sub -> grdFP2;
grdFP2 -> klant;
fv_activity -> customer_id;
sub -> grdFP2;
grdFP2 -> id;
fv_activity -> functieplaatsnaam;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr426()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_customer.external_id, fv_customer.notes, fv_customer.street + ' ' + fv_customer.zip + ' ' + fv_customer.city AS overig, 
                      fv_customer.verantwoordelijk
FROM         fv_customer
where external_id = '$sub.txtFPcode$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer -> external_id;
fv_customer -> notes;
fv_customer -> street;
fv_customer -> zip;
fv_customer -> city;
fv_customer -> verantwoordelijk;
fv_customer -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement35Component2337()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, Coalesce(name,'') + '/' + Coalesce(name2,'') + '/' + Coalesce(city,'') as oms,name,name2 from fv_customer_main where city like '$sub.txtCity$' + '%' and name like '%' + '$sub.txtName$' + '%' and $flow.zoek$=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer_main -> city;
fv_customer_main -> name;
flow -> zoek;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement36()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitytype_id=CASE WHEN '$form.cbType$' = '' THEN null ELSE $form.cbType$+0 END where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitytype_id;
form -> cbType;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement37()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set capability_id= CASE WHEN '$form.cbArtikelGroep$' = '' THEN null ELSE '$form.cbArtikelGroep$' END, productgroep_id=CASE WHEN '$form.cbProductgroep$' = '' THEN null ELSE '$form.cbProductgroep$' END, functieplaatsnaam=CASE WHEN COALESCE(customer_id,0)=0 THEN '$form.txtFPNB$' ELSE functieplaatsnaam END where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> capability_id;
fv_activity -> productgroep_id;
fv_activity -> functieplaatsnaam;
fv_activity -> customer_id;
fv_activity -> functieplaatsnaam;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement38()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set customer_main_id = $sub.grdKlant.id$, name='$sub.grdKlant.name$', name_2='$sub.grdKlant.name2$', description = '$form.txtDescNW$', opdrachtnummer = '$form.txtOpdrnr$'  where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> customer_main_id;
sub -> grdKlant;
grdKlant -> id;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement39()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET     activitytype_id = $form.lcbType$,    
--activitytype_id = $form.cbType$,
    description = REPLACE('$form.txtDescNW$', '
', ' '),
    opdrachtnummer = '$form.txtOpdrnr$',
    capability_id = $form.cbArtikelGroep$,
    ordersoort_id = $form.txtOrdersoort$
where    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitytype_id;
form -> lcbType;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> capability_id;
form -> cbArtikelGroep;
fv_activity -> ordersoort_id;
form -> txtOrdersoort;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr432()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_ordersoort where external_id = 'ZZ01'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_ordersoort -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr433()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE    fv_activity
SET    activitytype_id = $form.lcbType$,
--activitytype_id = $form.cbType$,
    description = REPLACE('$form.txtDescNW$', '
', ' '),
    opdrachtnummer = '$form.txtOpdrnr$',
    capability_id = $form.cbArtikelGroep$,
    productgroep_id = $form.cbProductgroep$,
    ordersoort_id = $form.txtOrdersoort$,
    functieplaatsnaam = CASE WHEN COALESCE(customer_id,0)=0 THEN '$form.txtFPNB$' ELSE functieplaatsnaam END,
    samenvatting = '$form.txtSamenv$'
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitytype_id;
form -> lcbType;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> capability_id;
form -> cbArtikelGroep;
fv_activity -> productgroep_id;
form -> cbProductgroep;
fv_activity -> ordersoort_id;
form -> txtOrdersoort;
fv_activity -> functieplaatsnaam;
fv_activity -> customer_id;
fv_activity -> functieplaatsnaam;
fv_activity -> samenvatting;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr467()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    COALESCE(fv_activity.activitytype_id, 'null') AS activitytype_id,
    fv_activity.description,
    fv_activity.opdrachtnummer,
    COALESCE(fv_activity.capability_id, 'null') AS capability_id,
    fv_activity.sub_id,
    fv_activity.serviceordernumber,
    COALESCE(fv_activity.productgroep_id, 2) AS productgroep_id,
    fv_activity.equipmentname,
    fv_activity.functieplaatsnaam,
    fv_activity.contactpersoon,
    fv_customer_main.name
FROM    fv_activity
    LEFT OUTER JOIN fv_customer_main ON fv_activity.customer_main_id = fv_customer_main.id
WHERE    fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> activitytype_id;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> capability_id;
fv_activity -> sub_id;
fv_activity -> serviceordernumber;
fv_activity -> productgroep_id;
fv_activity -> equipmentname;
fv_activity -> functieplaatsnaam;
fv_activity -> contactpersoon;
fv_customer_main -> name;
fv_activity -> customer_main_id;
fv_customer_main -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr654()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT 
COALESCE(fv_activity.ministoringsboek, CASE WHEN fv_activity.ordersoort_id = 1 THEN UPPER(COALESCE(at.description, '')) + '
' + 'Melding: ' + COALESCE(SUBSTRING(CONVERT(nvarchar, fv_activity.melddatum, 13), 1, 11),'')  + ' ' + COALESCE(fv_activity.melder, '') + ' ' + COALESCE(fv_activity.melder_phone, '') + '
' + 'Prioriteit: ' + COALESCE(fv_priority.description, '') ELSE 'Plandatum: ' + COALESCE(SUBSTRING(CONVERT(nvarchar, fv_activity.planstartdt, 13), 1, 11),'') + '
' END + '
---------------------------------------------------
' + COALESCE(fv_activity.name, '') + COALESCE('
' + fv_activity.name_2, '') + '
' + COALESCE(fv_customer.external_id, '') + ' ' + COALESCE(fv_activity.functieplaatsnaam, '') + '
---------------------------------------------------
' + COALESCE(fv_activity.equipmentname + '
', '') + COALESCE(fv_activity.description, '') + '
' + COALESCE(CONVERT(NVARCHAR(4000),fv_activity.notes), '') + '
---------------------------------------------------
' + 'Opdrachtnummer: ' + COALESCE(fv_activity.opdrachtnummer, ''))  As orderbeschrijving
FROM    fv_activity
    LEFT OUTER JOIN fv_priority
        ON fv_activity.priority_id = fv_priority.id
    LEFT OUTER JOIN fv_activitytype at
        on fv_activity.activitytype_id = at.id
    LEFT OUTER JOIN fv_customer
        on fv_customer.id = fv_activity.customer_id
WHERE    fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> ministoringsboek;
fv_activity -> ordersoort_id;
at -> description;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_priority -> description;
fv_activity -> planstartdt;
fv_activity -> name;
fv_activity -> name_2;
fv_customer -> external_id;
fv_activity -> functieplaatsnaam;
fv_activity -> equipmentname;
fv_activity -> description;
fv_activity -> notes;
fv_activity -> opdrachtnummer;
fv_activity -> priority_id;
fv_priority -> id;
fv_activitytype -> at;
fv_activity -> activitytype_id;
at -> id;
fv_customer -> id;
fv_activity -> customer_id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement40Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_capability where isactive = 1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_capability -> isactive;
fv_capability -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement41Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_productgroep where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_productgroep -> isactive;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement42Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT id, description
FROM fv_activitytype
WHERE external_id IN ('10', '20')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activitytype -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement43()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set opdrachtnummer='$form.txtOpdrachtnr$', name_signature = '$sub.grdContact2.name$', email='$sub.grdContact2.email$', signaturedt= SUBSTRING('$form.datSig$',1,11) + SUBSTRING('$form.timeSig$',12,8), paraafstatus_id='$form.cboStatus$' where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> email;
fv_debrief -> signaturedt;
fv_debrief -> paraafstatus_id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement44()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief SET opdrachtnummer = '$form.txtOpdrachtnr$', name_signature = '$sub.grdContact2.name$', email = '$form.txtEmail$' + CASE WHEN LEN('$form.txtEmail$')>0 THEN ';' ELSE '' END + '$sub.grdContact2.email$', signaturedt = SUBSTRING('$form.datSig$',1,11) + SUBSTRING('$form.timeSig$',12,8), send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> email;
fv_debrief -> signaturedt;
fv_debrief -> send_specificatie;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement45Component2402()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_contact.contactsurname, fv_contact.phone, fv_contact.email
FROM         fv_customer_main INNER JOIN
                      fv_activity ON fv_customer_main.id = fv_activity.customer_main_id INNER JOIN
                      fv_contact ON fv_customer_main.id = fv_contact.customer_main_id
where fv_activity.id = '$flow.activity_id$'
order by fv_contact.contactsurname");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_contact -> contactsurname;
fv_contact -> phone;
fv_contact -> email;
fv_customer_main -> id;
fv_activity -> customer_main_id;
fv_customer_main -> id;
fv_contact -> customer_main_id;
fv_activity -> id;
fv_contact -> contactsurname;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr373()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select c.external_id from fv_customer c inner join fv_activity a on a.customer_id = c.id where a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
c -> external_id;
fv_customer -> c;
fv_activity -> a;
a -> customer_id;
c -> id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement46Component2417()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    s.id,
    SUBSTRING(s.external_id, 9, 10) AS short_ext,
    s.description,
    s.external_id
FROM    fv_serviceobject s
    INNER JOIN fv_customer c
        ON c.id = s.customer_id
    INNER JOIN fv_customer cp
        ON cp.id = c.parent_customer_id
WHERE    c.external_id LIKE '$sub.txtFP$' + '%'
    AND s.external_id LIKE '%' + '$sub.txtEqnr$'
    AND s.description LIKE '%$sub.txtDesc$%'
    AND '$flow.zoek$' = '1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
s -> id;
s -> external_id;
s -> description;
s -> external_id;
fv_serviceobject -> s;
fv_customer -> c;
c -> id;
s -> customer_id;
fv_customer -> cp;
cp -> id;
c -> parent_customer_id;
c -> external_id;
s -> external_id;
s -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement47()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set serviceobject_id = $sub.grdEq.id$ where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> serviceobject_id;
sub -> grdEq;
grdEq -> id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr372()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_serviceobject.external_id, fv_serviceobject.description, fv_customer.external_id AS functieplaats, fv_serviceobject.notes,fv_customer.id
FROM fv_serviceobject left outer join fv_customer ON fv_serviceobject.customer_id = fv_customer.id
WHERE fv_serviceobject.external_id = '$sub.txtEquipNr$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_serviceobject -> external_id;
fv_serviceobject -> description;
fv_customer -> external_id;
fv_serviceobject -> notes;
fv_customer -> id;
fv_serviceobject -> customer_id;
fv_customer -> id;
fv_serviceobject -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr494()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr495()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select at.external_id as typewerk,
cm.external_id as kunnr,
a.contact as contactpersoonid,
CASE WHEN COALESCE(a.customer_id,0)=0 THEN a.functieplaatsnaam ELSE fp.external_id END as functieplaatsid,
coalesce(eq.external_id,'') as equipmentid,
coalesce(a.description,'') as omschrijving,
coalesce(a.opdrachtnummer,'') as opdrachtnummer,
pc.external_id as productcombi  from fv_activity a inner join fv_activitytype at on at.id = a.activitytype_id left outer join fv_customer_main cm on a.customer_main_id = cm.id left outer join fv_customer fp on a.customer_id = fp.id  left outer join fv_serviceobject eq on a.serviceobject_id = eq.id  left outer join fv_capability pc on a.capability_id = pc.id where a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
at -> external_id;
cm -> external_id;
a -> contact;
a -> customer_id;
a -> functieplaatsnaam;
fp -> external_id;
eq -> external_id;
a -> description;
a -> opdrachtnummer;
pc -> external_id;
fv_activity -> a;
fv_activitytype -> at;
at -> id;
a -> activitytype_id;
fv_customer_main -> cm;
a -> customer_main_id;
cm -> id;
fv_customer -> fp;
a -> customer_id;
fp -> id;
fv_serviceobject -> eq;
a -> serviceobject_id;
eq -> id;
fv_capability -> pc;
a -> capability_id;
pc -> id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr525()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set sub_id = $form.txtWB$, serviceordernumber='$form.txtSO$' where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> sub_id;
form -> txtWB;
fv_activity -> serviceordernumber;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr693()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus set radiostatus_id = 0 where activity_id = '$flow.activity_id$' and activitystatustype_id = 30 and '$form.txtSO$'=''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activity_id;
fv_activitystatus -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement48()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(isafmeldbonvoorklantverplicht,0) FROM fv_activity WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement49()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(IsUrenSpecificatieVerplicht,0) FROM fv_activity WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement50()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(isafmeldbonvoorklantverplicht,0) FROM fv_activity WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement51()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(isequipmentscannenverplicht,0) FROM fv_activity WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement52()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief
SET email = '$form.txtEmail$', send_email = CASE WHEN '$form.chMail$' = 'true' THEN 1 ELSE 0 END, send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END 
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr416()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(fv_debrief.email,fv_contact.email) as email from fv_activity inner join fv_debrief on fv_activity.id = fv_debrief.activity_id left outer join fv_contact on fv_activity.contact_id = fv_contact.id where fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> email;
fv_contact -> email;
fv_activity -> id;
fv_debrief -> activity_id;
fv_activity -> contact_id;
fv_contact -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr417()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    CASE WHEN send_email = 1 THEN 'true' ELSE 'false' END AS mail,
    CASE WHEN send_specificatie = 1 THEN 'true' ELSE 'false' END AS spec
FROM    fv_debrief
WHERE    activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr524()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select fv_debrief.cc from fv_activity inner join fv_debrief on fv_activity.id = fv_debrief.activity_id where fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> cc;
fv_activity -> id;
fv_debrief -> activity_id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement53Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  l1.emailto
FROM    fv_emaillist l1
WHERE   l1.id IN ( SELECT   MIN(id)
                   FROM     fv_emaillist l2
                   WHERE    l1.activity_id = l2.activity_id
                            AND l1.emailto = l2.emailto )
        AND activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
l1 -> emailto;
fv_emaillist -> l1;
l1 -> id;
fv_emaillist -> l2;
l1 -> activity_id;
l2 -> activity_id;
l1 -> emailto;
l2 -> emailto;
}
fv_emaillist -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement54()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief set send_email = CASE WHEN '$form.chMail$' = 'true' THEN 1 ELSE 0 END, send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END 
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement55()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set email = '$form.txtEmail$' + CASE WHEN LEN('$form.txtEmail$')>0 THEN ';' ELSE '' END + '$sub.grdEmail.mail$' where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement56()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE
    fv_debrief
SET 
    email = '$form.txtEmail$' + CASE WHEN LEN('$form.txtEmail$') > 0 THEN ';'
                                     ELSE ''
                                END + '$sub.grdEmail.mail$',
    name_signature = '$form.txtParaafNaam$',
    opdrachtnummer = '$form.txtOpdrachtnr$',
    signaturedt = SUBSTRING('$form.datSig$', 1, 11) + SUBSTRING('$form.timeSig$', 12, 8)    
WHERE
    activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> name_signature;
fv_debrief -> opdrachtnummer;
fv_debrief -> signaturedt;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement57Component2468()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_contact.contactsurname, fv_contact.email
FROM         fv_customer_main INNER JOIN
                      fv_activity ON fv_customer_main.id = fv_activity.customer_main_id INNER JOIN
                      fv_contact ON fv_customer_main.id = fv_contact.customer_main_id
where fv_activity.id = '$flow.activity_id$'
AND fv_contact.isactive = 1
order by fv_contact.contactsurname");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_contact -> contactsurname;
fv_contact -> email;
fv_customer_main -> id;
fv_activity -> customer_main_id;
fv_customer_main -> id;
fv_contact -> customer_main_id;
fv_activity -> id;
fv_contact -> isactive;
fv_contact -> contactsurname;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement58()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CONVERT(NVARCHAR, COALESCE(MIN(ds.statusdt),
                                   DATEADD(year, 1, GETDATE())), 126) AS debrief_statusdt
FROM    fv_debrief_status ds
        INNER JOIN fv_activity a ON a.external_id = ds.external_id
                                    AND a.sub_id = ds.sub_id
                                    AND a.activitystatustype_id NOT IN ( 120, 125, 60, 62 )
WHERE   ds.activitystatustype_id = 59
        AND NOT EXISTS ( SELECT 0
                         FROM   fv_activitystatus acts
                         WHERE  acts.activity_id = a.id
                                AND acts.activitystatustype_id IN ( 120, 125, 60, 62 ) )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ds -> statusdt;
fv_debrief_status -> ds;
fv_activity -> a;
a -> external_id;
ds -> external_id;
a -> sub_id;
ds -> sub_id;
a -> activitystatustype_id;
ds -> activitystatustype_id;
fv_activitystatus -> acts;
acts -> activity_id;
a -> id;
acts -> activitystatustype_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr448()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set radiostatus_id = 0 where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> radiostatus_id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr449()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE    fv_labour
SET    radiostatus_id = 0
WHERE    activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour -> radiostatus_id;
fv_labour -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr450()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debriefoperations set radiostatus_id = 0 where activity_id = '$flow.activity_id$' and done = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debriefoperations -> radiostatus_id;
fv_debriefoperations -> activity_id;
fv_debriefoperations -> done;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr451()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id)
SELECT NEWID(), '$flow.activity_id$', $app.userid$, GETDATE(), $flow.afrondst$, -5
FROM fv_engineer
WHERE id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
flow -> afrondst;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr452()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE    fv_activity
SET    maxstatusdt = GETDATE()
    ,activitystatustype_id = $flow.afrondst$
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> maxstatusdt;
fv_activity -> activitystatustype_id;
flow -> afrondst;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr453()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour_detail set radiostatus_id=0 where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr460()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set radiostatus_id=0 where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_materialmutation -> radiostatus_id;
fv_materialmutation -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr656()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_labour
SET    enddt = getdate(),
    roenddt = COALESCE(roenddt, getdate())
WHERE    activity_id = '$flow.activity_id$'
    AND enddt IS NULL
    AND labourstatus_id = 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour -> enddt;
fv_labour -> roenddt;
fv_labour -> roenddt;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr666()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(fv_activity.serviceordernumber,'') as sonr
FROM fv_activity 
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr722()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM   fv_debrief_status
WHERE         EXISTS (SELECT * FROM fv_activity a WHERE a.external_id = fv_debrief_status.external_id
                                    AND a.sub_id = fv_debrief_status.sub_id
                                    AND a.id = '$flow.activity_id$')
AND activitystatustype_id = 59 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_activity -> a;
a -> external_id;
fv_debrief_status -> external_id;
a -> sub_id;
fv_debrief_status -> sub_id;
a -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr735()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief_photo set radiostatus_id = 0 where activity_id = '$flow.activity_id$' and radiostatus_id != -2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief_photo -> radiostatus_id;
fv_debrief_photo -> activity_id;
fv_debrief_photo -> radiostatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr620()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(bestel_autorisatie,0) as bestel_autorisatie, COALESCE(ontvangst_autorisatie,0) as ontvangst_autorisatie from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr629()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE WHEN COUNT(QUANTITY)=0 THEN '0' else '1' END as materiaalingevoerd from fv_materialmutation where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialmutation -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr672()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(fv_activity.serviceordernumber,'') as sonr
FROM fv_activity 
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement59Component2471()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     coalesce(bestelnr,'') + '/' + coalesce(description,'') + '/' + coalesce(supplier_name,'') as omsch, quantity, type, id,'' as empty
FROM         fv_materialmutation
WHERE     ((type = 'D') OR(type = 'O')) and activity_id = '$flow.activity_id$'
UNION
SELECT     coalesce(fv_material.bestelnr,'') + '/' + coalesce(fv_materialmutation.description,'') + '/' + coalesce(fv_supplier.description,'') AS omsch, fv_materialmutation.quantity, type, fv_materialmutation.id,'' as empty
FROM         fv_materialmutation INNER JOIN
                      fv_material ON fv_materialmutation.material_id = fv_material.id LEFT OUTER JOIN
                      fv_supplier ON fv_material.supplier_id = fv_supplier.id
WHERE     (fv_materialmutation.type = 'A') and  activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialmutation -> type;
fv_materialmutation -> type;
fv_materialmutation -> activity_id;
fv_material -> bestelnr;
fv_materialmutation -> description;
fv_supplier -> description;
fv_materialmutation -> quantity;
fv_materialmutation -> id;
fv_materialmutation -> material_id;
fv_material -> id;
fv_material -> supplier_id;
fv_supplier -> id;
fv_materialmutation -> type;
fv_materialmutation -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement60()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement61()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement62()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DROP TABLE fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement63()
        {
            var statement = MacroScope.Factory.CreateStatement(@"CREATE TABLE fv_tmp_bestelling(balie int NULL , huisnummer nvarchar(50) NULL , id uniqueidentifier ROWGUIDCOL CONSTRAINT PK_fv_tmp_bestelling PRIMARY KEY , land nvarchar(50) NULL , leveranciernummer nvarchar(50) NULL , naam nvarchar(50) NULL , naam2 nvarchar(50) NULL , onderaanneming int NULL , plaats nvarchar(50) NULL , postcode nvarchar(50) NULL , sonummer nvarchar(50) NULL , straat nvarchar(50) NULL , werkbon int NULL )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement64()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_bestellingregel");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement65()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestelling (id,sonummer,werkbon,straat,naam,naam2,huisnummer,postcode,plaats,land) select '$flow.bestel_id$',serviceordernumber,sub_id,street,name,name_2,housenumber,zip,city,'NL' from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bestelling -> id;
fv_tmp_bestelling -> sonummer;
fv_tmp_bestelling -> werkbon;
fv_tmp_bestelling -> straat;
fv_tmp_bestelling -> naam;
fv_tmp_bestelling -> naam2;
fv_tmp_bestelling -> huisnummer;
fv_tmp_bestelling -> postcode;
fv_tmp_bestelling -> plaats;
fv_tmp_bestelling -> land;
}
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement66()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement67()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement68()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set quantity=$form.txtAantal$,description='$form.txtOms$' where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_materialmutation -> quantity;
form -> txtAantal;
fv_materialmutation -> description;
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr382()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     COALESCE(mm.bestelnr,fv_material.bestelnr) as bestelnr, mm.description, COALESCE(fv_supplier.description,mm.supplier_name) AS supomsch, COALESCE(mm.price,fv_material.price) as price, mm.quantity, mm.purchaseorderpositie
FROM            fv_materialmutation mm left outer join 
fv_material on mm.material_id = fv_material.id LEFT OUTER JOIN
                      fv_supplier ON fv_material.supplier_id = fv_supplier.id
WHERE  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
mm -> bestelnr;
fv_material -> bestelnr;
mm -> description;
fv_supplier -> description;
mm -> supplier_name;
mm -> price;
fv_material -> price;
mm -> quantity;
mm -> purchaseorderpositie;
fv_materialmutation -> mm;
mm -> material_id;
fv_material -> id;
fv_material -> supplier_id;
fv_supplier -> id;
mm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement69()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr379()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_supplier where gabicode = '29'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> gabicode;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement70Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_supplier where isactive =1 and not gabicode is null
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> isactive;
fv_supplier -> gabicode;
fv_supplier -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement71Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_material.id,fv_material.bestelnr + '/'  + fv_supplier.description AS omsch, fv_material.hitrate, fv_material.description, fv_material.external_id FROM fv_material inner JOIN fv_supplier ON fv_material.supplier_id = fv_supplier.id where 0 = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_material -> id;
fv_material -> bestelnr;
fv_supplier -> description;
fv_material -> hitrate;
fv_material -> description;
fv_material -> external_id;
fv_material -> supplier_id;
fv_supplier -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr380()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_material.bestelnr, fv_material.description, fv_supplier.description AS supomsch, fv_material.price, 1 as def
FROM            fv_material LEFT OUTER JOIN
                      fv_supplier ON fv_material.supplier_id = fv_supplier.id
WHERE  fv_material.id = $sub.grdZoekArt.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_material -> bestelnr;
fv_material -> description;
fv_supplier -> description;
fv_material -> price;
fv_material -> supplier_id;
fv_supplier -> id;
fv_material -> id;
sub -> grdZoekArt;
grdZoekArt -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement72()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,material_id,radiostatus_id,description,type) select newid(),'$flow.activity_id$',getdate(),$sub.txtAantal$,id,-1,'$sub.txtOms$','A' from fv_material where id =  $sub.grdZoekArt.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_materialmutation -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> mutationdt;
fv_materialmutation -> quantity;
fv_materialmutation -> material_id;
fv_materialmutation -> radiostatus_id;
fv_materialmutation -> description;
fv_materialmutation -> type;
}
subgraph select {
sub -> txtAantal;
fv_material -> id;
sub -> grdZoekArt;
grdZoekArt -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr383()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,material_id,radiostatus_id,description,type) select '$flow.mat_id$','$flow.activity_id$',getdate(),1,m.id,-1,fv_materialgroup.description,fv_materialgroup.category from fv_materialgroup left outer join fv_material m on fv_materialgroup.material_external_id = m.external_id where fv_materialgroup.id = $form.id$ and '$flow.screen$'<>''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_materialmutation -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> mutationdt;
fv_materialmutation -> quantity;
fv_materialmutation -> material_id;
fv_materialmutation -> radiostatus_id;
fv_materialmutation -> description;
fv_materialmutation -> type;
}
subgraph select {
m -> id;
fv_materialgroup -> description;
fv_materialgroup -> category;
fv_material -> m;
fv_materialgroup -> material_external_id;
m -> external_id;
fv_materialgroup -> id;
form -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement73Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialgroup where category='H' and isactive =1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialgroup -> category;
fv_materialgroup -> isactive;
fv_materialgroup -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement74Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialgroup where category='S' and isactive =1 and parent_id = $form.cbHead$ order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialgroup -> category;
fv_materialgroup -> isactive;
fv_materialgroup -> parent_id;
form -> cbHead;
fv_materialgroup -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement75Component2516()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_material.description as oms, fv_materialgroup.category, fv_materialgroup.id
FROM         fv_material RIGHT OUTER JOIN
                      fv_materialgroup ON fv_material.external_id = fv_materialgroup.material_external_id
WHERE fv_materialgroup.parent_id = $form.cbSub$ order by fv_materialgroup.external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_material -> description;
fv_materialgroup -> category;
fv_materialgroup -> id;
fv_material -> external_id;
fv_materialgroup -> material_external_id;
fv_materialgroup -> parent_id;
form -> cbSub;
fv_materialgroup -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement76()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,radiostatus_id,description,type,price) select newid(),'$flow.activity_id$',getdate(),1,-1,'$sub.grdKlein.oms$','D',convert(real,replace('$sub.grdKlein.id$',',','.')) from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_materialmutation -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> mutationdt;
fv_materialmutation -> quantity;
fv_materialmutation -> radiostatus_id;
fv_materialmutation -> description;
fv_materialmutation -> type;
fv_materialmutation -> price;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement77Component2528()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 2.5 as id, 'klein materiaal 2.5' as oms from fv_engineer where id = $app.userid$ 
UNION
select 5.0 as id, 'klein materiaal 5.0' as oms from fv_engineer where id = $app.userid$ 
UNION
select 10.0 as id, 'klein materiaal 10.0' as oms from fv_engineer where id = $app.userid$ 
UNION
select 15.0 as id, 'klein materiaal 15.0' as oms from fv_engineer where id = $app.userid$ 
UNION
select 20.0 as id, 'klein materiaal 20.0' as oms from fv_engineer where id = $app.userid$ 
UNION
select 25.0 as id, 'klein materiaal 25.0' as oms from fv_engineer where id = $app.userid$ 
UNION
select 30.0 as id, 'klein materiaal 30.0' as oms from fv_engineer where id = $app.userid$
UNION
select 40.0 as id, 'klein materiaal 40.0' as oms from fv_engineer where id = $app.userid$ 
UNION
select 50.0 as id, 'klein materiaal 50.0' as oms from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr496()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 1 as def from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement78()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,material_id,radiostatus_id,description,type) select newid(),'$flow.activity_id$',getdate(),$sub.txtAantal1$,MIN(id),-1,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel1$') group by bestelnr UNION select newid(),'$flow.activity_id$',getdate(),$sub.txtAantal2$,MIN(id),-1,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel2$') group by bestelnr UNION select newid(),'$flow.activity_id$',getdate(),$sub.txtAantal3$,MIN(id),-1,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel3$') group by bestelnr UNION select newid(),'$flow.activity_id$',getdate(),$sub.txtAantal4$,MIN(id),-1,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel4$') group by bestelnr UNION select newid(),'$flow.activity_id$',getdate(),$sub.txtAantal5$,MIN(id),-1,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel5$') group by bestelnr ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_materialmutation -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> mutationdt;
fv_materialmutation -> quantity;
fv_materialmutation -> material_id;
fv_materialmutation -> radiostatus_id;
fv_materialmutation -> description;
fv_materialmutation -> type;
}
subgraph select {
sub -> txtAantal1;
fv_material -> bestelnr;
fv_material -> bestelnr;
subgraph select {
sub -> txtAantal2;
fv_material -> bestelnr;
fv_material -> bestelnr;
subgraph select {
sub -> txtAantal3;
fv_material -> bestelnr;
fv_material -> bestelnr;
subgraph select {
sub -> txtAantal4;
fv_material -> bestelnr;
fv_material -> bestelnr;
subgraph select {
sub -> txtAantal5;
fv_material -> bestelnr;
fv_material -> bestelnr;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr386()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '-' as def from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement79()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set supplier_name = '$sub.grdZoekLev.name$' where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_materialmutation -> supplier_name;
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement80Component2572()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description from fv_supplier where isactive = 1 and description like '%'+'$sub.txtZoek$' + '%' and $flow.zoek$=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> isactive;
fv_supplier -> description;
flow -> zoek;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement81()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set supplier_name='$form.txtSup$', bestelnr='$form.txtBestel$', quantity=$form.txtAantal$,description='$form.txtOms$',price=convert(real,replace('$form.txtPrice$',',','.')),n_price=convert(real,replace('$form.txtPrice$',',','.')) where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_materialmutation -> supplier_name;
fv_materialmutation -> bestelnr;
fv_materialmutation -> quantity;
form -> txtAantal;
fv_materialmutation -> description;
fv_materialmutation -> price;
fv_materialmutation -> n_price;
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr388()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     mm.supplier_name,mm.bestelnr, mm.description, mm.quantity, mm.price, mm.n_price, mm.purchaseorderpositie
FROM            fv_materialmutation mm
WHERE  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
mm -> supplier_name;
mm -> bestelnr;
mm -> description;
mm -> quantity;
mm -> price;
mm -> n_price;
mm -> purchaseorderpositie;
fv_materialmutation -> mm;
mm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr389()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     mm.supplier_name,mm.bestelnr, mm.description, mm.quantity, mm.price, mm.n_price
FROM            fv_materialmutation mm
WHERE  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
mm -> supplier_name;
mm -> bestelnr;
mm -> description;
mm -> quantity;
mm -> price;
mm -> n_price;
fv_materialmutation -> mm;
mm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestListQuerylstCheck1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"(select 1, 'U moet de geschatte prijs nog invullen.', 2 as sortorder from fv_debrief where activity_id = '$flow.activity_id$' and '$form.txtPrice$'='') UNION (select 1, 'klaar', 9 as sortorder from fv_engineer where id = '$app.UserID$') order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
fv_engineer -> id;
fv_engineer -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement82()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement83()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where price is null and id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_materialmutation -> price;
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement84()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set supplier_name='$form.txtSup$', bestelnr='$form.txtBestel$', quantity=$form.txtAantal$,description='$form.txtOms$',price=convert(real,replace('$form.txtPrice$',',','.')) where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_materialmutation -> supplier_name;
fv_materialmutation -> bestelnr;
fv_materialmutation -> quantity;
form -> txtAantal;
fv_materialmutation -> description;
fv_materialmutation -> price;
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr384()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     mm.supplier_name,mm.bestelnr, mm.description, mm.quantity, mm.price, mm.purchaseorderpositie
FROM            fv_materialmutation mm
WHERE  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
mm -> supplier_name;
mm -> bestelnr;
mm -> description;
mm -> quantity;
mm -> price;
mm -> purchaseorderpositie;
fv_materialmutation -> mm;
mm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr385()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     mm.supplier_name,mm.bestelnr, mm.description, mm.quantity, mm.price
FROM            fv_materialmutation mm
WHERE  mm.id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
mm -> supplier_name;
mm -> bestelnr;
mm -> description;
mm -> quantity;
mm -> price;
fv_materialmutation -> mm;
mm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement85()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement86()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where price is null and id = '$flow.mat_id$' and purchaseorderpositie is null and external_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_materialmutation -> price;
fv_materialmutation -> id;
fv_materialmutation -> purchaseorderpositie;
fv_materialmutation -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr390()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select overigekosten, overigekosten_bedrag from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement87()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set overigekosten = '$form.txtKosten_oms$', overigekosten_bedrag = CASE WHEN '$form.txtKosten$'='' THEN null ELSE convert(real,replace('$form.txtKosten$',',','.')) END where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> overigekosten;
fv_debrief -> overigekosten_bedrag;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr447()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT 'Strukton Worksphere heeft in uw opdracht werkzaamheden verricht welke zijn beschreven op de PDA. Met het plaatsen van een paraaf op de PDA van de medewerker van Strukton Worksphere geeft u aan dat u akkoord gaat met de door de medewerker uitgevoerde werkzaamheden.' AS txt FROM fv_engineer WHERE id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement88Component4207()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  fv_tmp_werkbonmateriaal.id,
        fv_tmp_werkbonmateriaal.external_id,
        WerkbonId,
        Fabrikant,
        Leverancier,
        Aantal,
        Artikelnummer,
        COALESCE(Artikelnummer, '') + '/' + COALESCE(omschrijving, '') + '/'
        + COALESCE(leverancier, '') AS Omschrijving,
        '' AS empty,
        0 AS is_mutated
FROM    fv_tmp_werkbonmateriaal
        INNER JOIN fv_activity ON fv_activity.sub_id = fv_tmp_werkbonmateriaal.WerkbonId
WHERE NOT EXISTS (SELECT * FROM fv_materialmutation WHERE fv_activity.id = fv_materialmutation.activity_id
AND fv_materialmutation.wbm_id = fv_tmp_werkbonmateriaal.external_id)
AND fv_activity.id = '$flow.activity_id$'
UNION
SELECT  fv_tmp_werkbonmateriaal.id,
        fv_tmp_werkbonmateriaal.external_id,
        WerkbonId,
        Fabrikant,
        Leverancier,
        Aantal,
        Artikelnummer,
        COALESCE(Artikelnummer, '') + '/' + COALESCE(omschrijving, '') + '/'
        + COALESCE(leverancier, '') AS Omschrijving,
        '' AS empty,
        1
FROM    fv_tmp_werkbonmateriaal
        INNER JOIN fv_activity ON fv_activity.sub_id = fv_tmp_werkbonmateriaal.WerkbonId
WHERE EXISTS (SELECT * FROM fv_materialmutation WHERE fv_activity.id = fv_materialmutation.activity_id
AND fv_materialmutation.wbm_id = fv_tmp_werkbonmateriaal.external_id)
AND fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_werkbonmateriaal -> id;
fv_tmp_werkbonmateriaal -> external_id;
fv_activity -> sub_id;
fv_tmp_werkbonmateriaal -> WerkbonId;
fv_activity -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> wbm_id;
fv_tmp_werkbonmateriaal -> external_id;
}
fv_activity -> id;
fv_tmp_werkbonmateriaal -> id;
fv_tmp_werkbonmateriaal -> external_id;
fv_activity -> sub_id;
fv_tmp_werkbonmateriaal -> WerkbonId;
fv_activity -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> wbm_id;
fv_tmp_werkbonmateriaal -> external_id;
}
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement89Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     coalesce(bestelnr,'') + '/' + coalesce(description,'') + '/' + coalesce(supplier_name,'') as omsch, quantity, type, id,'' as empty
FROM         fv_materialmutation
WHERE     TYPE IN ('D','O','A') and activity_id = '$flow.activity_id$'
AND material_id IS NULL
UNION
SELECT     coalesce(fv_material.bestelnr,'') + '/' + coalesce(fv_materialmutation.description,'') + '/' + coalesce(fv_supplier.description,'') AS omsch, fv_materialmutation.quantity, type, fv_materialmutation.id,'' as empty
FROM         fv_materialmutation INNER JOIN
                      fv_material ON fv_materialmutation.material_id = fv_material.id LEFT OUTER JOIN
                      fv_supplier ON fv_material.supplier_id = fv_supplier.id
WHERE     (fv_materialmutation.type = 'A') and  activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialmutation -> TYPE;
fv_materialmutation -> activity_id;
fv_materialmutation -> material_id;
fv_material -> bestelnr;
fv_materialmutation -> description;
fv_supplier -> description;
fv_materialmutation -> quantity;
fv_materialmutation -> id;
fv_materialmutation -> material_id;
fv_material -> id;
fv_material -> supplier_id;
fv_supplier -> id;
fv_materialmutation -> type;
fv_materialmutation -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr351()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     COALESCE(convert(nvarchar,fv_activity.sub_id),'') as werkbon,  COALESCE(fv_activity.serviceordernumber,'') as serviceordernumber, opdrachtnummer FROM fv_activity
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> sub_id;
fv_activity -> serviceordernumber;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement90()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set opdrachtnummer = '$sub.txtOpdrachtnr$' where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> opdrachtnummer;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement91()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set opdrachtnummer = '$sub.txtOpdrachtnr$' where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> opdrachtnummer;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr361()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    fv_customer.external_id,
    fv_activity.equipmentname,
    fv_customer.id,
    'focus.intra/onderhoudshistorie?p=' + COALESCE(fv_engineer.external_id, '') + '&eq=' + COALESCE(fv_serviceobject.external_id, '') + '&fp=' + REPLACE('/', '_', COALESCE(fv_customer.external_id, '')) AS webadres
FROM    fv_activity
    INNER JOIN fv_engineer
        ON fv_activity.engineer_id = fv_engineer.id
            AND fv_activity.id = '$flow.activity_id$'
    LEFT OUTER JOIN fv_customer
        ON fv_activity.customer_id = fv_customer.id
    LEFT OUTER JOIN fv_serviceobject
        ON fv_activity.serviceobject_id = fv_serviceobject.id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer -> external_id;
fv_activity -> equipmentname;
fv_customer -> id;
fv_engineer -> external_id;
fv_serviceobject -> external_id;
fv_customer -> external_id;
fv_activity -> engineer_id;
fv_engineer -> id;
fv_activity -> id;
fv_activity -> customer_id;
fv_customer -> id;
fv_activity -> serviceobject_id;
fv_serviceobject -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement92Component2639()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_history.id, historydt, fv_history.description
FROM         fv_history inner join fv_activity on fv_activity.id = fv_history.activity_id
where fv_activity.id = '$flow.activity_id$' and fv_history.serviceobject_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_history -> id;
fv_history -> description;
fv_activity -> id;
fv_history -> activity_id;
fv_activity -> id;
fv_history -> serviceobject_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement93Component3773()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_history.id, historydt, fv_history.description
FROM         fv_history inner join fv_activity on fv_activity.id = fv_history.activity_id
where fv_activity.id = '$flow.activity_id$' and not fv_history.serviceobject_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_history -> id;
fv_history -> description;
fv_activity -> id;
fv_history -> activity_id;
fv_activity -> id;
fv_history -> serviceobject_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr371()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select extra_notes from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement94()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$sub.txtNotes$',extra_notes = '$sub.txtExtra$' where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> notes;
fv_debrief -> extra_notes;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr413()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT       'Ordernr: ' + COALESCE(fv_activity.serviceordernumber,'') + '
' + 'Werkbon: ' + COALESCE(convert(nvarchar,fv_activity.sub_id),'') + '
' + 'Datum: ' + CONVERT(nvarchar,getdate(),105) + '

' + 'Omschrijving: 
' + COALESCE (fv_activity.description, '') AS samenvatting
FROM         fv_activity
where fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> sub_id;
fv_activity -> description;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr657()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT      fv_debrief.notes
FROM         fv_debrief 
where fv_debrief.activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> notes;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr725()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  ds.rostatusdt AS enddt
FROM fv_activity a
LEFT OUTER JOIN  fv_debrief_status ds ON ds.external_id = a.external_id AND ds.sub_id = a.sub_id
AND ds.activitystatustype_id in (59,150)
WHERE a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ds -> rostatusdt;
fv_activity -> a;
fv_debrief_status -> ds;
ds -> external_id;
a -> external_id;
ds -> sub_id;
a -> sub_id;
ds -> activitystatustype_id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement95()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Update fv_labour set medewerker_id = $sub.grdZoekMDW.id$ where id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour -> medewerker_id;
sub -> grdZoekMDW;
grdZoekMDW -> id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement96()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_debrief
SET    vervolg_medewerker_id = $sub.grdZoekMDW.id$,
    vervolgactie_id = CASE WHEN '$form.cbVervolg$'='' OR '$form.cbVervolg$'='null' THEN null ELSE '$form.cbVervolg$' END,
    vervolgnotes = '$form.txtVervolgNotes$',
    restduur = DatePart(hh, '$form.tmRest$') + CONVERT(REAL, DATEPART(mi, '$form.tmRest$')) / 60
WHERE    activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> vervolg_medewerker_id;
sub -> grdZoekMDW;
grdZoekMDW -> id;
fv_debrief -> vervolgactie_id;
fv_debrief -> vervolgnotes;
fv_debrief -> restduur;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement97Component2666()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    id,
    external_id,
    description
FROM    fv_medewerker
WHERE    isactive = 1
    AND description LIKE '$sub.txtZoek$' + '%'
    AND '$flow.zoek$' = '1'
ORDER BY description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_medewerker -> isactive;
fv_medewerker -> description;
fv_medewerker -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr387()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '-' as def from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement98()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_materialmutation set supplier_name = '$sub.grdZoekLev2.name$' where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_materialmutation -> supplier_name;
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement99Component2675()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description from fv_supplier where isactive = 1 and description like '%'+'$sub.txtZoek$' + '%' and $flow.zoek$=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> isactive;
fv_supplier -> description;
flow -> zoek;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr427()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     cm.external_id, cm.name, cm.name2, COALESCE(cm.street,'') + '
' + COALESCE(cm.zip,'') + ' ' +  COALESCE(cm.city,'') + '
' +  CASE WHEN cm.fax is null THEN '' ELSE 'Fax: ' END + COALESCE(cm.fax,'') as overig, 
                      c.contactsurname + ' ' + c.phone as contact
FROM         fv_customer_main cm left outer join fv_contact c on c.customer_main_id = cm.id
WHERE cm.external_id = '$sub.txtKlantnr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
cm -> external_id;
cm -> name;
cm -> name2;
cm -> street;
cm -> zip;
cm -> city;
cm -> fax;
cm -> fax;
c -> contactsurname;
c -> phone;
fv_customer_main -> cm;
fv_contact -> c;
c -> customer_main_id;
cm -> id;
cm -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement100()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitytype_id= $form.lcbType$ where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitytype_id;
form -> lcbType;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement101()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set capability_id= CASE WHEN '$form.cbArtikelGroep$'='' THEN null ELSE '$form.cbArtikelGroep$' END, productgroep_id= CASE WHEN '$form.cbProductgroep$'='' THEN null ELSE '$form.cbProductgroep$' END, functieplaatsnaam=CASE WHEN COALESCE(customer_id,0)=0 THEN '$form.txtFPNB$' ELSE functieplaatsnaam END where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> capability_id;
fv_activity -> productgroep_id;
fv_activity -> functieplaatsnaam;
fv_activity -> customer_id;
fv_activity -> functieplaatsnaam;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement102()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set contact = '$sub.grdContact.extid$', contactpersoon = '$sub.grdContact.name$', contactpersoon_phone = '$sub.grdContact.phone$', description = '$form.txtDescNW$', opdrachtnummer = '$form.txtOpdrnr$' where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> contact;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement103Component2685()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_contact.contactsurname, fv_contact.phone,fv_contact.id, fv_contact.external_id
FROM         fv_customer_main INNER JOIN
                      fv_activity ON fv_customer_main.id = fv_activity.customer_main_id INNER JOIN
                      fv_contact ON fv_customer_main.id = fv_contact.customer_main_id
where fv_activity.id = '$flow.activity_id$'
order by fv_contact.contactsurname");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_contact -> contactsurname;
fv_contact -> phone;
fv_contact -> id;
fv_contact -> external_id;
fv_customer_main -> id;
fv_activity -> customer_main_id;
fv_customer_main -> id;
fv_contact -> customer_main_id;
fv_activity -> id;
fv_contact -> contactsurname;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr430()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select c.external_id from fv_customer c inner join fv_activity a on a.customer_id = c.id where a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
c -> external_id;
fv_customer -> c;
fv_activity -> a;
a -> customer_id;
c -> id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement104Component2691()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    s.id,
    SUBSTRING(s.external_id, 9, 10) AS short_ext,
    s.description,
    s.external_id
FROM    fv_serviceobject s
    INNER JOIN fv_customer c
        ON c.id = s.customer_id
    INNER JOIN fv_activity a
        ON a.customer_main_id = c.customer_main_id
WHERE    a.id = '$flow.activity_id$'
    AND c.external_id LIKE '$sub.txtFP$' + '%'
    AND s.external_id LIKE '%' + '$sub.txtEqnr$'
    AND s.description LIKE '%$sub.txtDescEZ$%'
    AND '$flow.zoek$' = '1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
s -> id;
s -> external_id;
s -> external_id;
s -> description;
s -> external_id;
fv_serviceobject -> s;
fv_customer -> c;
c -> id;
s -> customer_id;
fv_activity -> a;
a -> customer_main_id;
c -> customer_main_id;
a -> id;
c -> external_id;
s -> external_id;
s -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement105()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitytype_id= $form.lcbType$ where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitytype_id;
form -> lcbType;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement106()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set capability_id= CASE WHEN '$form.cbArtikelGroep$'='' THEN null ELSE '$form.cbArtikelGroep$' END, productgroep_id= CASE WHEN '$form.cbProductgroep$'='' THEN null ELSE '$form.cbProductgroep$' END, functieplaatsnaam=CASE WHEN COALESCE(customer_id,0)=0 THEN '$form.txtFPNB$' ELSE functieplaatsnaam END where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> capability_id;
fv_activity -> productgroep_id;
fv_activity -> functieplaatsnaam;
fv_activity -> customer_id;
fv_activity -> functieplaatsnaam;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement107()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set serviceobject_id = $sub.grdEq2.id$, equipmentname = '$sub.grdEq2.name$', description = '$form.txtDescEZ$', opdrachtnummer = '$form.txtOpdrnr$' where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> serviceobject_id;
sub -> grdEq2;
grdEq2 -> id;
fv_activity -> equipmentname;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement108Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"            SELECT 
                convert(nvarchar,datepart(dd,sta.statusdt)) + '-'+ convert(nvarchar,datepart(MM,sta.statusdt)) + ' ' + CASE len(convert(nvarchar,datepart(hh,sta.statusdt))) WHEN 1 THEN '0' ELSE '' END + convert(nvarchar,datepart(hh,sta.statusdt)) + ':'+ + CASE len(convert(nvarchar,datepart(mi,sta.statusdt))) WHEN 1 THEN '0' ELSE '' END + convert(nvarchar,datepart(mi,sta.statusdt)) as plnstrtdt,
                a.serviceordernumber + ' ' + convert(nvarchar,a.sub_id) as sonr,                COALESCE(a.functieplaatsnaam,'') + ' ' + substring(a.description,1,50) as betreft
                from fv_activity a inner join fv_activitystatus sta on sta.activity_id = a.id and ((sta.activitystatustype_id = 30) OR (sta.activitystatustype_id = 170))
where (a.engineer_id=$App.UserId$)  and ((a.activitystatustype_id<60) or (a.activitystatustype_id=140) or (a.activitystatustype_id=160) or (a.activitystatustype_id=170))
and a.planstartdt<='$App.SelectedDateEnd$'                order by sta.statusdt desc



");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
sta -> statusdt;
sta -> statusdt;
sta -> statusdt;
sta -> statusdt;
sta -> statusdt;
sta -> statusdt;
a -> serviceordernumber;
a -> sub_id;
a -> functieplaatsnaam;
a -> description;
fv_activity -> a;
fv_activitystatus -> sta;
sta -> activity_id;
a -> id;
sta -> activitystatustype_id;
sta -> activitystatustype_id;
a -> engineer_id;
App -> UserId;
a -> activitystatustype_id;
a -> activitystatustype_id;
a -> activitystatustype_id;
a -> activitystatustype_id;
a -> planstartdt;
sta -> statusdt;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr491()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement109Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select convert(nvarchar,datepart(dd,a.planstartdt)) + '-'+ convert(nvarchar,datepart(MM,a.planstartdt)) + ' ' + CASE len(convert(nvarchar,datepart(hh,a.planstartdt))) WHEN 1 THEN '0' ELSE '' END + convert(nvarchar,datepart(hh,a.planstartdt)) + ':'+ + CASE len(convert(nvarchar,datepart(mi,a.planstartdt))) WHEN 1 THEN '0' ELSE '' END + convert(nvarchar,datepart(mi,a.planstartdt)) as plnstrtdt, a.id, a.serviceorder_id,COALESCE(a.functieplaatsnaam,'') + ' ' + substring(a.description,1,50) as betreft, a.ordersoort_id from fv_activity a where a.external_id is null and a.activitystatustype_id = 30 and a.engineer_id = $app.userid$ and a.serviceordernumber is null and a.sub_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
a -> planstartdt;
a -> planstartdt;
a -> planstartdt;
a -> planstartdt;
a -> planstartdt;
a -> planstartdt;
a -> id;
a -> serviceorder_id;
a -> functieplaatsnaam;
a -> description;
a -> ordersoort_id;
fv_activity -> a;
a -> external_id;
a -> activitystatustype_id;
a -> engineer_id;
app -> userid;
a -> serviceordernumber;
a -> sub_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement110()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Update fv_activity set activitystatustype_id = 120 where id = '$sub.grdOpen.id$' and $sub.grdOpen.ordersoort_id$>=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitystatustype_id;
fv_activity -> id;
sub -> grdOpen;
grdOpen -> ordersoort_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement111()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus (id,engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)  SELECT newid(),$App.UserID$, getdate(), 0, 120, '$sub.grdOpen.id$' FROM fv_engineer  WHERE  id = $App.UserID$ and $sub.grdOpen.ordersoort_id$>=0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
App -> UserID;
fv_engineer -> id;
App -> UserID;
sub -> grdOpen;
grdOpen -> ordersoort_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement112()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT   CASE activitytype_id WHEN 4 THEN 1 WHEN 15 THEN 1 ELSE 0 END AS isonderhoud
  FROM    fv_activity
  WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement113()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT   COALESCE(isequipmentscannenverplicht, 0)   AS isequipmentscannenverplicht
  FROM    fv_activity
  WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement114()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) from fv_serviceobject s inner join fv_activity a on a.serviceobject_id = s.id where a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_serviceobject -> s;
fv_activity -> a;
a -> serviceobject_id;
s -> id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement115()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief SET IsEquipmentNietVanToepassing = 0 WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> IsEquipmentNietVanToepassing;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr500()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT scannr from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr501()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select problemcode_id, causecode_id, solutioncode_id from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr502()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select s.external_id, s.description,s.id from fv_serviceobject s inner join fv_activity a on a.serviceobject_id = s.id where a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
s -> external_id;
s -> description;
s -> id;
fv_serviceobject -> s;
fv_activity -> a;
a -> serviceobject_id;
s -> id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr541()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set serviceobject_id = CASE WHEN '$form.txtEquipmentID$' = '' THEN null else '$form.txtEquipmentID$' END where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> serviceobject_id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr542()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set solutioncode_id= CASE WHEN '$form.cbSol$' = '' THEN null ELSE $form.cbSol$+0 END where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> solutioncode_id;
form -> cbSol;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr543()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set scandt=getdate(),scannr='$form.txtEquipment$' where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> scandt;
fv_debrief -> scannr;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestListQuerylstCheck22()
        {
            var statement = MacroScope.Factory.CreateStatement(@"(select 1,'U heeft geen equipment gescand.',1 as sortorder from fv_activity a where a.id = '$flow.activity_id$' and '$form.txtEquipment$'='') UNION (select 1,'Onjuist equipment gescand. Deze order is van toepassing op een ander equipment! Scan het juiste equipment.',2 as sortorder from fv_activity a where a.id = '$flow.activity_id$' and convert(numeric(15,0),CASE WHEN '$form.txtEquipment$'='' THEN '0' ELSE '$form.txtEquipment$' END) <> convert(numeric(15,0),CASE WHEN '$form.txtEquipment$'='' THEN '0' ELSE '$form.txtEquipment$' END)) UNION (select 1, 'klaar', 9 as sortorder from fv_engineer where id = '$app.UserID$') order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> a;
a -> id;
fv_activity -> a;
a -> id;
fv_engineer -> id;
fv_engineer -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement116Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_solutioncode where isactive = 1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_solutioncode -> isactive;
fv_solutioncode -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement117()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief SET IsEquipmentNietVanToepassing = 1 WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> IsEquipmentNietVanToepassing;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr511()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     verholpen, COALESCE(verholpendt,getdate()) as verholpendt, vervolgactie, vervolgactie_id, vervolgnotes, startdt
FROM         fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr512()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set verholpen=$form.lcverholpen$, verholpendt='$flow.verholpendt$', startdt='$flow.start$', vervolgactie=$form.lcVervolg$ where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> verholpen;
form -> lcverholpen;
fv_debrief -> verholpendt;
fv_debrief -> startdt;
fv_debrief -> vervolgactie;
form -> lcVervolg;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement118()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE WHEN /*(PATINDEX ('%een%' , '$form.txtNotes$') +
PATINDEX ( '%het%' , '$form.txtNotes$' ) +
PATINDEX ( '%de%' , '$form.txtNotes$' )
) **/ 
(LEN('$form.txtNotes$')-20) > 0 THEN 1 ELSE 0 END AS CheckLidWoordEn50Karakters");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr514()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select description from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr515()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes, extra_notes from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr516()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$sub.txtNotes$', chknotes= CASE WHEN '$sub.txtNotes$'='' THEN 0 ELSE 1 END where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> notes;
fv_debrief -> chknotes;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement119()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$sub.txtNotes$' where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> notes;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement120()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief_teksten (id, notes, engineer_id, radiostatus_id) SELECT newid(), '$form.txtNotes$', id, 0 FROM fv_engineer WHERE id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief_teksten -> id;
fv_debrief_teksten -> notes;
fv_debrief_teksten -> engineer_id;
fv_debrief_teksten -> radiostatus_id;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement121()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_remark (id, notes, engineer_id) SELECT MAX(id) + 1, '$form.txtNotes$', $app.userid$ FROM fv_remark");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_remark -> id;
fv_remark -> notes;
fv_remark -> engineer_id;
}
subgraph select {
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr517()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select def_remark_category_id as def from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr635()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select notes from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr683()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$sub.grdTekst.notes$' as notes from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement122Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description  from fv_remark_category where isactive = 1 order by id
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_remark_category -> isactive;
fv_remark_category -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement123Component2928()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    MIN(r.id) as id,
    substring(r.notes, 1, 
        CASE    WHEN CHARINDEX(nchar(10),r.notes)=0 THEN 80
            WHEN CHARINDEX(nchar(10),r.notes)<80 THEN CHARINDEX(nchar(10),r.notes)
            ELSE 80
        END) as n,
    r.notes
FROM    fv_remark r
WHERE    ((r.engineer_id = $app.userid$ AND $sub.cboCategory$ = -1)
        OR (r.engineer_id is null AND r.remark_category_id = $sub.cboCategory$)
        OR ($sub.cboCategory$ = -2)
    )
    AND r.notes LIKE '%$sub.txtSearch$%'
GROUP BY r.notes
ORDER BY r.notes");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
r -> id;
r -> notes;
r -> notes;
r -> notes;
r -> notes;
r -> notes;
fv_remark -> r;
r -> engineer_id;
app -> userid;
sub -> cboCategory;
r -> engineer_id;
r -> remark_category_id;
sub -> cboCategory;
sub -> cboCategory;
r -> notes;
r -> notes;
r -> notes;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement124()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_debrief set notes = '$sub.txtDebNotes$' + CASE WHEN '$sub.txtDebNotes$'='' THEN '' ELSE ' ' END + '$sub.grdTekst.notes$'  where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> notes;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement125()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_engineer set def_remark_category_id = CASE WHEN '$sub.cboCategory$'='' THEN null ELSE '$sub.cboCategory$' END");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_engineer -> def_remark_category_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement126()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_remark where id = $sub.grdTekst.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_remark -> id;
sub -> grdTekst;
grdTekst -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr518()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select getdate() as nu, id, 0 as def from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestListQuerylstCheck3()
        {
            var statement = MacroScope.Factory.CreateStatement(@"(select 1,'U moet een geldige reden ingeven.',1 as sortorder from fv_activity a where a.id = '$flow.activity_id$' and '$sub.tb_reden$' IN ('', '0', 'NULL')) UNION (select 1, 'klaar', 9 as sortorder from fv_engineer where id = '$app.UserID$') order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> a;
a -> id;
fv_engineer -> id;
fv_engineer -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement127Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT fv_cancelreason.id, fv_cancelreason.description FROM fv_cancelreason WHERE fv_cancelreason.isactive = 1 ORDER BY fv_cancelreason.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_cancelreason -> id;
fv_cancelreason -> description;
fv_cancelreason -> isactive;
fv_cancelreason -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement128()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief 
SET restduur=($sub.txtUren$*60)+$sub.lcMinuten$,
send_email = null
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> restduur;
sub -> txtUren;
sub -> lcMinuten;
fv_debrief -> send_email;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement129()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(isafmeldbonvoorklantverplicht, 0)+COALESCE(ishandtekeningverplicht, 0) AS beidenietverplicht
FROM    fv_activity
WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr521()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief SET vervolgactie_id= CASE WHEN '$form.cbVervolg$' = '' THEN null ELSE $form.cbVervolg$+0 END, vervolgnotes='$form.txtVervolgNotes$',restduur=$form.durRest$/60.0 WHERE activity_id = '$flow.activity_id$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> vervolgactie_id;
form -> cbVervolg;
fv_debrief -> vervolgnotes;
fv_debrief -> restduur;
form -> durRest;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr522()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     vervolgactie_id, vervolgnotes,restduur*60 AS restduur
FROM         fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr523()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  fv_medewerker.description from fv_debrief inner join fv_medewerker on fv_debrief.vervolg_medewerker_id = fv_medewerker.id where fv_debrief.activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_medewerker -> description;
fv_debrief -> vervolg_medewerker_id;
fv_medewerker -> id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement130Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT
    id,
    description
FROM
    fv_vervolgactie
WHERE
    (
     NOT EXISTS ( SELECT
                    0
                  FROM
                    fv_debrief_status
                  WHERE
                    activity_id IN (SELECT
                                        a.id
                                    FROM
                                        fv_activity a
                                        INNER JOIN fv_activity b
                                            ON a.external_id = b.external_id
                                               AND a.sub_id = b.sub_id
                                    WHERE
                                        b.id = '$flow.activity_id$')
                    AND activitystatustype_id IN (157) )
     AND description LIKE '%noodopl.%'
    )
UNION
SELECT
    id,
    description
FROM
    fv_vervolgactie
WHERE
    description NOT LIKE '%noodopl.%'
ORDER BY
    description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
b -> id;
}
fv_debrief_status -> activitystatustype_id;
}
fv_vervolgactie -> description;
fv_vervolgactie -> description;
fv_vervolgactie -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement131()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief
SET    email = '$form.txtEmail$'
        + CASE WHEN LEN('$form.txtEmail$') > 0 THEN ';'
               ELSE ''
          END + '$sub.grdZoekEMail.cc$'
WHERE    activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement132()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE  fv_debrief
SET     email = '$form.txtEmail$'
        + CASE WHEN LEN('$form.txtEmail$') > 0 THEN ';'
               ELSE ''
          END + '$sub.grdZoekEMail.cc$',
        name_signature = '$form.txtParaafNaam$',
        opdrachtnummer = '$form.txtOpdrachtnr$',
        signaturedt = SUBSTRING('$form.datSig$', 1, 11)
        + SUBSTRING('$form.timeSig$', 12, 8)
WHERE   activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> name_signature;
fv_debrief -> opdrachtnummer;
fv_debrief -> signaturedt;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement133Component2981()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  id,
        external_id,
        description,
        email
FROM    fv_medewerker
WHERE   isactive = 1
        AND description LIKE '$sub.txtZoek$' + '%'
        AND '$flow.zoek$' = '1'
        AND COALESCE(email, '') <> ''
UNION
SELECT  id,
        external_id,
        description,
        email
FROM    fv_medewerker
WHERE   isactive = 1
        AND description LIKE '$sub.txtZoek$' + '%'
        AND '$flow.zoek$' = '1'
        AND COALESCE(email, '') = ''
        AND NOT EXISTS ( SELECT    *
                  FROM      fv_medewerker
                  WHERE     isactive = 1
                            AND description LIKE '$sub.txtZoek$' + '%'
                            AND '$flow.zoek$' = '1'
                            AND COALESCE(email, '') <> ''
                )
ORDER BY description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_medewerker -> isactive;
fv_medewerker -> description;
fv_medewerker -> email;
fv_medewerker -> isactive;
fv_medewerker -> description;
fv_medewerker -> email;
fv_medewerker -> isactive;
fv_medewerker -> description;
fv_medewerker -> email;
}
fv_medewerker -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement134()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set sub_id = CASE WHEN '$sub.txtWB$'='' THEN null ELSE '$sub.txtWB$' END, serviceordernumber='$sub.txtSO$' where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> sub_id;
fv_activity -> serviceordernumber;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement135()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activitystatus set radiostatus_id = 0 where activity_id = '$flow.activity_id$' and activitystatustype_id = 30");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activity_id;
fv_activitystatus -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr526()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr527()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select at.external_id as typewerk,
cm.external_id as kunnr,
a.contact as contactpersoonid,
CASE WHEN COALESCE(a.customer_id,0)=0 THEN a.functieplaatsnaam ELSE fp.external_id END as functieplaatsid,
coalesce(eq.external_id,'') as equipmentid,
coalesce(a.description,'') as omschrijving,
coalesce(a.opdrachtnummer,'') as opdrachtnummer,
pc.external_id as productcombi  from fv_activity a inner join fv_activitytype at on at.id = a.activitytype_id left outer join fv_customer_main cm on a.customer_main_id = cm.id left outer join fv_customer fp on a.customer_id = fp.id  left outer join fv_serviceobject eq on a.serviceobject_id = eq.id  left outer join fv_capability pc on a.capability_id = pc.id where a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
at -> external_id;
cm -> external_id;
a -> contact;
a -> customer_id;
a -> functieplaatsnaam;
fp -> external_id;
eq -> external_id;
a -> description;
a -> opdrachtnummer;
pc -> external_id;
fv_activity -> a;
fv_activitytype -> at;
at -> id;
a -> activitytype_id;
fv_customer_main -> cm;
a -> customer_main_id;
cm -> id;
fv_customer -> fp;
a -> customer_id;
fp -> id;
fv_serviceobject -> eq;
a -> serviceobject_id;
eq -> id;
fv_capability -> pc;
a -> capability_id;
pc -> id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement136Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_problemcode where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_problemcode -> isactive;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement137Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_causecode where isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_causecode -> isactive;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr530()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour (id,engineer_id, startdt, rostartdt, radiostatus_id, activity_id, labourstatus_id) SELECT  newid(),   '$app.UserId$', getdate(), getdate() ,  3, '$flow.activity_id$', 2 FROM fv_engineer WHERE fv_engineer.id = '$app.UserId$' and not exists (select id from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id=2 and roenddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour -> id;
fv_labour -> engineer_id;
fv_labour -> startdt;
fv_labour -> rostartdt;
fv_labour -> radiostatus_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
}
subgraph select {
fv_engineer -> id;
subgraph select {
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> roenddt;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr531()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus
(id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '$flow.activity_id$', $app.userid$, getdate(), 50, 0 from fv_engineer where id = $app.userID$ and 50 IN (Select activitystatustype_id from fv_activity where id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
app -> userID;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr624()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    COALESCE(convert(nvarchar,fv_activity.sub_id),'')+ ' / ' + COALESCE(fv_activity.serviceordernumber,'') + ' (' + COALESCE(fv_ordersoort.description,'') + ')' AS serviceordernumber,
    fv_activity.samenvatting AS orderbeschrijving,
    fv_activity.productgroep_id,
    fv_customer.external_id AS SB
FROM    fv_activity
    LEFT OUTER JOIN fv_ordersoort
        ON fv_activity.ordersoort_id = fv_ordersoort.id
    LEFT OUTER JOIN fv_customer
        ON fv_activity.customer_id = fv_customer.id
WHERE    fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> sub_id;
fv_activity -> serviceordernumber;
fv_ordersoort -> description;
fv_activity -> samenvatting;
fv_activity -> productgroep_id;
fv_customer -> external_id;
fv_activity -> ordersoort_id;
fv_ordersoort -> id;
fv_activity -> customer_id;
fv_customer -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement138()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief (id, radiostatus_id, activity_id, serviceobject_id, extra_notes, vervolgactie, name_signature, startdt, opdrachtnummer, send_email, send_specificatie)
SELECT NEWID(), 3, id, serviceobject_id, notes, 0, contactpersoon, GETDATE(), opdrachtnummer, CASE WHEN isafmeldbonvoorklantverplicht = 1 THEN 1 ELSE null END, CASE WHEN isafmeldbonvoorklantverplicht = 1 THEN 1 ELSE null END
FROM fv_activity
WHERE id = '$flow.activity_id$'
    AND NOT EXISTS (SELECT id FROM fv_debrief WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief -> id;
fv_debrief -> radiostatus_id;
fv_debrief -> activity_id;
fv_debrief -> serviceobject_id;
fv_debrief -> extra_notes;
fv_debrief -> vervolgactie;
fv_debrief -> name_signature;
fv_debrief -> startdt;
fv_debrief -> opdrachtnummer;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
}
subgraph select {
fv_activity -> id;
subgraph select {
fv_debrief -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement139()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_labour SET rostartdt = GETDATE() WHERE activity_id = '$flow.activity_id$' AND labourstatus_id = 2 AND enddt IS NULL");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour -> rostartdt;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement140()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
SELECT NEWID(), '$flow.activity_id$', $app.userid$, getdate(), 50, 0
FROM fv_engineer
WHERE id = $app.userID$
    AND 50 NOT IN (SELECT activitystatustype_id FROM fv_activity WHERE id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
app -> userID;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement141()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt ,engineer_id ,radiostatus_id)
SELECT NEWID(), id, external_id, sub_id, 50, GETDATE(), $app.userID$, 0 FROM fv_activity
WHERE id = '$flow.activity_id$'
    AND 50 NOT IN (SELECT activitystatustype_id FROM fv_debrief_status WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief_status -> id;
fv_debrief_status -> activity_id;
fv_debrief_status -> external_id;
fv_debrief_status -> sub_id;
fv_debrief_status -> activitystatustype_id;
fv_debrief_status -> statusdt;
fv_debrief_status -> engineer_id;
fv_debrief_status -> radiostatus_id;
}
subgraph select {
app -> userID;
fv_activity -> id;
subgraph select {
fv_debrief_status -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement142()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
SELECT NEWID(), '$flow.activity_id$', $app.userid$, getdate(), 59, 0
FROM fv_engineer
WHERE id = $app.userID$
    AND 59 NOT IN (SELECT activitystatustype_id FROM fv_debrief_status WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
app -> userID;
subgraph select {
fv_debrief_status -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement143()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt ,engineer_id ,radiostatus_id)
SELECT NEWID(), id, external_id, sub_id, 59, GETDATE(), $app.userID$, 0) FROM fv_activity
WHERE id = '$flow.activity_id$'
    AND 59 NOT IN (SELECT activitystatustype_id FROM fv_debrief_status WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief_status -> id;
fv_debrief_status -> activity_id;
fv_debrief_status -> external_id;
fv_debrief_status -> sub_id;
fv_debrief_status -> activitystatustype_id;
fv_debrief_status -> statusdt;
fv_debrief_status -> engineer_id;
fv_debrief_status -> radiostatus_id;
}
subgraph select {
app -> userID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement144()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS IsFunctieHersteld FROM fv_debrief_status
WHERE activity_id IN ( SELECT a.id FROM fv_activity a
INNER JOIN fv_activity b ON
a.external_id = b.external_id
AND a.sub_id = b.sub_id
WHERE b.id = '$flow.activity_id$')
AND activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
b -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement145()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief (id, radiostatus_id, activity_id, serviceobject_id, extra_notes, vervolgactie, name_signature, startdt, opdrachtnummer, send_email, send_specificatie)
SELECT NEWID(), 3, id, serviceobject_id, notes, 0, contactpersoon, GETDATE(), opdrachtnummer, CASE WHEN isafmeldbonvoorklantverplicht = 1 THEN 1 ELSE null END, CASE WHEN IsUrenSpecificatieVerplicht = 1 THEN 1 ELSE null END
FROM fv_activity
WHERE id = '$flow.activity_id$'
    AND NOT EXISTS (SELECT id FROM fv_debrief WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief -> id;
fv_debrief -> radiostatus_id;
fv_debrief -> activity_id;
fv_debrief -> serviceobject_id;
fv_debrief -> extra_notes;
fv_debrief -> vervolgactie;
fv_debrief -> name_signature;
fv_debrief -> startdt;
fv_debrief -> opdrachtnummer;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
}
subgraph select {
fv_activity -> id;
subgraph select {
fv_debrief -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement146()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
SELECT NEWID(), '$flow.activity_id$', $app.userid$, getdate(), 52, 0
FROM fv_engineer
WHERE id = $app.userID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
app -> userID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement147()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT   COALESCE(isequipmentscannenverplicht, 0)   AS isequipmentscannenverplicht
  FROM    fv_activity
  WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement148()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT   COALESCE(isequipmentscannenverplicht, 0)   AS isequipmentscannenverplicht
  FROM    fv_activity
  WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr538()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    COALESCE(convert(nvarchar,fv_activity.sub_id),'') + ' / ' + COALESCE(fv_activity.serviceordernumber,'') + ' (' + COALESCE(fv_ordersoort.description,'') + ')' as serviceordernumber,
    fv_activity.samenvatting
FROM    fv_activity
    LEFT OUTER JOIN fv_ordersoort
        ON fv_activity.ordersoort_id = fv_ordersoort.id
WHERE    fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> sub_id;
fv_activity -> serviceordernumber;
fv_ordersoort -> description;
fv_activity -> samenvatting;
fv_activity -> ordersoort_id;
fv_ordersoort -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr539()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour (id,engineer_id, startdt, rostartdt, radiostatus_id, activity_id, labourstatus_id) SELECT  newid(),   '$app.UserId$', getdate(), getdate() ,  3, '$flow.activity_id$', 2 FROM fv_engineer WHERE fv_engineer.id = '$app.UserId$' and not exists (select id from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id=2 and roenddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour -> id;
fv_labour -> engineer_id;
fv_labour -> startdt;
fv_labour -> rostartdt;
fv_labour -> radiostatus_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
}
subgraph select {
fv_engineer -> id;
subgraph select {
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> roenddt;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr540()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus
(id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
select newid(), '$flow.activity_id$', $app.userid$, getdate(), 50, 0 from fv_engineer where id = $app.userID$ and 50 IN (Select activitystatustype_id from fv_activity where id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
app -> userID;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement149()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CONVERT(NVARCHAR, COALESCE(MIN(ds.statusdt),
                                   DATEADD(year, 1, GETDATE())), 126) AS debrief_statusdt
FROM    fv_debrief_status ds
        INNER JOIN fv_activity a ON a.external_id = ds.external_id
                                    AND a.sub_id = ds.sub_id
                                    AND a.activitystatustype_id NOT IN ( 120, 125, 60, 62 )
WHERE   ds.activitystatustype_id = 59
        AND NOT EXISTS ( SELECT 0
                         FROM   fv_activitystatus acts
                         WHERE  acts.activity_id = a.id
                                AND acts.activitystatustype_id IN ( 120, 125, 60, 62 ) )
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ds -> statusdt;
fv_debrief_status -> ds;
fv_activity -> a;
a -> external_id;
ds -> external_id;
a -> sub_id;
ds -> sub_id;
a -> activitystatustype_id;
ds -> activitystatustype_id;
fv_activitystatus -> acts;
acts -> activity_id;
a -> id;
acts -> activitystatustype_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement150()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief (id, radiostatus_id, activity_id, serviceobject_id, extra_notes, vervolgactie, name_signature, startdt, opdrachtnummer, send_email, send_specificatie)
SELECT NEWID(), 3, id, serviceobject_id, notes, 0, contactpersoon, GETDATE(), opdrachtnummer, CASE WHEN isafmeldbonvoorklantverplicht = 1 THEN 1 ELSE null END, CASE WHEN IsUrenSpecificatieVerplicht = 1 THEN 1 ELSE null END
FROM fv_activity
WHERE id = '$flow.activity_id$'
    AND NOT EXISTS (SELECT id FROM fv_debrief WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief -> id;
fv_debrief -> radiostatus_id;
fv_debrief -> activity_id;
fv_debrief -> serviceobject_id;
fv_debrief -> extra_notes;
fv_debrief -> vervolgactie;
fv_debrief -> name_signature;
fv_debrief -> startdt;
fv_debrief -> opdrachtnummer;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
}
subgraph select {
fv_activity -> id;
subgraph select {
fv_debrief -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement151()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_labour SET rostartdt = GETDATE() WHERE activity_id = '$flow.activity_id$' AND labourstatus_id = 2 AND enddt IS NULL");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour -> rostartdt;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement152()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
SELECT NEWID(), '$flow.activity_id$', $app.userid$, getdate(), 50, CASE WHEN COALESCE(IsAntidaterenToegestaan,0) = 1 THEN -1 ELSE 0 END
FROM fv_activity
WHERE id = '$flow.activity_id$' AND activitystatustype_id!=50");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
fv_activity -> id;
fv_activity -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement153()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(IsAntidaterenToegestaan,1) FROM fv_activity WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement154()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS IsOrderStarted FROM fv_debrief_status
WHERE activity_id IN ( SELECT a.id FROM fv_activity a
INNER JOIN fv_activity b ON
a.external_id = b.external_id
AND a.sub_id = b.sub_id
WHERE b.id = '$flow.activity_id$')
AND activitystatustype_id in (50,157)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
b -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement155()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt ,engineer_id ,radiostatus_id)
SELECT NEWID(), id, external_id, sub_id, 50, GETDATE(), $app.userID$, 0 FROM fv_activity
WHERE id = '$flow.activity_id$'
    AND 50 NOT IN (SELECT activitystatustype_id FROM fv_debrief_status WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief_status -> id;
fv_debrief_status -> activity_id;
fv_debrief_status -> external_id;
fv_debrief_status -> sub_id;
fv_debrief_status -> activitystatustype_id;
fv_debrief_status -> statusdt;
fv_debrief_status -> engineer_id;
fv_debrief_status -> radiostatus_id;
}
subgraph select {
app -> userID;
fv_activity -> id;
subgraph select {
fv_debrief_status -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement156()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_activitystatus (id, activity_id, engineer_id, statusdt, activitystatustype_id, radiostatus_id )
SELECT NEWID(), '$flow.activity_id$', $app.userid$, getdate(), 59, CASE WHEN COALESCE(IsAntidaterenToegestaan,0) = 1 THEN -1 ELSE 0 END
FROM fv_activity
WHERE id = '$flow.activity_id$' AND activitystatustype_id!=59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> activity_id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> radiostatus_id;
}
subgraph select {
app -> userid;
fv_activity -> id;
fv_activity -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement157()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(IsAntidaterenToegestaan,1) FROM fv_activity WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement158()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS IsOrderStarted FROM fv_debrief_status
WHERE activity_id IN ( SELECT a.id FROM fv_activity a
INNER JOIN fv_activity b ON
a.external_id = b.external_id
AND a.sub_id = b.sub_id
WHERE b.id = '$flow.activity_id$')
AND activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
b -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement159()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt, rostatusdt, engineer_id ,radiostatus_id)
SELECT NEWID(), id, external_id, sub_id, 59, GETDATE(), '$flow.verholpendt$', $app.userID$, 0 FROM fv_activity
WHERE id = '$flow.activity_id$'
    AND 59 NOT IN (SELECT activitystatustype_id FROM fv_debrief_status WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief_status -> id;
fv_debrief_status -> activity_id;
fv_debrief_status -> external_id;
fv_debrief_status -> sub_id;
fv_debrief_status -> activitystatustype_id;
fv_debrief_status -> statusdt;
fv_debrief_status -> rostatusdt;
fv_debrief_status -> engineer_id;
fv_debrief_status -> radiostatus_id;
}
subgraph select {
app -> userID;
fv_activity -> id;
subgraph select {
fv_debrief_status -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr545()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     COALESCE(convert(nvarchar,fv_activity.sub_id),'') as werkbonnr, COALESCE(fv_activity.serviceordernumber,'') as serviceordernumber, COALESCE(fv_ordersoort.description,'') + ' - ' + COALESCE(at.description,'') AS ordersoort, fv_activity.sub_id, fv_activity.name, fv_activity.name_2, 
                      fv_activity.functieplaatsnaam, fv_activity.opdrachtnummer, fv_activity.description, fv_activity.melddatum, fv_activity.melder, 
                      fv_activity.melder_phone, fv_priority.description AS priority, fv_activity.notes, c.external_id as functieplaatsnr, s.external_id as equipmentnr, fv_activity.equipmentname,
fv_activity.planstartdt, opdrachtnummer
FROM         fv_activity LEFT OUTER JOIN
                      fv_ordersoort ON fv_activity.ordersoort_id = fv_ordersoort.id LEFT OUTER JOIN
                      fv_priority ON fv_activity.priority_id = fv_priority.id LEFT OUTER JOIN
fv_activitytype at on fv_activity.activitytype_id = at.id LEFT OUTER JOIN fv_customer c on fv_activity.customer_id = c.id LEFT OUTER JOIN fv_serviceobject s on fv_activity.serviceobject_id = s.id
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> sub_id;
fv_activity -> serviceordernumber;
fv_ordersoort -> description;
at -> description;
fv_activity -> sub_id;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> functieplaatsnaam;
fv_activity -> opdrachtnummer;
fv_activity -> description;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_priority -> description;
fv_activity -> notes;
c -> external_id;
s -> external_id;
fv_activity -> equipmentname;
fv_activity -> planstartdt;
fv_activity -> ordersoort_id;
fv_ordersoort -> id;
fv_activity -> priority_id;
fv_priority -> id;
fv_activitytype -> at;
fv_activity -> activitytype_id;
at -> id;
fv_customer -> c;
fv_activity -> customer_id;
c -> id;
fv_serviceobject -> s;
fv_activity -> serviceobject_id;
s -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr552()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(fv_activity.serviceordernumber,'') as serviceordernumber from fv_activity where  id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr553()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) as aantal from fv_materialmutation where activity_id = '$flow.activity_id$' and external_id is null and not purchaseorderpositie is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialmutation -> activity_id;
fv_materialmutation -> external_id;
fv_materialmutation -> purchaseorderpositie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr681()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement160()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement161()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement162Component3800()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, purchaseorder, leveranciernaam, Convert(nvarchar,orderdt,105) + ' ' + COALESCE(besteller,'') as orderdt, CASE WHEN selected=1 THEN '*' ELSE '' END as selected from fv_tmp_purchaseorder order by purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_purchaseorder -> purchaseorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement163()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_purchaseorder set selected = CASE WHEN COALESCE(selected,0) = 0 THEN 1 ELSE 0 END where id = '$sub.grdOrder.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_purchaseorder -> selected;
fv_tmp_purchaseorder -> selected;
fv_tmp_purchaseorder -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement164Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(fa_aantal,go_aantal,be_aantal) as aantal, omschrijving from fv_tmp_purchaseorderline where purchaseorder = '$sub.grdOrder.purchaseorder$' order by positie");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_purchaseorderline -> purchaseorder;
fv_tmp_purchaseorderline -> positie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement165()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,quantity,radiostatus_id,type) select '$flow.mat_id$','$flow.activity_id$',getdate(),1,-1,'D' from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_materialmutation -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> mutationdt;
fv_materialmutation -> quantity;
fv_materialmutation -> radiostatus_id;
fv_materialmutation -> type;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement166Component3133()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     coalesce(bestelnr,'') + '/' + coalesce(description,'') + '/' + coalesce(supplier_name,'') as omsch, quantity, type, id,'' as empty
FROM         fv_materialmutation
WHERE     ((type = 'D') OR(type = 'O')) and activity_id = '$flow.activity_id$' and fv_materialmutation.external_id is null and fv_materialmutation.purchaseorderpositie is null
UNION
SELECT     coalesce(fv_material.bestelnr,'') + '/' + coalesce(fv_materialmutation.description,'') + '/' + coalesce(fv_supplier.description,'') AS omsch, fv_materialmutation.quantity, type, fv_materialmutation.id,'' as empty
FROM         fv_materialmutation INNER JOIN
                      fv_material ON fv_materialmutation.material_id = fv_material.id LEFT OUTER JOIN
                      fv_supplier ON fv_material.supplier_id = fv_supplier.id
WHERE     (fv_materialmutation.type = 'A') and  activity_id = '$flow.activity_id$' and fv_materialmutation.external_id is null and fv_materialmutation.purchaseorderpositie is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialmutation -> type;
fv_materialmutation -> type;
fv_materialmutation -> activity_id;
fv_materialmutation -> external_id;
fv_materialmutation -> purchaseorderpositie;
fv_material -> bestelnr;
fv_materialmutation -> description;
fv_supplier -> description;
fv_materialmutation -> quantity;
fv_materialmutation -> id;
fv_materialmutation -> material_id;
fv_material -> id;
fv_material -> supplier_id;
fv_supplier -> id;
fv_materialmutation -> type;
fv_materialmutation -> activity_id;
fv_materialmutation -> external_id;
fv_materialmutation -> purchaseorderpositie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr564()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sonummer,werkbon,COALESCE(s.description,'') + '; ' + t.leveranciernummer as leveranciernummer, COALESCE(t.naam,'') + '
' + COALESCE(t.straat,'') + ' ' + COALESCE(t.huisnummer,'') + '
' + COALESCE(t.postcode,'') + ' ' + COALESCE(t.plaats,'') as adres,CASE WHEN t.onderaanneming=1 THEN 'true' ELSE 'false' END as onderaanneming, CASE WHEN t.balie=1 THEN 'true' ELSE 'false' END as balie, COALESCE(t.straat,'') as straat, COALESCE(t.leveranciernummer,'') as levnr from fv_tmp_bestelling t left outer join fv_supplier s on s.external_id = t.leveranciernummer");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
s -> description;
t -> leveranciernummer;
t -> naam;
t -> straat;
t -> huisnummer;
t -> postcode;
t -> plaats;
t -> onderaanneming;
t -> balie;
t -> straat;
t -> leveranciernummer;
fv_tmp_bestelling -> t;
fv_supplier -> s;
s -> external_id;
t -> leveranciernummer;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr565()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr567()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set onderaanneming = CASE when '$form.chkOA$'='true' THEN 1 ELSE 0 END, balie = CASE when '$form.chkBalie$'='true' THEN 1 ELSE 0 END");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bestelling -> onderaanneming;
fv_tmp_bestelling -> balie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr569()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,aantal,type) select newid(),1,'O' from fv_engineer where id = $app.Userid$ and '$flow.OA$'='1' and NOT EXISTS (select id from fv_tmp_bestellingregel)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bestellingregel -> id;
fv_tmp_bestellingregel -> aantal;
fv_tmp_bestellingregel -> type;
}
subgraph select {
fv_engineer -> id;
app -> Userid;
subgraph select {
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement167()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE from fv_tmp_bestellingregel where EXISTS (select id from fv_tmp_bestelling where type<>'O')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_tmp_bestelling -> id;
fv_tmp_bestelling -> type;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement168()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE from fv_tmp_bestellingregel where EXISTS (select id from fv_tmp_bestelling where type='O')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_tmp_bestelling -> id;
fv_tmp_bestelling -> type;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement169()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set onderaanneming = CASE when '$form.chkOA$'='true' THEN 1 ELSE 0 END, balie = CASE when '$form.chkBalie$'='true' THEN 1 ELSE 0 END");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bestelling -> onderaanneming;
fv_tmp_bestelling -> balie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement170()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set description = '$flow.Bestelling_nummer$' where id = '$flow.activity_id$' and ordersoort_id = -2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> description;
fv_activity -> id;
fv_activity -> ordersoort_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement171Component3162()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     omschrijving as omsch, aantal as quantity, type, id,'' as empty
FROM         fv_tmp_bestellingregel

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement172()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,aantal,type) select '$flow.mat_id$',1,'D' from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bestellingregel -> id;
fv_tmp_bestellingregel -> aantal;
fv_tmp_bestellingregel -> type;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr554()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_supplier where gabicode = '29'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> gabicode;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement173Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_supplier where isactive =1 and not gabicode is null
order by description
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> isactive;
fv_supplier -> gabicode;
fv_supplier -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement174Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_material.id,fv_material.bestelnr + '/'  + fv_supplier.description AS omsch, fv_material.hitrate, fv_material.description, fv_material.external_id FROM fv_material inner JOIN fv_supplier ON fv_material.supplier_id = fv_supplier.id where 0 = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_material -> id;
fv_material -> bestelnr;
fv_supplier -> description;
fv_material -> hitrate;
fv_material -> description;
fv_material -> external_id;
fv_material -> supplier_id;
fv_supplier -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr555()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_material.bestelnr, fv_material.description, fv_supplier.description AS supomsch, fv_material.price, 1 as def
FROM            fv_material LEFT OUTER JOIN
                      fv_supplier ON fv_material.supplier_id = fv_supplier.id
WHERE  fv_material.id = $sub.grdZoekArtBest.id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_material -> bestelnr;
fv_material -> description;
fv_supplier -> description;
fv_material -> price;
fv_material -> supplier_id;
fv_supplier -> id;
fv_material -> id;
sub -> grdZoekArtBest;
grdZoekArtBest -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement175()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,bestelling_id,aantal,artikelnummer,omschrijving,prijs,type) select newid(),id,$sub.txtAantal$,'$sub.txtBestel$','$sub.txtOms$',$sub.txtPrice$,'A' from fv_tmp_bestelling where id = '$flow.bestel_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bestellingregel -> id;
fv_tmp_bestellingregel -> bestelling_id;
fv_tmp_bestellingregel -> aantal;
fv_tmp_bestellingregel -> artikelnummer;
fv_tmp_bestellingregel -> omschrijving;
fv_tmp_bestellingregel -> prijs;
fv_tmp_bestellingregel -> type;
}
subgraph select {
sub -> txtAantal;
sub -> txtPrice;
fv_tmp_bestelling -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr556()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 1 as def from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement176()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,bestelling_id,artikelnummer,aantal,omschrijving,type) select newid(),'$flow.bestel_id$','$sub.txtBestel1$',$sub.txtAantal1$,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel1$') group by bestelnr UNION select newid(),'$flow.bestel_id$','$sub.txtBestel2$',$sub.txtAantal2$,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel2$') group by bestelnr UNION select newid(),'$flow.bestel_id$','$sub.txtBestel3$',$sub.txtAantal3$,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel3$') group by bestelnr UNION select newid(),'$flow.bestel_id$','$sub.txtBestel4$',$sub.txtAantal4$,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel4$') group by bestelnr UNION select newid(),'$flow.bestel_id$','$sub.txtBestel5$',$sub.txtAantal5$,MIN(description),'A' from fv_material where (bestelnr = '$sub.txtBestel5$') group by bestelnr ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bestellingregel -> id;
fv_tmp_bestellingregel -> bestelling_id;
fv_tmp_bestellingregel -> artikelnummer;
fv_tmp_bestellingregel -> aantal;
fv_tmp_bestellingregel -> omschrijving;
fv_tmp_bestellingregel -> type;
}
subgraph select {
sub -> txtAantal1;
fv_material -> bestelnr;
fv_material -> bestelnr;
subgraph select {
sub -> txtAantal2;
fv_material -> bestelnr;
fv_material -> bestelnr;
subgraph select {
sub -> txtAantal3;
fv_material -> bestelnr;
fv_material -> bestelnr;
subgraph select {
sub -> txtAantal4;
fv_material -> bestelnr;
fv_material -> bestelnr;
subgraph select {
sub -> txtAantal5;
fv_material -> bestelnr;
fv_material -> bestelnr;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr557()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestellingregel (id,bestelling_id,artikelnummer,aantal,omschrijving,type) select '$flow.mat_id$', '$flow.bestel_id$', m.external_id, 1, m.description, fv_materialgroup.category from fv_materialgroup left outer join fv_material m on fv_materialgroup.material_external_id = m.external_id where fv_materialgroup.id = $form.id$ and '$flow.screen$'<>''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bestellingregel -> id;
fv_tmp_bestellingregel -> bestelling_id;
fv_tmp_bestellingregel -> artikelnummer;
fv_tmp_bestellingregel -> aantal;
fv_tmp_bestellingregel -> omschrijving;
fv_tmp_bestellingregel -> type;
}
subgraph select {
m -> external_id;
m -> description;
fv_materialgroup -> category;
fv_material -> m;
fv_materialgroup -> material_external_id;
m -> external_id;
fv_materialgroup -> id;
form -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement177Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialgroup where category='H' and isactive =1 order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialgroup -> category;
fv_materialgroup -> isactive;
fv_materialgroup -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement178Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_materialgroup where category='S' and isactive =1 and parent_id = $form.cbHead$ order by description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialgroup -> category;
fv_materialgroup -> isactive;
fv_materialgroup -> parent_id;
form -> cbHead;
fv_materialgroup -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement179Component3200()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     fv_material.description as oms, fv_materialgroup.category, fv_materialgroup.id
FROM         fv_material RIGHT OUTER JOIN
                      fv_materialgroup ON fv_material.external_id = fv_materialgroup.material_external_id
WHERE fv_materialgroup.parent_id = $form.cbSub$ order by fv_materialgroup.external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_material -> description;
fv_materialgroup -> category;
fv_materialgroup -> id;
fv_material -> external_id;
fv_materialgroup -> material_external_id;
fv_materialgroup -> parent_id;
form -> cbSub;
fv_materialgroup -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement180()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestellingregel set aantal=$form.txtAantal$,omschrijving='$form.txtOms$' where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bestellingregel -> aantal;
form -> txtAantal;
fv_tmp_bestellingregel -> omschrijving;
fv_tmp_bestellingregel -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr558()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     artikelnummer,omschrijving,aantal,prijs
FROM            fv_tmp_bestellingregel
WHERE  id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_bestellingregel -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement181()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_tmp_bestellingregel -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement182()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestellingregel set artikelnummer='$form.txtBestel$', aantal=$form.txtAantal$,omschrijving='$form.txtOms$',prijs=convert(real,replace('$form.txtPrice$',',','.')) where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bestellingregel -> artikelnummer;
fv_tmp_bestellingregel -> aantal;
form -> txtAantal;
fv_tmp_bestellingregel -> omschrijving;
fv_tmp_bestellingregel -> prijs;
fv_tmp_bestellingregel -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr559()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT artikelnummer,omschrijving,aantal,prijs
FROM            fv_tmp_bestellingregel
WHERE  id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_bestellingregel -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement183()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_tmp_bestellingregel -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement184()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel where prijs is null and id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_tmp_bestellingregel -> prijs;
fv_tmp_bestellingregel -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement185()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestellingregel set artikelnummer='$form.txtBestel$', aantal=$form.txtAantal$,omschrijving='$form.txtOms$',prijs=convert(real,replace('$form.txtPrice$',',','.'))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bestellingregel -> artikelnummer;
fv_tmp_bestellingregel -> aantal;
form -> txtAantal;
fv_tmp_bestellingregel -> omschrijving;
fv_tmp_bestellingregel -> prijs;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr561()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT artikelnummer,omschrijving,aantal,prijs
FROM            fv_tmp_bestellingregel
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestListQuerylstCheck4()
        {
            var statement = MacroScope.Factory.CreateStatement(@"(select 1, 'U moet de geschatte prijs nog invullen.', 2 as sortorder from fv_debrief where activity_id = '$flow.activity_id$' and '$form.txtPrice$'='') UNION (select 1, 'klaar', 9 as sortorder from fv_engineer where id = '$app.UserID$') order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
fv_engineer -> id;
fv_engineer -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement186()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_bestellingregel");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr563()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '-' as def from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr577()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select leveranciernummer from fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr667()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$sub.grdZoekLev3.totaal$' as totaal from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement187Component3234()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description, external_id + '
' + description + '
' + Coalesce(straat,'') + ' ' + Coalesce(huisnummer,'') + '
' + COALESCE(postcode,'') + ' ' + COALESCE(plaats,'') + '
tel: ' + coalesce(telefoon,'') + '
fax: ' + coalesce(fax,'') as totaal from fv_supplier where isactive = 1 and description like '%'+'$sub.txtZoek$' + '%' and $flow.zoek$=1

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> isactive;
fv_supplier -> description;
flow -> zoek;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement188()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set leveranciernummer = '$sub.grdZoekLev3.ext_id$' where id = '$flow.bestel_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bestelling -> leveranciernummer;
fv_tmp_bestelling -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr566()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password, '$flow.functieplaats$' as fp from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement189()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_orderrequest");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement190()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_orderrequest set selected=1 where sonummer = '$flow.sonrophalen$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_orderrequest -> selected;
fv_tmp_orderrequest -> sonummer;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement191Component3249()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sonummer, COALESCE(sonummer,'') + ' ' + COALESCE(omschrijving,'') + ' ' + COALESCE(basisstart,'') + ' ' + COALESCE(basiseind,'') as omschrijving from fv_tmp_orderrequest where selected=0 order by sonummer");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_orderrequest -> selected;
fv_tmp_orderrequest -> sonummer;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement192()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_orderrequest set selected=0 where sonummer = '$flow.sonrgekozen$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_orderrequest -> selected;
fv_tmp_orderrequest -> sonummer;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement193Component3252()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sonummer, COALESCE(sonummer,'') + ' ' + COALESCE(omschrijving,'') + ' ' + COALESCE(basisstart,'') + ' ' + COALESCE(basiseind,'') as omschrijving from fv_tmp_orderrequest where selected=1 order by sonummer");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_orderrequest -> selected;
fv_tmp_orderrequest -> sonummer;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr568()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select naam,naam2,straat,huisnummer,postcode,plaats,land from fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement194()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set naam='$sub.txtNaam$',naam2='$sub.txtNaam2$',straat='$sub.txtStraat$',plaats='$sub.txtPlaats$',postcode='$sub.txtZip$',land='$sub.txtLand$',onderaanneming = CASE when '$form.chkOA$'='true' THEN 1 ELSE 0 END, balie = CASE when '$form.chkBalie$'='true' THEN 1 ELSE 0 END");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bestelling -> naam;
fv_tmp_bestelling -> naam2;
fv_tmp_bestelling -> straat;
fv_tmp_bestelling -> plaats;
fv_tmp_bestelling -> postcode;
fv_tmp_bestelling -> land;
fv_tmp_bestelling -> onderaanneming;
fv_tmp_bestelling -> balie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr570()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement195()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_orderrequest");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement196()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_tmp_orderrequest (sonummer,selected) select '$sub.txtSO$',1 from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_orderrequest -> sonummer;
fv_tmp_orderrequest -> selected;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr571()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(fv_activity.serviceordernumber,'') as serviceordernumber from fv_activity where  id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr573()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement197()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement198()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement199Component3281()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, purchaseorder, leveranciernaam, Convert(nvarchar,orderdt,105) + ' ' + COALESCE(besteller,'') as orderdt, CASE WHEN selected=1 THEN 'V' ELSE '' END as selected from fv_tmp_purchaseorder order by purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_purchaseorder -> purchaseorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement200Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(fa_aantal,go_aantal,be_aantal) as aantal, omschrijving from fv_tmp_purchaseorderline where purchaseorder = '$sub.grdOrder.purchaseorder$' order by positie");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_purchaseorderline -> purchaseorder;
fv_tmp_purchaseorderline -> positie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement201()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_purchaseorder set selected = CASE WHEN COALESCE(selected,0) = 0 THEN 1 ELSE 0 END where id = '$sub.grdOrder.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_purchaseorder -> selected;
fv_tmp_purchaseorder -> selected;
fv_tmp_purchaseorder -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement202()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_purchaseorder set selected = 0 where id <> '$sub.grdOrder.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_purchaseorder -> selected;
fv_tmp_purchaseorder -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr574()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement203()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement204()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement205()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_purchaseorder set selected = 1 where purchaseorder in (select min(purchaseorder) from fv_tmp_purchaseorder)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_purchaseorder -> selected;
fv_tmp_purchaseorder -> purchaseorder;
subgraph select {
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement206Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(ol.fa_aantal,ol.go_aantal,ol.be_aantal) as aantal, ol.omschrijving from fv_tmp_purchaseorderline ol inner join fv_tmp_purchaseorder o on ol.purchaseorder = o.purchaseorder and o.selected = 1 order by ol.positie");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ol -> fa_aantal;
ol -> go_aantal;
ol -> be_aantal;
ol -> omschrijving;
fv_tmp_purchaseorderline -> ol;
fv_tmp_purchaseorder -> o;
ol -> purchaseorder;
o -> purchaseorder;
o -> selected;
ol -> positie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr576()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select description, Coalesce(straat,'') + Coalesce(huisnummer,'') as adres, postcode, plaats, telefoon, fax, external_id from fv_supplier where external_id = '$sub.txtLevNr$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr595()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE WHEN '$flow.werkdatum$'='' THEN CONVERT(datetime,Substring(Convert(nvarchar,getdate(),126),1,10)) else Convert(datetime,'$flow.werkdatum$') END as datum from fv_engineer where id = $app.Userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> Userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr596()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('indirect', 'normaal', 'reis binnen werktijd') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal) ELSE 0 END)) / 60 AS N_aantal,
    CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('reis') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal) ELSE 0 END)) / 60 AS R_aantal,
    CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('over', 'over_extra', 'overuren 1en2') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal) ELSE 0 END)) / 60 AS O_aantal,
    DATEPART(wk, dateadd(dd,-1,CONVERT(DATETIME, '$sub.dtWeek$'))) + 1 - DATEPART(ww, DATEADD(yy, ( DATEPART(YEAR, CONVERT(DATETIME, '$sub.dtWeek$')) - 1900 ), 0) + 3) AS weeknr
FROM    fv_engineer
    CROSS JOIN fv_weekdagen
    LEFT OUTER JOIN fv_declaratie d
        ON d.werkdt = DATEADD(dd, fv_weekdagen.id, DATEADD(dd, 2 - DATEPART(dw, '$sub.dtWeek$') - CASE WHEN DATEPART(dw, '$sub.dtWeek$') = 1 THEN 7 ELSE 0 END, '$sub.dtWeek$'))
            AND d.engineer_id = fv_engineer.id
    LEFT OUTER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
    LEFT OUTER JOIN fv_looncomponent lc
        ON lm.looncomponent_id = lc.id
WHERE    fv_engineer.id = $app.userid$
GROUP BY    fv_engineer.id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> veldindicatie;
d -> aantal;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
d -> aantal;
fv_declaratie -> d;
d -> werkdt;
fv_weekdagen -> id;
d -> engineer_id;
fv_engineer -> id;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
fv_engineer -> id;
app -> userid;
fv_engineer -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestListQuerylstCheck5()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 1,'Uren ' + convert(nvarchar,fv_declaratie.werkdt,105) + ' nog niet verstuurd' as description, 1 as sortorder, fv_declaratie.werkdt as sortdt
from 
fv_declaratie inner join 
fv_declaratie d on 
    d.werkdt = fv_declaratie.werkdt and 
    CASE WHEN COALESCE(d.message,'')='' and COALESCE(d.keurregistratie,'0')<>'0' THEN 0 else 1 END <> 0
where fv_declaratie.engineer_id = $app.userid$ and fv_declaratie.werkdt<getdate()-1
group by fv_declaratie.werkdt
UNION
select 1 , 'klaar', 9 as sortorder, getdate() as sortdt from fv_engineer where id = $app.userid$
order by sortorder, sortdt desc
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> werkdt;
fv_declaratie -> werkdt;
fv_declaratie -> d;
d -> werkdt;
fv_declaratie -> werkdt;
d -> message;
d -> keurregistratie;
fv_declaratie -> engineer_id;
app -> userid;
fv_declaratie -> werkdt;
fv_declaratie -> werkdt;
fv_engineer -> id;
app -> userid;
fv_engineer -> sortorder;
fv_engineer -> sortdt;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement207Component3315()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    fv_weekdagen.dagnaam AS weekdag,
    DATEADD(dd, fv_weekdagen.id, DATEADD(dd, 2 - DATEPART(dw, '$sub.dtWeek$') - CASE WHEN DATEPART(dw, '$sub.dtWeek$') = 1 THEN 7 ELSE 0 END, '$sub.dtWeek$')) AS dag,
    CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('indirect', 'normaal', 'reis binnen werktijd') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal) ELSE 0 END)) / 60 AS N_aantal,
    CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('reis') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal) ELSE 0 END)) / 60 AS R_aantal,
    CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('over', 'over_extra', 'overuren 1en2') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal) ELSE 0 END)) / 60 AS O_aantal,
    CASE WHEN SUM(CASE WHEN COALESCE(message, '') = '' AND COALESCE(keurregistratie, '0') <> '0' THEN 0 ELSE 1 END) = 0 THEN 'OK' ELSE '' END AS verstuurd
FROM    fv_engineer
    CROSS JOIN fv_weekdagen
    LEFT OUTER JOIN fv_declaratie d
        ON d.werkdt = DATEADD(dd, fv_weekdagen.id, DATEADD(dd, 2 - DATEPART(dw, '$sub.dtWeek$') - CASE WHEN DATEPART(dw, '$sub.dtWeek$') = 1 THEN 7 ELSE 0 END, '$sub.dtWeek$'))
            AND d.engineer_id = fv_engineer.id
    LEFT OUTER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
    LEFT OUTER JOIN fv_looncomponent lc
        ON lm.looncomponent_id = lc.id
WHERE    fv_engineer.id = $app.userid$
GROUP BY    fv_weekdagen.dagnaam,
    fv_weekdagen.id
ORDER BY    dag");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_weekdagen -> dagnaam;
fv_weekdagen -> id;
lm -> veldindicatie;
d -> aantal;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
d -> aantal;
fv_declaratie -> d;
d -> werkdt;
fv_weekdagen -> id;
d -> engineer_id;
fv_engineer -> id;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
fv_engineer -> id;
app -> userid;
fv_weekdagen -> dagnaam;
fv_weekdagen -> id;
fv_engineer -> dag;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr583()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT   CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('indirect', 'normaal', 'reis binnen werktijd') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal)
                           ELSE 0
                      END)) / 60 AS N_aantal,
    CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('reis') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal)
                           ELSE 0
                      END)) / 60 AS R_aantal,
    CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('over', 'over_extra', 'overuren 1en2') THEN DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal)
                           ELSE 0
                      END)) / 60 AS O_aantal,
    CONVERT(NVARCHAR, CONVERT(DATETIME, '$flow.werkdatum$'), 105) AS datum
FROM    fv_engineer
    LEFT OUTER JOIN fv_declaratie d
        ON d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
           AND d.engineer_id = fv_engineer.id
    LEFT OUTER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
    LEFT OUTER JOIN fv_looncomponent lc
        ON lm.looncomponent_id = lc.id
WHERE   fv_engineer.id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> veldindicatie;
d -> aantal;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
d -> aantal;
fv_declaratie -> d;
d -> werkdt;
d -> engineer_id;
fv_engineer -> id;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr607()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sum(CASE WHEN COALESCE(message,'')='' and COALESCE(keurregistratie,'0')<>'0' THEN 0 else 1 END) as verstuurd from fv_declaratie where werkdt = Convert(datetime,'$flow.werkdatum$') and engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr608()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(sum(CASE WHEN lm.veldindicatie='vergoeding' THEN 1 else 0 END),0) as vergoeding from fv_engineer e left outer join fv_declaratie d on e.id = d.engineer_id inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id=lm.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and e.id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> veldindicatie;
fv_engineer -> e;
fv_declaratie -> d;
e -> id;
d -> engineer_id;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
e -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement208()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE  FROM fv_declaratie
WHERE   CONVERT(DATETIME, '$flow.werkdatum$') = werkdt
AND NOT activity_id IS NULL");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> werkdt;
fv_declaratie -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement209()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT  INTO fv_declaratie
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
SELECT  NEWID(),
lm.id,
CONVERT(DATETIME, '$flow.werkdatum$'),
DATEADD(mi,
SUM(DATEPART(hh, ld.uren) * 60 + DATEPART(mi, ld.uren)),
CONVERT(DATETIME, '$flow.werkdatum$')),
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
FROM    fv_labour l
INNER JOIN fv_labour_detail ld ON ld.labour_id = l.id
INNER JOIN fv_labour_type lt ON ld.labour_type_id = lt.id
INNER JOIN fv_looncomponent lc ON lt.external_id = lc.external_id
INNER JOIN fv_looncomponent_mapping lm ON lm.looncomponent_id = lc.id
AND lm.veldindicatie = 'normaal'
INNER JOIN fv_activity a ON l.activity_id = a.id
INNER JOIN fv_engineer e ON e.id = $app.userid$
LEFT OUTER JOIN fv_medewerker m ON l.medewerker_id = m.id
AND e.external_id = m.external_id             
WHERE   COALESCE(l.engineer_id,e.id) = $app.userid$ AND COALESCE(l.engineer_id,m.external_id) IS NOT NULL
AND ld.uren >= CONVERT(DATETIME, '$flow.werkdatum$')
AND ld.uren < DATEADD(dd, 1,
CONVERT(DATETIME, '$flow.werkdatum$'))
GROUP BY a.serviceordernumber,
ld.activity_id,
lm.id,
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
}
subgraph select {
lm -> id;
ld -> uren;
ld -> uren;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
a -> serviceordernumber;
fv_labour -> l;
fv_labour_detail -> ld;
ld -> labour_id;
l -> id;
fv_labour_type -> lt;
ld -> labour_type_id;
lt -> id;
fv_looncomponent -> lc;
lt -> external_id;
lc -> external_id;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
fv_activity -> a;
l -> activity_id;
a -> id;
fv_engineer -> e;
e -> id;
app -> userid;
fv_medewerker -> m;
l -> medewerker_id;
m -> id;
e -> external_id;
m -> external_id;
l -> engineer_id;
e -> id;
app -> userid;
l -> engineer_id;
m -> external_id;
ld -> uren;
ld -> uren;
a -> serviceordernumber;
ld -> activity_id;
lm -> id;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement210()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT  INTO fv_declaratie
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
SELECT  NEWID(),
lm.id,
CONVERT(DATETIME, '$flow.werkdatum$'),
DATEADD(mi,
SUM(DATEPART(hh, ld.uren) * 60 + DATEPART(mi, ld.uren)),
CONVERT(DATETIME, '$flow.werkdatum$')),
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
FROM    fv_labour l
INNER JOIN fv_labour_detail ld ON ld.labour_id = l.id
INNER JOIN fv_labour_type lt ON ld.labour_type_id = lt.id
INNER JOIN fv_looncomponent lc ON lt.external_id = lc.external_id
INNER JOIN fv_looncomponent_mapping lm ON lm.looncomponent_id = lc.id
AND lm.veldindicatie = 'reis binnen werktijd'
INNER JOIN fv_activity a ON l.activity_id = a.id
INNER JOIN fv_engineer e ON e.id = $app.userid$
LEFT OUTER JOIN fv_medewerker m ON l.medewerker_id = m.id
AND e.external_id = m.external_id             
WHERE   COALESCE(l.engineer_id,e.id) = $app.userid$ AND COALESCE(l.engineer_id,m.external_id) IS NOT NULL
AND ld.uren >= CONVERT(DATETIME, '$flow.werkdatum$')
AND ld.uren < DATEADD(dd, 1,
CONVERT(DATETIME, '$flow.werkdatum$'))
GROUP BY a.serviceordernumber,
ld.activity_id,
lm.id,
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
}
subgraph select {
lm -> id;
ld -> uren;
ld -> uren;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
a -> serviceordernumber;
fv_labour -> l;
fv_labour_detail -> ld;
ld -> labour_id;
l -> id;
fv_labour_type -> lt;
ld -> labour_type_id;
lt -> id;
fv_looncomponent -> lc;
lt -> external_id;
lc -> external_id;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
fv_activity -> a;
l -> activity_id;
a -> id;
fv_engineer -> e;
e -> id;
app -> userid;
fv_medewerker -> m;
l -> medewerker_id;
m -> id;
e -> external_id;
m -> external_id;
l -> engineer_id;
e -> id;
app -> userid;
l -> engineer_id;
m -> external_id;
ld -> uren;
ld -> uren;
a -> serviceordernumber;
ld -> activity_id;
lm -> id;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement211()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT  INTO fv_declaratie
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
SELECT  NEWID(),
lm.id,
CONVERT(DATETIME, '$flow.werkdatum$'),
DATEADD(mi,
SUM(DATEPART(hh, ld.uren) * 60 + DATEPART(mi, ld.uren)),
CONVERT(DATETIME, '$flow.werkdatum$')),
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
FROM    fv_labour l
INNER JOIN fv_labour_detail ld ON ld.labour_id = l.id
INNER JOIN fv_labour_type lt ON ld.labour_type_id = lt.id
INNER JOIN fv_looncomponent lc ON lt.external_id = lc.external_id
INNER JOIN fv_looncomponent_mapping lm ON lm.looncomponent_id = lc.id
AND lm.veldindicatie = 'reis'
INNER JOIN fv_activity a ON l.activity_id = a.id
INNER JOIN fv_engineer e ON e.id = $app.userid$
LEFT OUTER JOIN fv_medewerker m ON l.medewerker_id = m.id
AND e.external_id = m.external_id             
WHERE   COALESCE(l.engineer_id,e.id) = $app.userid$ AND COALESCE(l.engineer_id,m.external_id) IS NOT NULL
AND ld.uren >= CONVERT(DATETIME, '$flow.werkdatum$')
AND ld.uren < DATEADD(dd, 1,
CONVERT(DATETIME, '$flow.werkdatum$'))
GROUP BY a.serviceordernumber,
ld.activity_id,
lm.id,
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
}
subgraph select {
lm -> id;
ld -> uren;
ld -> uren;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
a -> serviceordernumber;
fv_labour -> l;
fv_labour_detail -> ld;
ld -> labour_id;
l -> id;
fv_labour_type -> lt;
ld -> labour_type_id;
lt -> id;
fv_looncomponent -> lc;
lt -> external_id;
lc -> external_id;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
fv_activity -> a;
l -> activity_id;
a -> id;
fv_engineer -> e;
e -> id;
app -> userid;
fv_medewerker -> m;
l -> medewerker_id;
m -> id;
e -> external_id;
m -> external_id;
l -> engineer_id;
e -> id;
app -> userid;
l -> engineer_id;
m -> external_id;
ld -> uren;
ld -> uren;
a -> serviceordernumber;
ld -> activity_id;
lm -> id;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement212()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT  INTO fv_declaratie
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
SELECT  NEWID(),
lm.id,
CONVERT(DATETIME, '$flow.werkdatum$'),
DATEADD(mi,
SUM(DATEPART(hh, ld.uren) * 60 + DATEPART(mi, ld.uren)),
CONVERT(DATETIME, '$flow.werkdatum$')),
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
FROM    fv_labour l
INNER JOIN fv_labour_detail ld ON ld.labour_id = l.id
INNER JOIN fv_labour_type lt ON ld.labour_type_id = lt.id
INNER JOIN fv_looncomponent lc ON lt.external_id = lc.external_id
INNER JOIN fv_looncomponent_mapping lm ON lm.looncomponent_id = lc.id
AND lm.veldindicatie = 'over'
INNER JOIN fv_activity a ON l.activity_id = a.id
INNER JOIN fv_engineer e ON e.id = $app.userid$
LEFT OUTER JOIN fv_medewerker m ON l.medewerker_id = m.id
AND e.external_id = m.external_id             
WHERE   COALESCE(l.engineer_id,e.id) = $app.userid$ AND COALESCE(l.engineer_id,m.external_id) IS NOT NULL
AND ld.uren >= CONVERT(DATETIME, '$flow.werkdatum$')
AND ld.uren < DATEADD(dd, 1,
CONVERT(DATETIME, '$flow.werkdatum$'))
GROUP BY a.serviceordernumber,
ld.activity_id,
lm.id,
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
}
subgraph select {
lm -> id;
ld -> uren;
ld -> uren;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
a -> serviceordernumber;
fv_labour -> l;
fv_labour_detail -> ld;
ld -> labour_id;
l -> id;
fv_labour_type -> lt;
ld -> labour_type_id;
lt -> id;
fv_looncomponent -> lc;
lt -> external_id;
lc -> external_id;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
fv_activity -> a;
l -> activity_id;
a -> id;
fv_engineer -> e;
e -> id;
app -> userid;
fv_medewerker -> m;
l -> medewerker_id;
m -> id;
e -> external_id;
m -> external_id;
l -> engineer_id;
e -> id;
app -> userid;
l -> engineer_id;
m -> external_id;
ld -> uren;
ld -> uren;
a -> serviceordernumber;
ld -> activity_id;
lm -> id;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement213()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT  INTO fv_declaratie
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
SELECT  NEWID(),
lm.id,
CONVERT(DATETIME, '$flow.werkdatum$'),
DATEADD(mi,
SUM(DATEPART(hh, ld.uren) * 60 + DATEPART(mi, ld.uren)),
CONVERT(DATETIME, '$flow.werkdatum$')),
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort,
a.serviceordernumber
FROM    fv_labour l
INNER JOIN fv_labour_detail ld ON ld.labour_id = l.id
INNER JOIN fv_labour_type lt ON ld.labour_type_id = lt.id
INNER JOIN fv_looncomponent lc ON lt.external_id = lc.external_id
INNER JOIN fv_looncomponent_mapping lm ON lm.looncomponent_id = lc.id
AND lm.veldindicatie = 'overuren 1en2'
INNER JOIN fv_activity a ON l.activity_id = a.id
INNER JOIN fv_engineer e ON e.id = $app.userid$
LEFT OUTER JOIN fv_medewerker m ON l.medewerker_id = m.id
AND e.external_id = m.external_id             
WHERE   COALESCE(l.engineer_id,e.id) = $app.userid$ AND COALESCE(l.engineer_id,m.external_id) IS NOT NULL
AND ld.uren >= CONVERT(DATETIME, '$flow.werkdatum$')
AND ld.uren < DATEADD(dd, 1,
CONVERT(DATETIME, '$flow.werkdatum$'))
GROUP BY a.serviceordernumber,
ld.activity_id,
lm.id,
COALESCE(l.engineer_id,e.id),
l.activity_id,
lc.prestatiesoort");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
}
subgraph select {
lm -> id;
ld -> uren;
ld -> uren;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
a -> serviceordernumber;
fv_labour -> l;
fv_labour_detail -> ld;
ld -> labour_id;
l -> id;
fv_labour_type -> lt;
ld -> labour_type_id;
lt -> id;
fv_looncomponent -> lc;
lt -> external_id;
lc -> external_id;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
fv_activity -> a;
l -> activity_id;
a -> id;
fv_engineer -> e;
e -> id;
app -> userid;
fv_medewerker -> m;
l -> medewerker_id;
m -> id;
e -> external_id;
m -> external_id;
l -> engineer_id;
e -> id;
app -> userid;
l -> engineer_id;
m -> external_id;
ld -> uren;
ld -> uren;
a -> serviceordernumber;
ld -> activity_id;
lm -> id;
l -> engineer_id;
e -> id;
l -> activity_id;
lc -> prestatiesoort;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement214Component3962()
        {
            var statement = MacroScope.Factory.CreateStatement(@"    SELECT    d.rubricering AS id,
        d.rubricering AS ordernr,
        CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('normaal', 'reis binnen werktijd') THEN DATEPART(hh, d.aantal)
                               ELSE 0
                          END) * 60 + SUM(CASE WHEN lm.veldindicatie IN ('normaal', 'reis binnen werktijd') THEN DATEPART(mi, d.aantal)
                                               ELSE 0
                                          END)) / 60 AS N_aantal,
        CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('reis') THEN DATEPART(hh, d.aantal)
                               ELSE 0
                          END) * 60 + SUM(CASE WHEN lm.veldindicatie IN ('reis') THEN DATEPART(mi, d.aantal)
                                               ELSE 0
                                          END)) / 60 AS R_aantal,
        CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('over', 'over_extra', 'overuren 1en2') THEN DATEPART(hh, d.aantal)
                               ELSE 0
                          END) * 60 + SUM(CASE WHEN lm.veldindicatie IN ('over', 'over_extra', 'overuren 1en2') THEN DATEPART(mi, d.aantal)
                                               ELSE 0
                                          END)) / 60 AS O_aantal,
        CASE WHEN SUM(CASE WHEN COALESCE(d.keurregistratie, '0') = '0'
                                AND COALESCE(d.message, '') <> '' THEN 1
                           ELSE 0
                      END) > 0 THEN '****'
             ELSE ''
        END AS err,
        'o' AS screen,
        2 AS sortorder,
        d.orderoms
    FROM    fv_declaratie d
        INNER JOIN fv_looncomponent_mapping lm
            ON d.looncomponent_mapping_id = lm.id
               AND lm.veldindicatie <> 'indirect'
               AND lm.veldindicatie <> 'vergoeding'
    WHERE    d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
        AND d.engineer_id = $app.userid$
        AND d.activity_id IS NULL
    GROUP BY
        d.rubricering,
        d.orderoms
UNION
    SELECT    CONVERT(NCHAR(36), d.activity_id) AS id,
        a.serviceordernumber AS ordernr,
        CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('normaal', 'reis binnen werktijd') THEN DATEPART(hh, d.aantal)
                               ELSE 0
                          END) * 60 + SUM(CASE WHEN lm.veldindicatie IN ('normaal', 'reis binnen werktijd') THEN DATEPART(mi, d.aantal)
                                               ELSE 0
                                          END)) / 60 AS N_aantal,
        CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('reis') THEN DATEPART(hh, d.aantal)
                               ELSE 0
                          END) * 60 + SUM(CASE WHEN lm.veldindicatie IN ('reis') THEN DATEPART(mi, d.aantal)
                                               ELSE 0
                                          END)) / 60 AS R_aantal,
        CONVERT(REAL, SUM(CASE WHEN lm.veldindicatie IN ('over', 'over_extra', 'overuren 1en2') THEN DATEPART(hh, d.aantal)
                               ELSE 0
                          END) * 60 + SUM(CASE WHEN lm.veldindicatie IN ('over', 'over_extra', 'overuren 1en2') THEN DATEPART(mi, d.aantal)
                                               ELSE 0
                                          END)) / 60 AS O_aantal,
        CASE WHEN SUM(CASE WHEN COALESCE(d.keurregistratie, '0') = '0' AND COALESCE(d.message, '') <> '' THEN 1
                           ELSE 0
                      END) > 0 THEN '****'
             ELSE ''
        END AS err,
        'd' AS screen,
        1 AS sortorder,
        '' AS orderoms
    FROM    fv_declaratie d
        INNER JOIN fv_looncomponent_mapping lm
            ON d.looncomponent_mapping_id = lm.id
        INNER JOIN fv_activity a
            ON d.activity_id = a.id
    WHERE    d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
        AND d.engineer_id = $app.userid$
    GROUP BY
        d.activity_id,
        a.serviceordernumber
UNION
    SELECT    CONVERT(NCHAR(36), d.id) AS id,
        l.description AS ordernr,
        CONVERT(REAL, DATEPART(hh, d.aantal) * 60 + DATEPART(mi, d.aantal)) / 60 AS N_aantal,
        0 AS R_aantal,
        0 AS O_aantal,
        CASE WHEN COALESCE(d.keurregistratie, '0') = '0' AND COALESCE(d.message, '') <> '' THEN '****'
             ELSE ''
        END AS err,
        'i' AS screen,
        3 AS sortorder,
        '' AS orderoms
    FROM    fv_declaratie d
        INNER JOIN fv_looncomponent_mapping lm
            ON d.looncomponent_mapping_id = lm.id
               AND lm.veldindicatie = 'indirect'
        INNER JOIN fv_looncomponent l
            ON lm.looncomponent_id = l.id
    WHERE    d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
        AND d.engineer_id = $app.userid$
    ORDER BY sortorder
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> rubricering;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
d -> keurregistratie;
d -> message;
d -> orderoms;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
lm -> veldindicatie;
lm -> veldindicatie;
d -> werkdt;
d -> engineer_id;
app -> userid;
d -> activity_id;
d -> rubricering;
d -> orderoms;
d -> activity_id;
a -> serviceordernumber;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
lm -> veldindicatie;
d -> aantal;
d -> keurregistratie;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
d -> activity_id;
a -> serviceordernumber;
d -> id;
l -> description;
d -> aantal;
d -> aantal;
d -> keurregistratie;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
lm -> veldindicatie;
fv_looncomponent -> l;
lm -> looncomponent_id;
l -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
fv_declaratie -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr578()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select Convert(nvarchar,Convert(datetime,'$flow.werkdatum$'),105) as datum, '0' as def from fv_engineer where id = $app.Userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> Userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement215Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'indirect' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement216()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, omschrijving) select newid(), $sub.cboLC$, Convert(datetime,'$flow.werkdatum$'), DATEADD(mi,$sub.lcMinuten$,DATEADD(hh,$sub.lcUren$,'$flow.werkdatum$'+'T00:00:00')),id, '$sub.txtOpm$' from fv_engineer where id = $app.userid$ and '$sub.lcUren$'+':'+'$sub.lcMinuten$'<>'0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> omschrijving;
}
subgraph select {
sub -> cboLC;
sub -> lcMinuten;
sub -> lcUren;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement217Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select l.description, Convert(real,datepart(hh,d.aantal)*60+datepart(mi,d.aantal))/60 as aantal from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent l on lm.looncomponent_id = l.id and lm.veldindicatie = 'indirect' where werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
l -> description;
d -> aantal;
d -> aantal;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> l;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
fv_declaratie -> werkdt;
d -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement218()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  SUM(CASE WHEN COALESCE(message, '') = ''
                      AND COALESCE(keurregistratie, '0') != '0' THEN 0
                 ELSE 1
            END) AS verstuurd
FROM    fv_declaratie
WHERE   werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
        AND engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr580()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select Convert(nvarchar,Convert(datetime,'$flow.werkdatum$'),105) as datum from fv_engineer where id = $app.Userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> Userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr581()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select looncomponent_mapping_id, aantal, omschrijving from fv_declaratie where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement219Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'indirect' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement220()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set looncomponent_mapping_id = $sub.cboLC$, aantal='$sub.tmUren$', omschrijving='$sub.txtOpm$' where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> looncomponent_mapping_id;
sub -> cboLC;
fv_declaratie -> aantal;
fv_declaratie -> omschrijving;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement221()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$flow.declaratie$' and SUBSTRING(Convert(nvarchar,aantal,108),1,5)='00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement222()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr584()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select Convert(nvarchar,Convert(datetime,'$flow.werkdatum$'),105) as datum from fv_engineer where id = $app.Userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> Userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr610()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select sum(CASE WHEN COALESCE(message,'')='' and COALESCE(keurregistratie,'0')<>'0' THEN 0 else 1 END) as verstuurd from fv_declaratie where convert(nvarchar,werkdt,105) = Convert(nvarchar,Convert(datetime,'$flow.werkdatum$'),105) and engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement223()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where werkdt = Convert(datetime,'$flow.werkdatum$') and looncomponent_mapping_id = $sub.grdVergoed.id$ and engineer_id=$app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> werkdt;
fv_declaratie -> looncomponent_mapping_id;
sub -> grdVergoed;
grdVergoed -> id;
fv_declaratie -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement224()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id) select newid(), $sub.grdVergoed.id$, Convert(datetime,'$flow.werkdatum$'), null, id from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
}
subgraph select {
sub -> grdVergoed;
grdVergoed -> id;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement225Component3351()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description, CASE WHEN d.id is null THEN '' ElSE 'V' END as selected from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id left outer join fv_declaratie d on d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.looncomponent_mapping_id = lm.id and d.engineer_id = $app.userid$ where lm.veldindicatie = 'vergoeding' and lm.isactive=1 and l.isactive=1
order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
d -> id;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
fv_declaratie -> d;
d -> werkdt;
d -> looncomponent_mapping_id;
lm -> id;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement226()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  SUM(CASE WHEN COALESCE(message, '') = ''
                      AND COALESCE(keurregistratie, '0') != '0' THEN 0
                 ELSE 1
            END) AS verstuurd
FROM    fv_declaratie
WHERE   werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
        AND engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr585()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT Convert(nvarchar,Convert(datetime,'$flow.werkdatum$'),105) as datum, serviceordernumber as ordernr, description
FROM fv_activity
WHERE id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr586()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT a.serviceordernumber AS ordernr, d.aantal, d.id, d.omschrijving
FROM fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm ON d.looncomponent_mapping_id = lm.id
    INNER JOIN fv_activity a ON d.activity_id = a.id
WHERE d.werkdt = Convert(datetime, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND lm.veldindicatie = 'normaal'
    AND d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
a -> serviceordernumber;
d -> aantal;
d -> id;
d -> omschrijving;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr587()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select a.serviceordernumber as ordernr, a.description, d.aantal, d.looncomponent_mapping_id, d.id, d.ReisurenTvT
from fv_declaratie d
    inner join fv_looncomponent_mapping lm
        on d.looncomponent_mapping_id = lm.id
    inner join fv_activity a
        on d.activity_id = a.id
where d.werkdt = Convert(datetime, '$flow.werkdatum$')
    and d.engineer_id = $app.userid$
    and lm.veldindicatie = 'reis'
    and d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
a -> serviceordernumber;
a -> description;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
d -> ReisurenTvT;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr588()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    a.serviceordernumber as ordernr,
    a.description,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id
FROM    fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
    INNER JOIN fv_activity a
        ON d.activity_id = a.id
WHERE    d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND lm.veldindicatie = 'overuren 1en2'
    AND d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
a -> serviceordernumber;
a -> description;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr589()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    a.serviceordernumber as ordernr,
    a.description,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id,
    d.overurentvt,

    d.consignatie
FROM    fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
    INNER JOIN fv_activity a
        ON d.activity_id = a.id
WHERE    d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND lm.veldindicatie = 'over'
    AND d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
a -> serviceordernumber;
a -> description;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
d -> overurentvt;
d -> consignatie;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr709()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT a.serviceordernumber AS ordernr, d.aantal, d.id, d.omschrijving
FROM fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm ON d.looncomponent_mapping_id = lm.id
    INNER JOIN fv_activity a ON d.activity_id = a.id
WHERE d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND lm.veldindicatie = 'reis binnen werktijd'
    AND d.activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
a -> serviceordernumber;
d -> aantal;
d -> id;
d -> omschrijving;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement227Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    lm.id,
    l.description
FROM    fv_looncomponent l
    INNER JOIN fv_looncomponent_mapping lm
        ON lm.looncomponent_id = l.id
WHERE    lm.veldindicatie = 'reis'
    AND lm.isactive = 1
    AND l.isactive = 1
ORDER BY lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement228Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    lm.id,
    l.description
FROM    fv_looncomponent l
    INNER JOIN fv_looncomponent_mapping lm
        ON lm.looncomponent_id = l.id
WHERE    lm.veldindicatie = 'over'
    AND lm.isactive = 1
    AND l.isactive = 1
ORDER BY lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement229()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving)

SELECT NEWID(), lm.id, CONVERT(DATETIME, '$flow.werkdatum$'), '$sub.tmUren$', $app.userid$, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$'

FROM fv_looncomponent_mapping lm

    INNER JOIN fv_looncomponent lc

        ON lm.looncomponent_id = lc.id

            AND lm.veldindicatie = 'normaal'

            AND SUBSTRING('$sub.tmUren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement230()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie SET aantal = '$sub.tmUren$', omschrijving = '$sub.txtOpm$' WHERE id = '$sub.txtDeclIDN$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> aantal;
fv_declaratie -> omschrijving;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement231()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_declaratie WHERE id = '$sub.txtDeclIDN$' AND SUBSTRING(CONVERT(NVARCHAR, aantal, 108), 1, 5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement232()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving, ReisurenTvT)

SELECT NEWID(), lm.id, CONVERT(DATETIME, '$flow.werkdatum$'), '$sub.tmReisUren$', $app.userid$, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', CASE WHEN '$sub.chkReisUren$' = 'true' THEN 1 ELSE 0 END

FROM fv_looncomponent_mapping lm

    INNER JOIN fv_looncomponent lc

        ON lm.looncomponent_id = lc.id

            AND lm.veldindicatie = 'reis binnen werktijd'

            AND SUBSTRING('$sub.tmReisUren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> ReisurenTvT;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement233()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie SET aantal = '$sub.tmReisUren$', omschrijving = '$sub.txtOpm$', ReisurenTvT = CASE WHEN '$sub.chkReisUren$' = 'true' THEN 1 ELSE 0 END WHERE id = '$sub.txtDeclIDNR$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> aantal;
fv_declaratie -> omschrijving;
fv_declaratie -> ReisurenTvT;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement234()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_declaratie WHERE id = '$sub.txtDeclIDNR$' AND SUBSTRING(CONVERT(NVARCHAR, aantal, 108), 1, 5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement235()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving, ReisurenTvT)

SELECT NEWID(), lm.id, CONVERT(DATETIME, '$flow.werkdatum$'), '$sub.tmOverigUren$', $app.userid$, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', CASE WHEN '$sub.chkReisUren$' = 'true' THEN 1 ELSE 0 END

FROM fv_looncomponent_mapping lm

    INNER JOIN fv_looncomponent lc

        ON lm.looncomponent_id = lc.id

            AND lm.id = CASE '$sub.cboLCR$' WHEN '' THEN NULL WHEN 'null' THEN NULL ELSE '$sub.cboLCR$' END

            AND SUBSTRING('$sub.tmOverigUren$',12,5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> ReisurenTvT;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement236()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie

SET looncomponent_mapping_id = CASE '$sub.cboLCR$' WHEN '' THEN NULL WHEN 'null' THEN NULL ELSE '$sub.cboLCR$' END,

    aantal = '$sub.tmOverigUren$',

    omschrijving = '$sub.txtOpm$',

    ReisurenTvT = CASE WHEN '$sub.chkReisUren$' = 'true' THEN 1 ELSE 0 END

WHERE id = '$sub.txtDeclIDR$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> aantal;
fv_declaratie -> omschrijving;
fv_declaratie -> ReisurenTvT;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement237()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_declaratie WHERE id = '$sub.txtDeclIDR$' AND ((SUBSTRING(CONVERT(NVARCHAR, aantal, 108), 1, 5) = '00:00') OR (looncomponent_mapping_id IS NULL))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
fv_declaratie -> looncomponent_mapping_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement238()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving, overurentvt, consignatie)

SELECT NEWID(), lm.id, CONVERT(DATETIME, '$flow.werkdatum$'), '$sub.tmOverUren$', $app.userid$, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', CASE WHEN '$sub.chkOverUren$' = 'true' THEN 1 ELSE 0 END, CASE WHEN '$sub.chkConsignatie$' = 'true' THEN 1 ELSE 0 END

FROM fv_looncomponent_mapping lm

    INNER JOIN fv_looncomponent lc

        ON lm.looncomponent_id = lc.id

            AND lm.veldindicatie = 'overuren 1en2'

            AND SUBSTRING('$sub.tmOverUren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> overurentvt;
fv_declaratie -> consignatie;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement239()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie

SET aantal = '$sub.tmOverUren$',

    omschrijving = '$sub.txtOpm$',

    overurentvt = CASE WHEN '$sub.chkOverUren$' = 'true' THEN 1 ELSE 0 END,

    consignatie = CASE WHEN '$sub.chkConsignatie$' = 'true' THEN 1 ELSE 0 END

WHERE id = '$sub.txtDeclIDO$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> aantal;
fv_declaratie -> omschrijving;
fv_declaratie -> overurentvt;
fv_declaratie -> consignatie;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement240()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_declaratie WHERE id = '$sub.txtDeclIDO$' AND SUBSTRING(CONVERT(NVARCHAR, aantal, 108), 1, 5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement241()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, activity_id, prestatiesoort, rubricering, omschrijving, overurentvt, consignatie)

SELECT NEWID(), lm.id,  Convert(datetime,'$flow.werkdatum$'),  '$sub.tmOverExtraUren$', $app.userid$, '$flow.declaratie$', lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', CASE WHEN '$sub.chkOverUren$' = 'true' THEN 1 ELSE 0 END, CASE WHEN '$sub.chkConsignatie$' = 'true' THEN 1 ELSE 0 END

FROM fv_looncomponent_mapping lm

    INNER JOIN fv_looncomponent lc

        ON lm.looncomponent_id = lc.id

            AND lm.id = CASE '$sub.cboLCOE$' WHEN '' THEN NULL WHEN 'null' THEN NULL ELSE '$sub.cboLCOE$' END

            AND SUBSTRING('$sub.tmOverExtraUren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> activity_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> overurentvt;
fv_declaratie -> consignatie;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement242()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie

SET    looncomponent_mapping_id = CASE '$sub.cboLCOE$' WHEN '' THEN NULL WHEN 'null' THEN NULL ELSE '$sub.cboLCOE$' END,

    aantal = '$sub.tmOverExtraUren$',

    omschrijving = '$sub.txtOpm$',

    overurentvt = CASE WHEN '$sub.chkOverUren$' = 'true' THEN 1 ELSE 0 END,

    consignatie = CASE WHEN '$sub.chkConsignatie$' = 'true' THEN 1 ELSE 0 END

WHERE    id = '$sub.txtDeclIDOE$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> aantal;
fv_declaratie -> omschrijving;
fv_declaratie -> overurentvt;
fv_declaratie -> consignatie;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement243()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtDeclIDOE$' and ((SUBSTRING(Convert(nvarchar,aantal,108),1,5)='00:00') OR (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
fv_declaratie -> looncomponent_mapping_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement244()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where werkdt = Convert(datetime,'$flow.werkdatum$') and engineer_id = $app.userid$ and activity_id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
fv_declaratie -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr590()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    CONVERT(nvarchar, Convert(datetime,'$flow.werkdatum$'), 105) as datum,
    '$flow.declaratie_change$' as ordernr,
    '$flow.orderoms$' as orderoms
FROM    fv_engineer
WHERE    id = $app.Userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> Userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr591()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT d.rubricering AS ordernr,
    '' AS description,
    d.aantal,
    d.id,
    d.omschrijving
FROM
    fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
WHERE    d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND lm.veldindicatie = 'normaal'
    AND d.activity_id IS NULL
    AND d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> id;
d -> omschrijving;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr592()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr, '' as description, d.aantal,d.looncomponent_mapping_id, d.id
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'reis' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr593()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr, '' as description, d.aantal,d.looncomponent_mapping_id, d.id
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'over' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr594()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select d.rubricering as ordernr, '' as description, d.aantal,d.looncomponent_mapping_id, d.id
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'over_extra' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement245Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'reis' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement246Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'over' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement247Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lm.id, l.description from fv_looncomponent l inner join fv_looncomponent_mapping lm on lm.looncomponent_id = l.id where lm.veldindicatie = 'over_extra' and lm.isactive=1  and l.isactive=1  order by lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement248()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms) select  newid(),  lm.id,  Convert(datetime,'$flow.werkdatum$'),  '$sub.tmUren$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', '$sub.txtDesc$' from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.veldindicatie = 'normaal' and SUBSTRING('$sub.tmUren$',12,5)<>'00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement249()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set aantal='$sub.tmUren$', rubricering='$sub.txtOrdrnr$', omschrijving = '$sub.txtOpm$', orderoms='$sub.txtDesc$' where id = '$sub.txtDeclIDN$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> aantal;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement250()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtDeclIDN$' and SUBSTRING(Convert(nvarchar,aantal,108),1,5)='00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement251()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms) select  newid(),  lm.id,  Convert(datetime,'$flow.werkdatum$'),  '$sub.tmUrenR$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', '$sub.txtDesc$' from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.id = CASE '$sub.cboLCR$' WHEN '' THEN null WHEN 'null' THEN null else '$sub.cboLCR$' END and SUBSTRING('$sub.tmUrenR$',12,5)<>'00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement252()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set looncomponent_mapping_id = CASE '$sub.cboLCR$' WHEN '' THEN null WHEN 'null' THEN null else '$sub.cboLCR$' END, aantal='$sub.tmUrenR$', rubricering='$sub.txtOrdrnr$', omschrijving = '$sub.txtOpm$', orderoms='$sub.txtDesc$' where id = '$sub.txtDeclIDR$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> aantal;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement253()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtDeclIDR$' and ((SUBSTRING(Convert(nvarchar,aantal,108),1,5)='00:00') OR (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
fv_declaratie -> looncomponent_mapping_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement254()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms) select  newid(),  lm.id,  Convert(datetime,'$flow.werkdatum$'),  '$sub.tmUrenO$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', '$sub.txtDesc$' from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.id = CASE '$sub.cboLCO$' WHEN '' THEN null WHEN 'null' THEN null else '$sub.cboLCO$' END and SUBSTRING('$sub.tmUrenO$',12,5)<>'00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement255()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set looncomponent_mapping_id = CASE '$sub.cboLCO$' WHEN '' THEN null WHEN 'null' THEN null else '$sub.cboLCO$' END, aantal='$sub.tmUrenO$', rubricering='$sub.txtOrdrnr$', omschrijving = '$sub.txtOpm$', orderoms='$sub.txtDesc$' where id = '$sub.txtDeclIDO$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> aantal;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement256()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtDeclIDO$' and ((SUBSTRING(Convert(nvarchar,aantal,108),1,5)='00:00') OR (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
fv_declaratie -> looncomponent_mapping_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement257()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms) select  newid(),  lm.id,  Convert(datetime,'$flow.werkdatum$'),  '$sub.tmUrenOE$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', '$sub.txtDesc$' from fv_looncomponent_mapping lm inner join fv_looncomponent lc on lm.looncomponent_id = lc.id and lm.id = CASE '$sub.cboLCOE$' WHEN '' THEN null WHEN 'null' THEN null else '$sub.cboLCOE$' END and SUBSTRING('$sub.tmUrenOE$',12,5)<>'00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement258()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set looncomponent_mapping_id = CASE '$sub.cboLCOE$' WHEN '' THEN null WHEN 'null' THEN null else '$sub.cboLCOE$' END, aantal='$sub.tmUrenOE$', rubricering='$sub.txtOrdrnr$', omschrijving = '$sub.txtOpm$', orderoms='$sub.txtDesc$' where id = '$sub.txtDeclIDOE$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> aantal;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement259()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtDeclIDOE$' and ((SUBSTRING(Convert(nvarchar,aantal,108),1,5)='00:00') OR (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
fv_declaratie -> looncomponent_mapping_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement260()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where werkdt = Convert(datetime,'$flow.werkdatum$') and engineer_id = $app.userid$ and rubricering = '$flow.declaratie$' and activity_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
fv_declaratie -> rubricering;
fv_declaratie -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr597()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select message from fv_declaratie where id = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr598()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'normale uren' as type, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'normaal' and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr599()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie IN ('reis', 'reis binnen werktijd') and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lc -> description;
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr600()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'overuren 1en2' and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lc -> description;
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr601()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'over' and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lc -> description;
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr710()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id inner join fv_activity a on d.activity_id = a.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie IN ('reis binnen werktijd') and d.activity_id = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lc -> description;
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr602()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'normale uren' as type, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'normaal' and d.activity_id is null and d.rubricering = '$flow.declaratie$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr603()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'reis' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lc -> description;
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr604()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'over' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lc -> description;
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr605()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select lc.description, d.aantal, d.message
from fv_declaratie d inner join fv_looncomponent_mapping lm on d.looncomponent_mapping_id = lm.id inner join fv_looncomponent lc on lm.looncomponent_id=lc.id where d.werkdt = Convert(datetime,'$flow.werkdatum$') and d.engineer_id = $app.userid$ and lm.veldindicatie = 'overuren 1en2' and d.activity_id is null and d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lc -> description;
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr717()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    lc.description,
    d.aantal,
    d.message
FROM    fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
    INNER JOIN fv_looncomponent lc
        ON lm.looncomponent_id = lc.id
    INNER JOIN fv_activity a
        ON d.activity_id = a.id
WHERE    d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND lm.veldindicatie IN ('reis binnen werktijd')
    AND d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lc -> description;
d -> aantal;
d -> message;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
fv_activity -> a;
d -> activity_id;
a -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement261()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_declaratie (id, rubricering, omschrijving, engineer_id, radiostatus_id, isactive) select newid(), '$sub.txtOrd$', '$sub.txtOms$', id, 0, 1 from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> engineer_id;
fv_declaratie -> radiostatus_id;
fv_declaratie -> isactive;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement262()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_declaratie set radiostatus_id=0, isactive=0 where id = '$sub.grdOrd.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> radiostatus_id;
fv_declaratie -> isactive;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement263Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, rubricering, omschrijving from fv_declaratie where werkdt is null and engineer_id = $app.userid$ and isactive=1 order by rubricering");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
fv_declaratie -> isactive;
fv_declaratie -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr609()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr611()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select DATEPART(hh,CASE WHEN datediff(hh,startdt,verholpendt)>23 THEN '1900-01-01T00:00:00' ELSE '1900-01-01T' + CASE WHEN LEN(convert(nvarchar,(CASE WHEN datediff(mi,startdt,verholpendt)<0 THEN 0 ELSE (datediff(mi,startdt,verholpendt) + CASE WHEN datediff(mi,startdt,verholpendt)%15 > 0 THEN 15 ELSE 0 END) /60 END )))=1 THEN '0' ELSE '' END + convert(nvarchar,(CASE WHEN datediff(mi,startdt,verholpendt)<0 THEN 0 ELSE (datediff(mi,startdt,verholpendt) + CASE WHEN datediff(mi,startdt,verholpendt)%15 > 0 THEN 15 ELSE 0 END) /60 END)) + 
':' + CASE WHEN (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=0 THEN '00' WHEN (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=15 THEN '15' WHEN  (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=30 THEN '30' WHEN  (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=45 THEN '45' ELSE '00' END + ':00' END) as uren, DATEPART(mi,CASE WHEN datediff(hh,startdt,verholpendt)>23 THEN '1900-01-01T00:00:00' ELSE '1900-01-01T' + CASE WHEN LEN(convert(nvarchar,(CASE WHEN datediff(mi,startdt,verholpendt)<0 THEN 0 ELSE (datediff(mi,startdt,verholpendt) + CASE WHEN datediff(mi,startdt,verholpendt)%15 > 0 THEN 15 ELSE 0 END) /60 END )))=1 THEN '0' ELSE '' END + convert(nvarchar,(CASE WHEN datediff(mi,startdt,verholpendt)<0 THEN 0 ELSE (datediff(mi,startdt,verholpendt) + CASE WHEN datediff(mi,startdt,verholpendt)%15 > 0 THEN 15 ELSE 0 END) /60 END)) + 
':' + CASE WHEN (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=0 THEN '00' WHEN (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=15 THEN '15' WHEN  (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=30 THEN '30' WHEN  (datediff(mi,startdt,verholpendt) - (datediff(mi,startdt,verholpendt)/60)*60)<=45 THEN '45' ELSE '00' END + ':00' END) as minuten, 0 as def from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr613()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$form.txtLabID$','$flow.activity_id$',1,-1,DATEADD(mi,$form.lcMinuten1$,DATEADD(hh,$form.lcUren1$,SUBSTRING(Convert(nvarchar,getdate(),20),1,10)+'T00:00:00')) from fv_engineer where id = $app.userid$ and '$form.lcUren1$'+':'+'$form.lcMinuten1$'<>'0:0'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
form -> lcMinuten1;
form -> lcUren1;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr614()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$form.txtLabID$','$flow.activity_id$',2,-1,DATEADD(mi,$form.lcMinuten2$,DATEADD(hh,$form.lcUren2$,SUBSTRING(Convert(nvarchar,getdate(),20),1,10)+'T00:00:00')) from fv_engineer where id = $app.userid$ and '$form.lcUren2$'+':'+'$form.lcMinuten2$'<>'0:0'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
form -> lcMinuten2;
form -> lcUren2;
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr615()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$form.txtLabID$','$flow.activity_id$',id,-1,DATEADD(mi,$form.lcMinuten3$,DATEADD(hh,$form.lcUren3$,SUBSTRING(Convert(nvarchar,getdate(),20),1,10)+'T00:00:00')) from fv_labour_type where id = $form.cb3$ and '$form.lcUren3$'+':'+'$form.lcMinuten3$'<>'0:0'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
form -> lcMinuten3;
form -> lcUren3;
fv_labour_type -> id;
form -> cb3;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr616()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id,rostartdt,coalesce(roenddt,getdate()) as nu from fv_labour where activity_id = '$flow.activity_id$' and enddt is null and labourstatus_id=2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr617()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE WHEN LEN(convert(nvarchar,SUM(datepart(hh,uren)) + (SUM(datepart(mi,uren))/60)))=1 THEN '0' ELSE '' END + CONVERT(nvarchar,SUM(datepart(hh,uren)) + (SUM(datepart(mi,uren))/60)) + ':' + CASE WHEN LEN(convert(nvarchar,(SUM(datepart(mi,uren))%60)))=1 THEN '0' ELSE '' END + convert(nvarchar,(SUM(datepart(mi,uren))%60)) as total FROM         fv_labour_detail INNER JOIN fv_labour ON fv_labour_detail.labour_id = fv_labour.id
WHERE     fv_labour.activity_id = '$flow.activity_id$' and not fv_labour.enddt is null and fv_labour.engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> labour_id;
fv_labour -> id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> engineer_id;
app -> userid;
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr671()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id from fv_labour_type where external_id = '0708' and not exists (select uren from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.activity_id = '$flow.activity_id$' and enddt is null and labourstatus_id=2)
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_type -> external_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> activity_id;
fv_labour -> enddt;
fv_labour -> labourstatus_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement264Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_labour_type where isactive=1 and id > 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_type -> isactive;
fv_labour_type -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement265()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bezorgadres (id,street,name,name_2,zip,city,engineer_id,radiostatus_id,isactive ) select newid(), '$sub.txtStraat$', '$sub.txtNaam$', '$sub.txtNaam2$', '$sub.txtZip$', '$sub.txtPlaats$', id, 0, 1 from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bezorgadres -> id;
fv_tmp_bezorgadres -> street;
fv_tmp_bezorgadres -> name;
fv_tmp_bezorgadres -> name_2;
fv_tmp_bezorgadres -> zip;
fv_tmp_bezorgadres -> city;
fv_tmp_bezorgadres -> engineer_id;
fv_tmp_bezorgadres -> radiostatus_id;
fv_tmp_bezorgadres -> isactive;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement266()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bezorgadres set radiostatus_id=0, isactive=0 where id = '$flow.del_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bezorgadres -> radiostatus_id;
fv_tmp_bezorgadres -> isactive;
fv_tmp_bezorgadres -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement267Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, name, name_2, street, city, zip from fv_tmp_bezorgadres where (engineer_id = $app.userid$ or engineer_id is null) and isactive=1 order by name");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_bezorgadres -> engineer_id;
app -> userid;
fv_tmp_bezorgadres -> engineer_id;
fv_tmp_bezorgadres -> isactive;
fv_tmp_bezorgadres -> name;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement268()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_tmp_bestelling set naam='$flow.naam3$',naam2='$flow.naam2$',straat='$flow.h_adres$',plaats='$flow.plaats$',postcode='$flow.postcode$',land='NL'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_tmp_bestelling -> naam;
fv_tmp_bestelling -> naam2;
fv_tmp_bestelling -> straat;
fv_tmp_bestelling -> plaats;
fv_tmp_bestelling -> postcode;
fv_tmp_bestelling -> land;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement269Component3539()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    id,
    eng,
    datum,
    DATEADD(mi, SUM(normaal_min), DATEADD(HH, SUM(normaal_uur), '1900-01-01T00:00:00')) AS normaal,
    DATEADD(mi, SUM(over_min), DATEADD(HH, SUM(over_uur), '1900-01-01T00:00:00')) AS over_uur,
    DATEADD(mi, SUM(reis_min), DATEADD(HH, SUM(reis_uur), '1900-01-01T00:00:00')) AS reis
FROM (
    SELECT
        fv_labour.id,
        fv_medewerker.description AS eng,
        fv_labour.rostartdt AS datum,
        CASE WHEN fv_labour_detail.labour_type_id IN (1) THEN SUM(DATEPART(HH, fv_labour_detail.uren)) ELSE 0 END AS normaal_uur,
        CASE WHEN fv_labour_detail.labour_type_id IN (1) THEN SUM(DATEPART(mi, fv_labour_detail.uren)) ELSE 0 END AS normaal_min,
        CASE WHEN fv_labour_detail.labour_type_id IN (3, 4, 5) THEN SUM(DATEPART(HH, fv_labour_detail.uren)) ELSE 0 END AS over_uur,
        CASE WHEN fv_labour_detail.labour_type_id IN (3, 4, 5) THEN SUM(DATEPART(mi, fv_labour_detail.uren)) ELSE 0 END AS over_min,
        CASE WHEN fv_labour_detail.labour_type_id IN (2, 10) THEN SUM(DATEPART(HH, fv_labour_detail.uren)) ELSE 0 END AS reis_uur,
        CASE WHEN fv_labour_detail.labour_type_id IN (2, 10) THEN SUM(DATEPART(mi, fv_labour_detail.uren)) ELSE 0 END AS reis_min
    FROM
        fv_labour
        INNER JOIN fv_medewerker
            ON fv_labour.medewerker_id = fv_medewerker.id
        LEFT OUTER JOIN fv_labour_detail
            ON fv_labour.id = fv_labour_detail.labour_id
    WHERE    fv_labour.activity_id = '$flow.activity_id$'
    GROUP BY
        fv_labour.id,
        fv_labour.rostartdt,
        fv_medewerker.description,
        fv_labour_detail.labour_type_id
    ) a
GROUP BY a.id, a.eng, a.datum");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> id;
fv_medewerker -> description;
fv_labour -> rostartdt;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour -> medewerker_id;
fv_medewerker -> id;
fv_labour -> id;
fv_labour_detail -> labour_id;
fv_labour -> activity_id;
fv_labour -> id;
fv_labour -> rostartdt;
fv_medewerker -> description;
fv_labour_detail -> labour_type_id;
a;
a -> id;
a -> eng;
a -> datum;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement270()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour (id, startdt, rostartdt, enddt, roenddt, radiostatus_id, activity_id, labourstatus_id) SELECT  '$flow.lab$', getdate(), getdate() , getdate(), getdate() ,  3, '$flow.activity_id$', 2 FROM fv_engineer WHERE fv_engineer.id = '$app.UserId$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour -> id;
fv_labour -> startdt;
fv_labour -> rostartdt;
fv_labour -> enddt;
fv_labour -> roenddt;
fv_labour -> radiostatus_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
}
subgraph select {
fv_engineer -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement271()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail where labour_id = '$sub.grdUren.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour_detail -> labour_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement272()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour where id = '$sub.grdUren.id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement273Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    id,
    eng,
    datum,
    DATEADD(mi, SUM(normaal_min), DATEADD(HH, SUM(normaal_uur), '1900-01-01T00:00:00')) AS normaal,
    DATEADD(mi, SUM(over_min), DATEADD(HH, SUM(over_uur), '1900-01-01T00:00:00')) AS over_uur,
    DATEADD(mi, SUM(reis_min), DATEADD(HH, SUM(reis_uur), '1900-01-01T00:00:00')) AS reis
FROM (
    SELECT
        fv_labour.id,
        COALESCE(fv_medewerker.description, fv_engineer.username) AS eng,
        fv_labour.rostartdt AS datum,
        CASE WHEN fv_labour_detail.labour_type_id IN (1) THEN SUM(DATEPART(HH, fv_labour_detail.uren)) ELSE 0 END AS normaal_uur,
        CASE WHEN fv_labour_detail.labour_type_id IN (1) THEN SUM(DATEPART(mi, fv_labour_detail.uren)) ELSE 0 END AS normaal_min,
        CASE WHEN fv_labour_detail.labour_type_id IN (3, 4, 5) THEN SUM(DATEPART(HH, fv_labour_detail.uren)) ELSE 0 END AS over_uur,
        CASE WHEN fv_labour_detail.labour_type_id IN (3, 4, 5) THEN SUM(DATEPART(mi, fv_labour_detail.uren)) ELSE 0 END AS over_min,
        CASE WHEN fv_labour_detail.labour_type_id IN (2, 10) THEN SUM(DATEPART(HH, fv_labour_detail.uren)) ELSE 0 END AS reis_uur,
        CASE WHEN fv_labour_detail.labour_type_id IN (2, 10) THEN SUM(DATEPART(mi, fv_labour_detail.uren)) ELSE 0 END AS reis_min
    FROM
        fv_labour
        LEFT OUTER JOIN fv_medewerker
            ON fv_labour.medewerker_id = fv_medewerker.id
        LEFT OUTER JOIN fv_engineer
            ON fv_labour.engineer_id = fv_engineer.id
        LEFT OUTER JOIN fv_labour_detail
            ON fv_labour.id = fv_labour_detail.labour_id
    WHERE
        fv_labour.activity_id IN (SELECT a.id FROM fv_activity a INNER JOIN fv_activity b ON a.serviceorder_id = b.serviceorder_id WHERE b.id = '$flow.activity_id$')
    GROUP BY
        fv_labour.id,
        fv_labour.rostartdt,
        COALESCE(fv_medewerker.description, fv_engineer.username),
        fv_labour_detail.labour_type_id
    ) a
GROUP BY a.id, a.eng, a.datum
HAVING SUM(normaal_min) > 0
      OR SUM(normaal_uur) > 0
      OR SUM(over_min) > 0
      OR SUM(over_uur) > 0
      OR SUM(reis_min) > 0
      OR SUM(reis_uur) > 0
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> id;
fv_medewerker -> description;
fv_engineer -> username;
fv_labour -> rostartdt;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> uren;
fv_labour -> medewerker_id;
fv_medewerker -> id;
fv_labour -> engineer_id;
fv_engineer -> id;
fv_labour -> id;
fv_labour_detail -> labour_id;
fv_labour -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> serviceorder_id;
b -> serviceorder_id;
b -> id;
}
fv_labour -> id;
fv_labour -> rostartdt;
fv_medewerker -> description;
fv_engineer -> username;
fv_labour_detail -> labour_type_id;
a;
a -> id;
a -> eng;
a -> datum;
 -> normaal_min;
 -> normaal_uur;
 -> over_min;
 -> over_uur;
 -> reis_min;
 -> reis_uur;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr636()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when ld.uren is null then '1900-01-01T00:00:00' else ld.uren end as werk, DATEPART(hh,CASE when ld.uren is null then '1900-01-01T00:00:00' else ld.uren end) as uren, DATEPART(mi,CASE when ld.uren is null then '1900-01-01T00:00:00' else ld.uren end) as minuten from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id = 1 where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
ld -> uren;
ld -> uren;
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr637()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ld.labour_type_id as id from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'
UNION
(select id from fv_labour_type where external_id = '0708' and not exists (select uren from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'))
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> labour_type_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
fv_labour_type -> external_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr641()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$flow.lab$' as id, fv_medewerker.description, fv_labour.rostartdt from fv_labour inner join fv_medewerker on fv_labour.medewerker_id = fv_medewerker.id where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_medewerker -> description;
fv_labour -> rostartdt;
fv_labour -> medewerker_id;
fv_medewerker -> id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr643()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END AS uren
FROM fv_labour
    LEFT OUTER JOIN fv_labour_detail ld
        ON ld.labour_id = fv_labour.id
            AND ld.labour_type_id = 10
WHERE fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr644()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END AS uren,
    ld.labour_type_id
FROM fv_labour
    LEFT OUTER JOIN fv_labour_detail ld
        ON ld.labour_id = fv_labour.id
            AND NOT ld.labour_type_id IN (1, 2, 3, 10)
WHERE fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
ld -> labour_type_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr707()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END AS uren
FROM fv_labour
    LEFT OUTER JOIN fv_labour_detail ld
        ON ld.labour_id = fv_labour.id
            AND ld.labour_type_id = 2
WHERE fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr708()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE WHEN ld.uren IS NULL THEN '1900-01-01T00:00:00' ELSE ld.uren END AS uren
FROM fv_labour
    LEFT OUTER JOIN fv_labour_detail ld
        ON ld.labour_id = fv_labour.id
            AND ld.labour_type_id = 3
WHERE fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement274Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT id, description
FROM    fv_labour_type
WHERE    isactive = 1
    AND NOT id IN (1, 2, 3, 10)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_type -> isactive;
fv_labour_type -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement275()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_labour SET rostartdt = '$sub.dtLabour$', roenddt = '$sub.dtLabour$' WHERE id = '$sub.txtLabID$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour -> rostartdt;
fv_labour -> roenddt;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement276()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_labour_detail WHERE labour_id = '$sub.txtLabID$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour_detail -> labour_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement277()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$sub.txtLabID$', '$flow.activity_id$', 1, -1, '$flow.dttm1$'
FROM fv_engineer
WHERE id = $app.userid$
    AND SUBSTRING('$sub.tm1$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement278()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$sub.txtLabID$', '$flow.activity_id$', 2, -1, '$flow.dttm2$'
FROM fv_engineer
WHERE id = $app.userid$
    AND SUBSTRING('$sub.tm2$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement279()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$sub.txtLabID$', '$flow.activity_id$', 10, -1, '$flow.dttm10$'
FROM fv_engineer
WHERE id = $app.userid$
    AND SUBSTRING('$sub.tm10$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement280()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$sub.txtLabID$', '$flow.activity_id$', 3, -1, '$flow.dttm3$'
FROM fv_engineer
WHERE id = $app.userid$
    AND SUBSTRING('$sub.tm3$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement281()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_labour_detail (id, labour_id, activity_id, labour_type_id, radiostatus_id, uren)
SELECT NEWID(), '$sub.txtLabID$', '$flow.activity_id$', '$sub.cb4$', -1, '$flow.dttm4$'
FROM fv_engineer
WHERE id = $app.userid$
    AND SUBSTRING('$sub.tm4$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr645()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select signature from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement282()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief SET signature = '$sub.signature$' WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> signature;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement283()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CASE WHEN LEN(CONVERT(NVARCHAR(5), SIGNATURE)) > 3 THEN 1
             ELSE CASE WHEN COALESCE(fv_activity.ishandtekeningverplicht, 0) != 1
                       THEN 1
                       ELSE 0
                  END
        END AS IsProceedButtonEnabled
FROM    fv_debrief
        INNER JOIN fv_activity ON fv_debrief.activity_id = fv_activity.id
WHERE   fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> ishandtekeningverplicht;
fv_debrief -> activity_id;
fv_activity -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr646()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when ld.uren is null then '1900-01-01T00:00:00' else ld.uren end as werk from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id = 1 where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr647()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select ld.labour_type_id as id from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'
UNION
(select id from fv_labour_type where external_id = '0708' and not exists (select uren from fv_labour inner join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'))
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> labour_type_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
fv_labour_type -> external_id;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr649()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$flow.lab$' as id, rostartdt from fv_labour where id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr650()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when ld.uren is null then '1900-01-01T00:00:00' else ld.uren end as uren from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id = 2 where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr651()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when ld.uren is null then '1900-01-01T00:00:00' else ld.uren end as uren from fv_labour left outer join fv_labour_detail ld on ld.labour_id = fv_labour.id and ld.labour_type_id not in (1,2) where fv_labour.id = '$flow.lab$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ld -> uren;
ld -> uren;
fv_labour_detail -> ld;
ld -> labour_id;
fv_labour -> id;
ld -> labour_type_id;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement284Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, description from fv_labour_type where isactive=1 and id > 2");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_type -> isactive;
fv_labour_type -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement285()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_labour set rostartdt = '$sub.dtLabour$', roenddt='$sub.dtLabour$' where id = '$sub.txtLabID$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_labour -> rostartdt;
fv_labour -> roenddt;
fv_labour -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement286()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_labour_detail where labour_id = '$sub.txtLabID$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour_detail -> labour_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement287()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$sub.txtLabID$','$flow.activity_id$',1,-1,SUBSTRING('$sub.dtLabour$',1,11) + SUBSTRING('$sub.tm1$',12,8) from fv_engineer where id = $app.userid$ and SUBSTRING('$sub.tm1$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement288()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$sub.txtLabID$','$flow.activity_id$',2,-1,SUBSTRING('$sub.dtLabour$',1,11) + SUBSTRING('$sub.tm2$',12,8) from fv_engineer where id = $app.userid$ and SUBSTRING('$sub.tm2$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement289()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour_detail (id,labour_id,activity_id,labour_type_id,radiostatus_id,uren) select newid(),'$sub.txtLabID$','$flow.activity_id$',id,-1,SUBSTRING('$sub.dtLabour$',1,11) + SUBSTRING('$sub.tm3$',12,8) from fv_labour_type where id = $sub.cb3$ and SUBSTRING('$sub.tm3$',12,8)<>'00:00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour_detail -> id;
fv_labour_detail -> labour_id;
fv_labour_detail -> activity_id;
fv_labour_detail -> labour_type_id;
fv_labour_detail -> radiostatus_id;
fv_labour_detail -> uren;
}
subgraph select {
fv_labour_type -> id;
sub -> cb3;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr679()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'true' as def from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement290Component3594()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT DISTINCT fv_customer.id,
    fv_customer.external_id,
    fv_customer.customername AS oms,
    fv_customer.customer_main_id,
    fv_customer_main.name,
    fv_customer_main.name2
FROM    fv_customer
    INNER JOIN fv_customer_main
        ON fv_customer.customer_main_id = fv_customer_main.id
    LEFT OUTER JOIN fv_serviceobject
        ON fv_customer.id = fv_serviceobject.customer_id
WHERE    LEN(fv_customer.external_id) = CASE WHEN '$sub.chMain$' = 'true' THEN 8 ELSE LEN(fv_customer.external_id) END
    AND fv_customer.isactive = 1
    AND fv_customer.external_id LIKE '$sub.txtFP$%'
    AND fv_customer.customername LIKE '%$sub.txtName$%'
    AND fv_serviceobject.description LIKE '$sub.txtEquipZoek$%'
    AND '$flow.zoek$' = '1'
ORDER BY fv_customer.external_id");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer -> id;
fv_customer -> external_id;
fv_customer -> customername;
fv_customer -> customer_main_id;
fv_customer_main -> name;
fv_customer_main -> name2;
fv_customer -> customer_main_id;
fv_customer_main -> id;
fv_customer -> id;
fv_serviceobject -> customer_id;
fv_customer -> external_id;
fv_customer -> external_id;
fv_customer -> isactive;
fv_customer -> external_id;
fv_customer -> customername;
fv_serviceobject -> description;
fv_customer -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement291()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set activitytype_id= $form.lcbType$ where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitytype_id;
form -> lcbType;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement292()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set capability_id= CASE WHEN '$form.cbArtikelGroep$'='' THEN null ELSE '$form.cbArtikelGroep$' END, productgroep_id= CASE WHEN '$form.cbProductgroep$'='' THEN null ELSE '$form.cbProductgroep$' END where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> capability_id;
fv_activity -> productgroep_id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement293()
        {
            var statement = MacroScope.Factory.CreateStatement(@"update fv_activity set customer_main_id=$sub.grdFP3.klant$, customer_id = $sub.grdFP3.id$, functieplaatsnaam = '$sub.grdFP3.name$', description = '$form.txtDescNW$', opdrachtnummer = '$form.txtOpdrnr$', name='$sub.grdFP3.klantname$', name_2='$sub.grdFP3.klantname2$' where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> customer_main_id;
sub -> grdFP3;
grdFP3 -> klant;
fv_activity -> customer_id;
sub -> grdFP3;
grdFP3 -> id;
fv_activity -> functieplaatsnaam;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr660()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select SUBSTRING('$flow.SB$',1,8) + '.docx' as SB, '$flow.SB$' as FP  from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr677()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(fv_customer.notes, cm.notes) AS responsetijd,
        COALESCE(fv_customer.responsetoelichting, cm.responsetoelichting) AS responsetoelichting,
        COALESCE(fv_customer_addition.klantcontacten,
                 parentCustomer.klantcontacten,
                 parentParentCustomer.klantcontacten) AS klantcontacten,
        COALESCE(fv_customer_addition.internecontacten,
                 parentCustomer.internecontacten,
                 parentParentCustomer.internecontacten) AS internecontacten,
        COALESCE(fv_customer_addition.onderaannemers,
                 parentCustomer.onderaannemers,
                 parentParentCustomer.onderaannemers) AS onderaannemers
FROM    fv_customer
        LEFT OUTER JOIN fv_customer cm ON cm.external_id = SUBSTRING(fv_customer.external_id, 1, 8)
        LEFT OUTER JOIN fv_customer_addition ON fv_customer.id = fv_customer_addition.customer_id
        LEFT OUTER JOIN fv_customer_addition parentCustomer ON parentCustomer.customer_id = fv_customer.parent_customer_id
        LEFT OUTER JOIN fv_customer_addition parentParentCustomer ON parentParentCustomer.customer_id IN ( SELECT   cp.parent_customer_id
                                                                                                           FROM     fv_customer cp
                                                                                                           WHERE    cp.id = fv_customer.parent_customer_id )
WHERE   fv_customer.external_id = '$flow.SB$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer -> notes;
cm -> notes;
fv_customer -> responsetoelichting;
cm -> responsetoelichting;
fv_customer_addition -> klantcontacten;
parentCustomer -> klantcontacten;
parentParentCustomer -> klantcontacten;
fv_customer_addition -> internecontacten;
parentCustomer -> internecontacten;
parentParentCustomer -> internecontacten;
fv_customer_addition -> onderaannemers;
parentCustomer -> onderaannemers;
parentParentCustomer -> onderaannemers;
fv_customer -> cm;
cm -> external_id;
fv_customer -> external_id;
fv_customer -> id;
fv_customer_addition -> customer_id;
fv_customer_addition -> parentCustomer;
parentCustomer -> customer_id;
fv_customer -> parent_customer_id;
fv_customer_addition -> parentParentCustomer;
parentParentCustomer -> customer_id;
cp -> parent_customer_id;
fv_customer -> cp;
cp -> id;
fv_customer -> parent_customer_id;
}
fv_customer -> external_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement294()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement295()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_bestellingregel");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement296()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestelling (id,sonummer,straat,naam,naam2,huisnummer,postcode,plaats,land) select '$flow.bestel_id$','$form.txtSO$',street,name,name_2,housenumber,zip,city,'NL' from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bestelling -> id;
fv_tmp_bestelling -> sonummer;
fv_tmp_bestelling -> straat;
fv_tmp_bestelling -> naam;
fv_tmp_bestelling -> naam2;
fv_tmp_bestelling -> huisnummer;
fv_tmp_bestelling -> postcode;
fv_tmp_bestelling -> plaats;
fv_tmp_bestelling -> land;
}
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr670()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select '$sub.grdZoekLev4.totaal$' as totaal from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement297Component3661()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select id, external_id, description, external_id + '
' + description + '
' + Coalesce(straat,'') + ' ' + Coalesce(huisnummer,'') + '
' + COALESCE(postcode,'') + ' ' + COALESCE(plaats,'') + '
tel: ' + coalesce(telefoon,'') + '
fax: ' + coalesce(fax,'') as totaal from fv_supplier where isactive = 1 and description like '%'+'$sub.txtZoek$' + '%' and $flow.zoek$=1

");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_supplier -> isactive;
fv_supplier -> description;
flow -> zoek;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement298()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_activity where planstartdt < DATEADD(dd,-1,getdate()) and activitytype_Id in (select id from fv_activitytype where billable=0)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_activity -> planstartdt;
fv_activity -> activitytype_Id;
subgraph select {
fv_activitytype -> id;
fv_activitytype -> billable;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement299()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_labour where NOT activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour -> activity_id;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement300()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_labour_detail where NOT activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_labour_detail -> activity_id;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement301()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_activitystatus where NOT activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_activitystatus -> activity_id;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement302()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_debrief where NOT activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_debrief -> activity_id;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement303()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_debriefoperations where NOT activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_debriefoperations -> activity_id;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement304()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_materialmutation where NOT activity_id in (select id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_materialmutation -> activity_id;
subgraph select {
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement305()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_customer_addition where NOT customer_id in (select customer_id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_customer_addition -> customer_id;
subgraph select {
fv_activity -> customer_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr678()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT '$flow.SBdet$' AS opm FROM fv_engineer WHERE id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr684()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT       'Ordernr: ' + COALESCE(fv_activity.serviceordernumber,'') + '
' + 'Werkbon: ' + COALESCE(convert(nvarchar,fv_activity.sub_id),'') + '
' + 'Datum: ' + CONVERT(nvarchar,getdate(),105) + '

' + 'Omschrijving: 
' + COALESCE (fv_activity.description, '') AS samenvatting
FROM         fv_activity
where fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> sub_id;
fv_activity -> description;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr685()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT      fv_debrief.notes
FROM         fv_debrief 
where fv_debrief.activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> notes;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr737()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  ds.rostatusdt AS enddt
FROM fv_activity a
LEFT OUTER JOIN  fv_debrief_status ds ON ds.external_id = a.external_id AND ds.sub_id = a.sub_id
AND ds.activitystatustype_id IN (59, 150, 157)
WHERE a.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ds -> rostatusdt;
fv_activity -> a;
fv_debrief_status -> ds;
ds -> external_id;
a -> external_id;
ds -> sub_id;
a -> sub_id;
ds -> activitystatustype_id;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr686()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select extra_notes from fv_debrief where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr687()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT       'Ordernr: ' + COALESCE(fv_activity.serviceordernumber,'') + '
' + 'Werkbon: ' + COALESCE(convert(nvarchar,fv_activity.sub_id),'') + '
' + 'Datum: ' + CONVERT(nvarchar,getdate(),105) + '

' + 'Omschrijving: 
' + COALESCE (fv_activity.description, '') AS samenvatting
FROM         fv_activity
where fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> sub_id;
fv_activity -> description;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr688()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT      fv_debrief.notes
FROM         fv_debrief 
where fv_debrief.activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> notes;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr689()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr690()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_activitystatus where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_activitystatus -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr691()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_serviceorder where id not in (select serviceorder_id from fv_activity)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_serviceorder -> id;
subgraph select {
fv_activity -> serviceorder_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr692()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select serviceordernumber, sub_id from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr694()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  a.notes,
        a.description,
        a.samenvatting
FROM    fv_activity a
WHERE   a.id = '$flow.activity_id$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
a -> notes;
a -> description;
a -> samenvatting;
fv_activity -> a;
a -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr695()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    COALESCE(bestel_autorisatie,0) as bestel_autorisatie,
    COALESCE(ontvangst_autorisatie,0) as ontvangst_autorisatie
FROM    fv_engineer
WHERE    id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement306()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_orderrequest");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement307()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_tmp_orderrequest");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement308()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement309()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr696()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    GETDATE() AS nu,
    DATEADD(minute, 1, GETDATE()) AS morgen,
    '1900-01-01 08:00' AS acht_uur,
    '0' AS def,
    NEWID() AS new_act_id,
    CONVERT(NVARCHAR(4000),fv_debrief.notes)
FROM    fv_debrief
WHERE    fv_debrief.activity_id = '$flow.activity_id$'
UNION
SELECT    GETDATE() AS nu,
    DATEADD(minute, 1, GETDATE()) AS morgen,
    '1900-01-01 08:00' AS acht_uur,
    '0' AS def,
    NEWID() AS new_act_id,
    NULL
FROM fv_engineer
WHERE id=$app.userid$ AND NOT EXISTS(SELECT * FROM    fv_debrief
WHERE    fv_debrief.activity_id = '$flow.activity_id$')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> notes;
fv_debrief -> activity_id;
fv_engineer -> id;
app -> userid;
fv_debrief -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement310Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    fv_cancelreason.id,
    fv_cancelreason.description
FROM    fv_cancelreason
WHERE    fv_cancelreason.isactive = 1
ORDER BY fv_cancelreason.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_cancelreason -> id;
fv_cancelreason -> description;
fv_cancelreason -> isactive;
fv_cancelreason -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement311()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief 
SET restduur=($sub.txtUren$*60)+$sub.lcMinuten$,
send_email = null
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> restduur;
sub -> txtUren;
sub -> lcMinuten;
fv_debrief -> send_email;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement312()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -4, '$flow.NewStatusdt$'), 0, 150, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement313()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -3, '$flow.NewStatusdt$'), 0, 120, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement314()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET    activitystatustype_id = 120,
    maxstatusdt = DATEADD(second, -3, '$flow.NewStatusdt$')
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitystatustype_id;
fv_activity -> maxstatusdt;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement315()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, herpland_door_naam, nlsfb_id)
SELECT    '$flow.NewActivity_id$', '$flow.NewStatusdt$', 152, external_id, sub_id, engineer_id, '$flow.datum$',
    DATEADD(minute, DATEDIFF(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, $flow.tijd$, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    CASE WHEN LEN('$flow.opmerking2$') > 999 THEN SUBSTRING('$flow.opmerking2$', 0, 999) ELSE '$flow.opmerking2$' END, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, '$app.username$', nlsfb_id
FROM    fv_activity
WHERE    id = '$flow.activity_id$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activity -> id;
fv_activity -> maxstatusdt;
fv_activity -> activitystatustype_id;
fv_activity -> external_id;
fv_activity -> sub_id;
fv_activity -> engineer_id;
fv_activity -> planstartdt;
fv_activity -> planenddt;
fv_activity -> capability_id;
fv_activity -> causecode_id;
fv_activity -> changedt;
fv_activity -> city;
fv_activity -> zip;
fv_activity -> street;
fv_activity -> housenumber;
fv_activity -> housenumbertext;
fv_activity -> community;
fv_activity -> contact;
fv_activity -> contact_id;
fv_activity -> contract_id;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_activity -> country;
fv_activity -> criteriumstartdt;
fv_activity -> criteriumenddt;
fv_activity -> customer_id;
fv_activity -> customer_main_id;
fv_activity -> customerexternal_id;
fv_activity -> description;
fv_activity -> email;
fv_activity -> equipmentname;
fv_activity -> fax;
fv_activity -> functieplaatsnaam;
fv_activity -> historie_tekst;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_activity -> meldkamernummer;
fv_activity -> ministoringsboek;
fv_activity -> mobilephone;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> normtijd;
fv_activity -> opdrachtnummer;
fv_activity -> ordersoort_id;
fv_activity -> organisation_id;
fv_activity -> phone;
fv_activity -> serviceorder_id;
fv_activity -> aangemaakt_door_naam;
fv_activity -> activitytype_id;
fv_activity -> planner_id;
fv_activity -> planner_name;
fv_activity -> priority_id;
fv_activity -> problemcode_id;
fv_activity -> productgroep_id;
fv_activity -> region_id;
fv_activity -> seen_by_eng;
fv_activity -> serviceobject_id;
fv_activity -> serviceordernumber;
fv_activity -> solutioncode_id;
fv_activity -> state;
fv_activity -> taken;
fv_activity -> verantwoordelijk;
fv_activity -> samenvatting;
fv_activity -> notes;
fv_activity -> onderwerp;
fv_activity -> isafmeldbonvoorklantverplicht;
fv_activity -> isantidaterentoegestaan;
fv_activity -> isequipmentscannenverplicht;
fv_activity -> ishandtekeningverplicht;
fv_activity -> isnlsfbcodeverplicht;
fv_activity -> isurenspecificatieverplicht;
fv_activity -> herpland_door_naam;
fv_activity -> nlsfb_id;
fv_activity -> external_id;
fv_activity -> sub_id;
fv_activity -> engineer_id;
fv_activity -> planstartdt;
fv_activity -> planenddt;
fv_activity -> capability_id;
fv_activity -> causecode_id;
fv_activity -> changedt;
fv_activity -> city;
fv_activity -> zip;
fv_activity -> street;
fv_activity -> housenumber;
fv_activity -> housenumbertext;
fv_activity -> community;
fv_activity -> contact;
fv_activity -> contact_id;
fv_activity -> contract_id;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_activity -> country;
fv_activity -> criteriumstartdt;
fv_activity -> criteriumenddt;
fv_activity -> customer_id;
fv_activity -> customer_main_id;
fv_activity -> customerexternal_id;
fv_activity -> description;
fv_activity -> email;
fv_activity -> equipmentname;
fv_activity -> fax;
fv_activity -> functieplaatsnaam;
fv_activity -> historie_tekst;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_activity -> meldkamernummer;
fv_activity -> ministoringsboek;
fv_activity -> mobilephone;
fv_activity -> name;
fv_activity -> name_2;
flow -> tijd;
fv_activity -> opdrachtnummer;
fv_activity -> ordersoort_id;
fv_activity -> organisation_id;
fv_activity -> phone;
fv_activity -> serviceorder_id;
fv_activity -> aangemaakt_door_naam;
fv_activity -> activitytype_id;
fv_activity -> planner_id;
fv_activity -> planner_name;
fv_activity -> priority_id;
fv_activity -> problemcode_id;
fv_activity -> productgroep_id;
fv_activity -> region_id;
fv_activity -> seen_by_eng;
fv_activity -> serviceobject_id;
fv_activity -> serviceordernumber;
fv_activity -> solutioncode_id;
fv_activity -> state;
fv_activity -> taken;
fv_activity -> verantwoordelijk;
fv_activity -> samenvatting;
fv_activity -> onderwerp;
fv_activity -> isafmeldbonvoorklantverplicht;
fv_activity -> isantidaterentoegestaan;
fv_activity -> isequipmentscannenverplicht;
fv_activity -> ishandtekeningverplicht;
fv_activity -> isnlsfbcodeverplicht;
fv_activity -> isurenspecificatieverplicht;
fv_activity -> nlsfb_id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement316()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -2, '$flow.NewStatusdt$'), 0, 30, '$flow.NewActivity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement317()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
SELECT    NEWID(), $app.userid$, '$flow.NewStatusdt$', 0, 152, '$flow.NewActivity_id$', '$flow.opmerking$',
    CASE WHEN '$flow.reden$'='' THEN null ELSE '$flow.reden$' END
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
fv_activitystatus -> cancelnotes;
fv_activitystatus -> cancelreason_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement318()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief_photo (id, activity_id, description, filename, radiostatus_id, isactive, path)
SELECT NEWID(), '$flow.NewActivity_id$', description, filename, 2, isactive, path FROM fv_debrief_photo WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief_photo -> id;
fv_debrief_photo -> activity_id;
fv_debrief_photo -> description;
fv_debrief_photo -> filename;
fv_debrief_photo -> radiostatus_id;
fv_debrief_photo -> isactive;
fv_debrief_photo -> path;
}
subgraph select {
fv_debrief_photo -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement319()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_emaillist SET activity_id = '$flow.NewActivity_id$' WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_emaillist -> activity_id;
fv_emaillist -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr701()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select 'true' as def, customer_main_id from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement320Component3976()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    fv_customer.id,
    fv_customer.external_id,
    COALESCE(fv_customer.customername + '
', '') + COALESCE(fv_customer.street, '') + ' ' + COALESCE(fv_customer.city, '') AS opm,
    fv_customer.customer_main_id,
    fv_customer_main.name,
    fv_customer_main.name2,
    fv_customer.customername AS oms
FROM fv_customer
    INNER JOIN fv_customer_main
        ON fv_customer.customer_main_id=fv_customer_main.id
WHERE    LEN(fv_customer.external_id) = CASE WHEN '$sub.chMain$'='true' THEN 8 ELSE LEN(fv_customer.external_id) END
    AND fv_customer.isactive=1
    AND fv_customer.external_id LIKE '$sub.txtFP$'+'%'
    AND fv_customer.customername LIKE '%$sub.txtName$%'
    AND fv_customer.city LIKE '$sub.txtCity$'+'%'
    AND fv_customer.street LIKE '$sub.txtStreet$'+'%'
    AND '$flow.zoek$'='1'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_customer -> id;
fv_customer -> external_id;
fv_customer -> customername;
fv_customer -> street;
fv_customer -> city;
fv_customer -> customer_main_id;
fv_customer_main -> name;
fv_customer_main -> name2;
fv_customer -> customername;
fv_customer -> customer_main_id;
fv_customer_main -> id;
fv_customer -> external_id;
fv_customer -> external_id;
fv_customer -> isactive;
fv_customer -> external_id;
fv_customer -> customername;
fv_customer -> city;
fv_customer -> street;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement321()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET    activitytype_id = $form.lcbType$,
--activitytype_id = CASE WHEN '$form.cbType$'='' THEN null ELSE  '$form.cbType$' END,
    capability_id = CASE WHEN '$form.cbArtikelGroep$'='' THEN null ELSE '$form.cbArtikelGroep$' END,
    productgroep_id = CASE WHEN '$form.cbProductgroep$'='' THEN null ELSE '$form.cbProductgroep$' END,
    customer_main_id = $sub.grdFP2.klant$,
    customer_id = $sub.grdFP2.id$,
    functieplaatsnaam = '$sub.grdFP2.name$',
    description = '$form.txtDescNW$',
    opdrachtnummer = '$form.txtOpdrnr$',
    name='$sub.grdFP2.klantname$',
    name_2='$sub.grdFP2.klantname2$'
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitytype_id;
form -> lcbType;
fv_activity -> capability_id;
fv_activity -> productgroep_id;
fv_activity -> customer_main_id;
sub -> grdFP2;
grdFP2 -> klant;
fv_activity -> customer_id;
sub -> grdFP2;
grdFP2 -> id;
fv_activity -> functieplaatsnaam;
fv_activity -> description;
fv_activity -> opdrachtnummer;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement322()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CASE WHEN opdrachtnummer IS NULL THEN 1
             ELSE 0
        END AS IsOpdrachtNummerLeeg
FROM    fv_activity
WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr702()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(fv_debrief.signaturedt, getdate()) AS nu, fv_debrief.signature, 1 AS def, fv_debrief.opdrachtnummer, fv_debrief.name_signature, COALESCE(fv_debrief.email, fv_contact.email) AS email, fv_debrief.send_specificatie
FROM fv_activity
INNER JOIN fv_debrief ON fv_activity.id = fv_debrief.activity_id
LEFT OUTER JOIN fv_contact ON fv_activity.contact_id = fv_contact.id
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> signaturedt;
fv_debrief -> signature;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> email;
fv_contact -> email;
fv_debrief -> send_specificatie;
fv_activity -> id;
fv_debrief -> activity_id;
fv_activity -> contact_id;
fv_contact -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement323()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE fv_debrief
SET    email = '$form.txtEmail$'
    ,send_email = 1
    ,send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END
    ,opdrachtnummer = '$form.txtOpdrachtnr$'
    ,name_signature = '$form.txtParaafNaam$'
    ,signaturedt = SUBSTRING('$form.datSig$',1,11) + SUBSTRING('$form.timeSig$',12,8)
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> signaturedt;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement324()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE fv_debrief
SET    email = '$form.txtEmail$'
    ,send_email = 1
    ,send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END
    ,opdrachtnummer = '$form.txtOpdrachtnr$'
    ,name_signature = '$form.txtParaafNaam$'
    ,signaturedt = SUBSTRING('$form.datSig$',1,11) + SUBSTRING('$form.timeSig$',12,8)
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> signaturedt;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement325()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -4, '$flow.NewStatusdt$'), 0, 150, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement326()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -3, '$flow.NewStatusdt$'), 0, 120, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement327()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET    activitystatustype_id = 120,
    maxstatusdt = DATEADD(second, -3, '$flow.NewStatusdt$')
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitystatustype_id;
fv_activity -> maxstatusdt;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement328()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id)
SELECT    '$flow.NewActivity_id$', '$flow.NewStatusdt$', 152, external_id, sub_id, engineer_id, '$flow.datum$',
    DATEADD(minute, DATEDIFF(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, $flow.tijd$, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    CASE WHEN LEN('$flow.opmerking2$') > 999 THEN SUBSTRING('$flow.opmerking2$', 0, 999) ELSE '$flow.opmerking2$' END, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id
FROM    fv_activity
WHERE    id = '$flow.activity_id$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activity -> id;
fv_activity -> maxstatusdt;
fv_activity -> activitystatustype_id;
fv_activity -> external_id;
fv_activity -> sub_id;
fv_activity -> engineer_id;
fv_activity -> planstartdt;
fv_activity -> planenddt;
fv_activity -> capability_id;
fv_activity -> causecode_id;
fv_activity -> changedt;
fv_activity -> city;
fv_activity -> zip;
fv_activity -> street;
fv_activity -> housenumber;
fv_activity -> housenumbertext;
fv_activity -> community;
fv_activity -> contact;
fv_activity -> contact_id;
fv_activity -> contract_id;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_activity -> country;
fv_activity -> criteriumstartdt;
fv_activity -> criteriumenddt;
fv_activity -> customer_id;
fv_activity -> customer_main_id;
fv_activity -> customerexternal_id;
fv_activity -> description;
fv_activity -> email;
fv_activity -> equipmentname;
fv_activity -> fax;
fv_activity -> functieplaatsnaam;
fv_activity -> historie_tekst;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_activity -> meldkamernummer;
fv_activity -> ministoringsboek;
fv_activity -> mobilephone;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> normtijd;
fv_activity -> opdrachtnummer;
fv_activity -> ordersoort_id;
fv_activity -> organisation_id;
fv_activity -> phone;
fv_activity -> serviceorder_id;
fv_activity -> aangemaakt_door_naam;
fv_activity -> activitytype_id;
fv_activity -> planner_id;
fv_activity -> planner_name;
fv_activity -> priority_id;
fv_activity -> problemcode_id;
fv_activity -> productgroep_id;
fv_activity -> region_id;
fv_activity -> seen_by_eng;
fv_activity -> serviceobject_id;
fv_activity -> serviceordernumber;
fv_activity -> solutioncode_id;
fv_activity -> state;
fv_activity -> taken;
fv_activity -> verantwoordelijk;
fv_activity -> samenvatting;
fv_activity -> notes;
fv_activity -> onderwerp;
fv_activity -> isafmeldbonvoorklantverplicht;
fv_activity -> isantidaterentoegestaan;
fv_activity -> isequipmentscannenverplicht;
fv_activity -> ishandtekeningverplicht;
fv_activity -> isnlsfbcodeverplicht;
fv_activity -> isurenspecificatieverplicht;
fv_activity -> nlsfb_id;
}
subgraph select {
flow -> tijd;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement329()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -2, '$flow.NewStatusdt$'), 0, 30, '$flow.NewActivity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement330()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
SELECT    NEWID(), $app.userid$, '$flow.NewStatusdt$', 0, 152, '$flow.NewActivity_id$', '$flow.opmerking$',
    CASE WHEN '$flow.reden$'='' THEN null ELSE '$flow.reden$' END
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
fv_activitystatus -> cancelnotes;
fv_activitystatus -> cancelreason_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement331()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  SUM(CASE WHEN COALESCE(message, '') = ''
                      AND COALESCE(keurregistratie, '0') != '0' THEN 0
                 ELSE 1
            END) AS verstuurd
FROM    fv_declaratie
WHERE   werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
        AND engineer_id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr711()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    CONVERT(NVARCHAR, CONVERT(DATETIME, '$flow.werkdatum$'), 105) AS datum,
    '$flow.declaratie_change$' AS ordernr,
    '$flow.orderoms$' AS description
FROM    fv_engineer
WHERE    id = $app.Userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> Userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr712()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT d.rubricering AS ordernr,
    d.aantal,
    d.id,
    d.omschrijving
FROM    fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
WHERE    d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND lm.veldindicatie = 'normaal'
    AND d.activity_id IS NULL
    AND d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> id;
d -> omschrijving;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
lm -> veldindicatie;
d -> activity_id;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr713()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT d.rubricering AS ordernr,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id,
    d.ReisurenTvT
FROM fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
WHERE d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND d.activity_id IS NULL
    AND lm.veldindicatie = 'reis'
    AND d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
d -> ReisurenTvT;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
d -> activity_id;
lm -> veldindicatie;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr714()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT d.rubricering AS ordernr,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id
FROM fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
WHERE d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND d.activity_id IS NULL
    AND lm.veldindicatie = 'overuren 1en2'
    AND d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
d -> activity_id;
lm -> veldindicatie;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr715()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT d.rubricering AS ordernr,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id,
    d.overurentvt,

    d.consignatie
FROM fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
WHERE d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND d.activity_id IS NULL
    AND lm.veldindicatie = 'over'
    AND d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
d -> overurentvt;
d -> consignatie;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
d -> activity_id;
lm -> veldindicatie;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr716()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT d.rubricering AS ordernr,
    d.aantal,
    d.looncomponent_mapping_id,
    d.id
FROM fv_declaratie d
    INNER JOIN fv_looncomponent_mapping lm
        ON d.looncomponent_mapping_id = lm.id
WHERE d.werkdt = CONVERT(DATETIME, '$flow.werkdatum$')
    AND d.engineer_id = $app.userid$
    AND d.activity_id IS NULL
    AND lm.veldindicatie = 'reis binnen werktijd'
    AND d.rubricering = '$flow.declaratie$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
d -> rubricering;
d -> aantal;
d -> looncomponent_mapping_id;
d -> id;
fv_declaratie -> d;
fv_looncomponent_mapping -> lm;
d -> looncomponent_mapping_id;
lm -> id;
d -> werkdt;
d -> engineer_id;
app -> userid;
d -> activity_id;
lm -> veldindicatie;
d -> rubricering;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement332Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    lm.id,
    l.description
FROM    fv_looncomponent l
    INNER JOIN fv_looncomponent_mapping lm
        ON lm.looncomponent_id = l.id
WHERE    lm.veldindicatie = 'reis'
    AND lm.isactive = 1
    AND l.isactive = 1
ORDER BY lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement333Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    lm.id,
    l.description
FROM    fv_looncomponent l
    INNER JOIN fv_looncomponent_mapping lm
        ON lm.looncomponent_id = l.id
WHERE    lm.veldindicatie = 'over'
    AND lm.isactive = 1
    AND l.isactive = 1
ORDER BY lm.sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
lm -> id;
l -> description;
fv_looncomponent -> l;
fv_looncomponent_mapping -> lm;
lm -> looncomponent_id;
l -> id;
lm -> veldindicatie;
lm -> isactive;
l -> isactive;
lm -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement334()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT  INTO fv_declaratie ( id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms )
SELECT  NEWID(), lm.id, CONVERT(DATETIME, '$flow.werkdatum$'), '$sub.tmUren$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', '$sub.txtDesc$'
FROM    fv_looncomponent_mapping lm
    INNER JOIN fv_looncomponent lc 
        ON lm.looncomponent_id = lc.id
        AND lm.veldindicatie = 'normaal'
        AND SUBSTRING('$sub.tmUren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement335()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie SET aantal = '$sub.tmUren$', rubricering='$sub.txtOrdrnr$', omschrijving = '$sub.txtOpm$', orderoms = '$sub.txtDesc$' WHERE id = '$sub.txtDeclIDN$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> aantal;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement336()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_declaratie WHERE id = '$sub.txtDeclIDN$' AND SUBSTRING(CONVERT(NVARCHAR,aantal,108),1,5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement337()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT  INTO fv_declaratie (   id,   looncomponent_mapping_id,   werkdt,   aantal,   engineer_id,   prestatiesoort,   rubricering,   omschrijving,   orderoms )
SELECT  NEWID(), lm.id, CONVERT(DATETIME, '$flow.werkdatum$'), '$sub.tmReisUren$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', '$sub.txtDesc$'         
FROM    fv_looncomponent_mapping lm
    INNER JOIN fv_looncomponent lc 
        ON lm.looncomponent_id = lc.id
        AND lm.veldindicatie = 'reis binnen werktijd'
        AND SUBSTRING('$sub.tmReisUren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement338()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie SET aantal = '$sub.tmReisUren$', rubricering='$sub.txtOrdrnr$', omschrijving = '$sub.txtOpm$', orderoms='$sub.txtDesc$' WHERE id = '$sub.txtDeclIDNR$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> aantal;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement339()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_declaratie WHERE id = '$sub.txtDeclIDNR$' AND SUBSTRING(CONVERT(NVARCHAR,aantal,108),1,5) = '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement340()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT  INTO fv_declaratie ( id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms, ReisurenTvT )
SELECT  NEWID(), lm.id, CONVERT(DATETIME, '$flow.werkdatum$'), '$sub.tmOverigeUren$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', '$sub.txtDesc$', CASE WHEN '$sub.chkReisUren$' = 'true' THEN 1 ELSE 0 END
    FROM    fv_looncomponent_mapping lm
        INNER JOIN fv_looncomponent lc 
            ON lm.looncomponent_id = lc.id
            AND lm.id = CASE WHEN '$sub.cboLCR$' = '' THEN NULL ELSE $sub.cboLCR$+0    END
            AND SUBSTRING('$sub.tmOverigeUren$', 12, 5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
fv_declaratie -> ReisurenTvT;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> id;
sub -> cboLCR;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement341()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie
SET looncomponent_mapping_id = CASE WHEN '$sub.cboLCR$' = '' THEN NULL ELSE $sub.cboLCR$+0 END, 
    aantal = '$sub.tmOverigeUren$', 
    rubricering = '$sub.txtOrdrnr$', 
    omschrijving = '$sub.txtOpm$', 
     
    ReisurenTvT = CASE WHEN '$sub.chkReisUren$' = 'true' THEN 1 ELSE 0 END, 
    orderoms = '$sub.txtDesc$'
WHERE id = '$sub.txtDeclIDR$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> looncomponent_mapping_id;
sub -> cboLCR;
fv_declaratie -> aantal;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> ReisurenTvT;
fv_declaratie -> orderoms;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement342()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_declaratie WHERE id = '$sub.txtDeclIDR$' AND ((SUBSTRING(CONVERT(NVARCHAR,aantal,108),1,5)='00:00') OR (looncomponent_mapping_id IS NULL))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
fv_declaratie -> looncomponent_mapping_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement343()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, overurentvt, consignatie, orderoms) 
SELECT  NEWID(),  lm.id,  CONVERT(DATETIME, '$flow.werkdatum$'),  '$sub.tmOverUren$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$',CASE WHEN '$sub.chkOverUren$' = 'true' THEN 1 ELSE 0 END, CASE WHEN '$sub.chkConsignatie$' = 'true' THEN 1 ELSE 0 END, '$sub.txtDesc$' 
FROM fv_looncomponent_mapping lm 
    INNER JOIN fv_looncomponent lc 
        ON lm.looncomponent_id = lc.id 
            AND lm.veldindicatie = 'overuren 1en2' 
            AND SUBSTRING('$sub.tmOverUren$',12,5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> overurentvt;
fv_declaratie -> consignatie;
fv_declaratie -> orderoms;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> veldindicatie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement344()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie 
SET aantal='$sub.tmOverUren$', 
    omschrijving = '$sub.txtOpm$', 
    rubricering='$sub.txtOrdrnr$', 
    overurentvt = CASE WHEN '$sub.chkOverUren$' = 'true' THEN 1 ELSE 0 END,
    consignatie = CASE WHEN '$sub.chkConsignatie$' = 'true' THEN 1 ELSE 0 END,
    orderoms='$sub.txtDesc$' 
WHERE ID = '$sub.txtDeclIDO$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> aantal;
fv_declaratie -> omschrijving;
fv_declaratie -> rubricering;
fv_declaratie -> overurentvt;
fv_declaratie -> consignatie;
fv_declaratie -> orderoms;
fv_declaratie -> ID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement345()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where id = '$sub.txtDeclIDO$' and ((SUBSTRING(Convert(nvarchar,aantal,108),1,5)='00:00') OR (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
fv_declaratie -> looncomponent_mapping_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement346()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_declaratie (id, looncomponent_mapping_id, werkdt, aantal, engineer_id, prestatiesoort, rubricering, omschrijving, orderoms, overurentvt, consignatie) 
SELECT  NEWID(),  lm.id,  CONVERT(DATETIME,'$flow.werkdatum$'),  '$sub.tmOverExtraUren$', $app.userid$, lc.prestatiesoort, '$sub.txtOrdrnr$', '$sub.txtOpm$', '$sub.txtDesc$', CASE WHEN '$sub.chkOverUren$' = 'true' THEN 1 ELSE 0 END, CASE WHEN '$sub.chkConsignatie$' = 'true' THEN 1 ELSE 0 END FROM fv_looncomponent_mapping lm INNER JOIN fv_looncomponent lc ON lm.looncomponent_id = lc.id AND lm.id = CASE WHEN '$sub.cboLCOE$'='' THEN null ELSE $sub.cboLCOE$+0 END AND SUBSTRING('$sub.tmOverExtraUren$',12,5) <> '00:00'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_declaratie -> id;
fv_declaratie -> looncomponent_mapping_id;
fv_declaratie -> werkdt;
fv_declaratie -> aantal;
fv_declaratie -> engineer_id;
fv_declaratie -> prestatiesoort;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> orderoms;
fv_declaratie -> overurentvt;
fv_declaratie -> consignatie;
}
subgraph select {
lm -> id;
app -> userid;
lc -> prestatiesoort;
fv_looncomponent_mapping -> lm;
fv_looncomponent -> lc;
lm -> looncomponent_id;
lc -> id;
lm -> id;
sub -> cboLCOE;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement347()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_declaratie 
SET looncomponent_mapping_id = CASE WHEN '$sub.cboLCOE$'='' THEN null ELSE $sub.cboLCOE$+0 END, 
    aantal='$sub.tmOverExtraUren$', 
    rubricering='$sub.txtOrdrnr$', 
    omschrijving = '$sub.txtOpm$', 
    

    overurentvt = CASE WHEN '$sub.chkOverUren$' = 'true' THEN 1 ELSE 0 END,

    consignatie = CASE WHEN '$sub.chkConsignatie$' = 'true' THEN 1 ELSE 0 END,
    orderoms = '$sub.txtDesc$'
 WHERE id = '$sub.txtDeclIDOE$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_declaratie -> looncomponent_mapping_id;
sub -> cboLCOE;
fv_declaratie -> aantal;
fv_declaratie -> rubricering;
fv_declaratie -> omschrijving;
fv_declaratie -> overurentvt;
fv_declaratie -> consignatie;
fv_declaratie -> orderoms;
fv_declaratie -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement348()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE from fv_declaratie WHERE id = '$sub.txtDeclIDOE$' and ((SUBSTRING(CONVERT(NVARCHAR,aantal,108),1,5)='00:00') OR (looncomponent_mapping_id is null))");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> id;
fv_declaratie -> aantal;
fv_declaratie -> looncomponent_mapping_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement349()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_declaratie where werkdt = Convert(datetime,'$flow.werkdatum$') and engineer_id = $app.userid$ and rubricering = '$flow.declaratie$' and activity_id is null");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_declaratie -> werkdt;
fv_declaratie -> engineer_id;
app -> userid;
fv_declaratie -> rubricering;
fv_declaratie -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement350()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief_status
(id ,activity_id ,external_id ,sub_id ,activitystatustype_id ,statusdt, rostatusdt, engineer_id ,radiostatus_id)
SELECT NEWID(), id, external_id, sub_id, 50, GETDATE(), '$flow.startdt$', $app.userID$, 0 FROM fv_activity
WHERE id = '$flow.activity_id$'
    AND 50 NOT IN (SELECT activitystatustype_id FROM fv_debrief_status WHERE activity_id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief_status -> id;
fv_debrief_status -> activity_id;
fv_debrief_status -> external_id;
fv_debrief_status -> sub_id;
fv_debrief_status -> activitystatustype_id;
fv_debrief_status -> statusdt;
fv_debrief_status -> rostatusdt;
fv_debrief_status -> engineer_id;
fv_debrief_status -> radiostatus_id;
}
subgraph select {
app -> userID;
fv_activity -> id;
subgraph select {
fv_debrief_status -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr718()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(ds.rostatusdt, d.startdt) AS startdt, GETDATE() AS now
FROM fv_debrief d
LEFT OUTER JOIN fv_activity a on d.activity_id = a.id
LEFT OUTER JOIN  fv_debrief_status ds ON ds.external_id = a.external_id AND ds.sub_id = a.sub_id
AND ds.activitystatustype_id = 50
WHERE d.activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ds -> rostatusdt;
d -> startdt;
fv_debrief -> d;
fv_activity -> a;
d -> activity_id;
a -> id;
fv_debrief_status -> ds;
ds -> external_id;
a -> external_id;
ds -> sub_id;
a -> sub_id;
ds -> activitystatustype_id;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr726()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_activitystatus
SET alterdstatusdt = '$flow.startdt$',
    radiostatus_id = 0
WHERE  $flow.IsStart$ = 1
AND activity_id = '$flow.activity_id$'
AND activitystatustype_id = 50");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activitystatus -> alterdstatusdt;
fv_activitystatus -> radiostatus_id;
flow -> IsStart;
fv_activitystatus -> activity_id;
fv_activitystatus -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr727()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_activitystatus
SET alterdstatusdt = '$flow.verholpendt$',
    radiostatus_id = 0
WHERE  $flow.IsStart$+0 = 0
AND activity_id = '$flow.activity_id$'
AND activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activitystatus -> alterdstatusdt;
fv_activitystatus -> radiostatus_id;
flow -> IsStart;
fv_activitystatus -> activity_id;
fv_activitystatus -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr728()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief
SET startdt = '$flow.startdt$'
WHERE  $flow.IsStart$ = 1
AND activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> startdt;
flow -> IsStart;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement351()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CONVERT(NVARCHAR, COALESCE(MIN(ds.statusdt),
                                   DATEADD(year, 1, GETDATE())), 126) AS debrief_statusdt
FROM    fv_debrief_status ds
        INNER JOIN fv_activity a ON a.external_id = ds.external_id
                                    AND a.sub_id = ds.sub_id
                                    AND a.activitystatustype_id NOT IN ( 120, 125, 60, 62 )
WHERE   ds.activitystatustype_id = 59
        AND NOT EXISTS ( SELECT 0
                         FROM   fv_activitystatus acts
                         WHERE  acts.activity_id = a.id
                                AND acts.activitystatustype_id IN ( 120, 125, 60, 62 ) )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
ds -> statusdt;
fv_debrief_status -> ds;
fv_activity -> a;
a -> external_id;
ds -> external_id;
a -> sub_id;
ds -> sub_id;
a -> activitystatustype_id;
ds -> activitystatustype_id;
fv_activitystatus -> acts;
acts -> activity_id;
a -> id;
acts -> activitystatustype_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement352()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE  FROM fv_tmp_werkbonmateriaal
WHERE   NOT EXISTS ( SELECT *
                     FROM   fv_activity a
                     WHERE  a.activitystatustype_id = 144
                            AND a.sub_id = fv_tmp_werkbonmateriaal.werkbonId )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_activity -> a;
a -> activitystatustype_id;
a -> sub_id;
fv_tmp_werkbonmateriaal -> werkbonId;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement353()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_param_mobile WHERE description IN('Desktop Photo Path','Mobile Photo Path','Camera Working Folder','Dispatch Photo Path')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_param_mobile -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement354()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_param_mobile (
    id,
    senttoclient,
    notes,
    description,
    paramvalue
) VALUES ( 
    /* id - int */ 1,
    /* senttoclient - int */ 1,
    /* notes - varchar(255) */ null,
    /* description - varchar(50) */ 'Desktop Photo Path',
    /* paramvalue - varchar(250) */ 'C:\Tensing\FieldVision PROD\Media\' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_param_mobile -> id;
fv_param_mobile -> senttoclient;
fv_param_mobile -> notes;
fv_param_mobile -> description;
fv_param_mobile -> paramvalue;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement355()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_param_mobile (
    id,
    senttoclient,
    notes,
    description,
    paramvalue
) VALUES ( 
    /* id - int */ 2,
    /* senttoclient - int */ 1,
    /* notes - varchar(255) */ null,
    /* description - varchar(50) */ 'Camera Working Folder',
    /* paramvalue - varchar(250) */ '%userprofile%\my pictures\' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_param_mobile -> id;
fv_param_mobile -> senttoclient;
fv_param_mobile -> notes;
fv_param_mobile -> description;
fv_param_mobile -> paramvalue;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement356()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_param_mobile (
    id,
    senttoclient,
    notes,
    description,
    paramvalue
) VALUES ( 
    /* id - int */ 3,
    /* senttoclient - int */ 1,
    /* notes - varchar(255) */ null,
    /* description - varchar(50) */ 'Mobile Photo Path',
    /* paramvalue - varchar(250) */ 'C:\Tensing\FieldVision PROD\Media\' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_param_mobile -> id;
fv_param_mobile -> senttoclient;
fv_param_mobile -> notes;
fv_param_mobile -> description;
fv_param_mobile -> paramvalue;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement357()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_param_mobile (
    id,
    senttoclient,
    notes,
    description,
    paramvalue
) VALUES ( 
    /* id - int */ 4,
    /* senttoclient - int */ 1,
    /* notes - varchar(255) */ null,
    /* description - varchar(50) */ 'Dispatch Photo Path',
    /* paramvalue - varchar(250) */ 'D:\win32app\Fieldvision\Media\' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_param_mobile -> id;
fv_param_mobile -> senttoclient;
fv_param_mobile -> notes;
fv_param_mobile -> description;
fv_param_mobile -> paramvalue;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement358()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS Aantal
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'fv_debrief_status'
AND COLUMN_NAME = 'rostatusdt'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement359()
        {
            var statement = MacroScope.Factory.CreateStatement(@"ALTER TABLE fv_debrief_status ADD rostatusdt DATETIME");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement360()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_commfield WHERE fieldname = 'ROSTATUSDT' AND tableid = 52");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_commfield -> fieldname;
fv_commfield -> tableid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement361()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (fieldid, fieldname, fieldtype, tableid) VALUES (10, 'ROSTATUSDT', 135, 52)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> fieldid;
fv_commfield -> fieldname;
fv_commfield -> fieldtype;
fv_commfield -> tableid;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement362()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS Aantal
FROM fv_commtable
WHERE TableName = 'fv_param_mobile'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_commtable -> TableName;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement363()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_commfield WHERE tableid = 56;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_commfield -> tableid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement364()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_commtable WHERE tableid = 56;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_commtable -> tableid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement365()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commtable (TableID, TableName, sendwithactivity, sendwithserviceorder, sendwithcustomer, client2server, sendwithlocation) VALUES (56, N'FV_PARAM_MOBILE', NULL, NULL, NULL, NULL, NULL);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commtable -> TableID;
fv_commtable -> TableName;
fv_commtable -> sendwithactivity;
fv_commtable -> sendwithserviceorder;
fv_commtable -> sendwithcustomer;
fv_commtable -> client2server;
fv_commtable -> sendwithlocation;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement366()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (TableID, FieldID, FieldName, FieldType) VALUES (56, 0, N'ID', 3);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> TableID;
fv_commfield -> FieldID;
fv_commfield -> FieldName;
fv_commfield -> FieldType;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement367()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (TableID, FieldID, FieldName, FieldType) VALUES (56, 1, N'NOTES', 200);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> TableID;
fv_commfield -> FieldID;
fv_commfield -> FieldName;
fv_commfield -> FieldType;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement368()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (TableID, FieldID, FieldName, FieldType) VALUES (56, 2, N'DESCRIPTION', 200);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> TableID;
fv_commfield -> FieldID;
fv_commfield -> FieldName;
fv_commfield -> FieldType;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement369()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (TableID, FieldID, FieldName, FieldType) VALUES (56, 3, N'PARAMVALUE', 200);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> TableID;
fv_commfield -> FieldID;
fv_commfield -> FieldName;
fv_commfield -> FieldType;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement370()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS Aantal
FROM fv_commtable
WHERE TableName = 'fv_version_clientdb'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_commtable -> TableName;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement371()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_commfield WHERE tableid = 57;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_commfield -> tableid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement372()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_commtable WHERE tableid = 57;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_commtable -> tableid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement373()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commtable (TableID, TableName, sendwithactivity, sendwithserviceorder, sendwithcustomer, client2server, sendwithlocation) VALUES (57, N'FV_VERSION_CLIENTDB', NULL, NULL, NULL, NULL, NULL);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commtable -> TableID;
fv_commtable -> TableName;
fv_commtable -> sendwithactivity;
fv_commtable -> sendwithserviceorder;
fv_commtable -> sendwithcustomer;
fv_commtable -> client2server;
fv_commtable -> sendwithlocation;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement374()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (TableID, FieldID, FieldName, FieldType) VALUES (57, 0, N'ID', 3);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> TableID;
fv_commfield -> FieldID;
fv_commfield -> FieldName;
fv_commfield -> FieldType;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement375()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (TableID, FieldID, FieldName, FieldType) VALUES (57, 1, N'CLIENTDB_DATE', 135);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> TableID;
fv_commfield -> FieldID;
fv_commfield -> FieldName;
fv_commfield -> FieldType;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement376()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (TableID, FieldID, FieldName, FieldType) VALUES (57, 2, N'CLIENTDB_VERSION', 202);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> TableID;
fv_commfield -> FieldID;
fv_commfield -> FieldName;
fv_commfield -> FieldType;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement377()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_version_clientdb (id,clientdb_version,clientdb_date) VALUES (     /* id - int */ 1,/* clientdb_version - nvarchar(100) */ N'Werkbon 2010 Fase 1',    /* clientdb_date - datetime */ '2012-4-24' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_version_clientdb -> id;
fv_version_clientdb -> clientdb_version;
fv_version_clientdb -> clientdb_date;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement378()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS Aantal
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'fv_paraafstatus'
AND COLUMN_NAME = 'canescape'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement379()
        {
            var statement = MacroScope.Factory.CreateStatement(@"ALTER TABLE fv_paraafstatus ADD canescape INT DEFAULT 0;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement380()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_paraafstatus SET external_id = 'KlantAkkoord', description = 'Klant accoord voor gezien' WHERE id = 1;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_paraafstatus -> external_id;
fv_paraafstatus -> description;
fv_paraafstatus -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement381()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_paraafstatus SET external_id = 'KlantNietAkkoord', description = 'Klant niet accoord', canescape = 1 WHERE id = 2;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_paraafstatus -> external_id;
fv_paraafstatus -> description;
fv_paraafstatus -> canescape;
fv_paraafstatus -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement382()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_paraafstatus SET external_id = 'KlantNietAanwezig', description = 'Niemand aanwezig om te tekenen', canescape = 1 WHERE id = 3;");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_paraafstatus -> external_id;
fv_paraafstatus -> description;
fv_paraafstatus -> canescape;
fv_paraafstatus -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement383()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_commfield (TableID, FieldID, FieldName, FieldType) VALUES (34, 9, N'CANESCAPE', 3);");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_commfield -> TableID;
fv_commfield -> FieldID;
fv_commfield -> FieldName;
fv_commfield -> FieldType;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement384()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_version_clientdb (id,clientdb_version,clientdb_date) VALUES (     /* id - int */ 3,/* clientdb_version - nvarchar(100) */ N'Werkbon 2010 Fase 2',    /* clientdb_date - datetime */ '2012-5-22' );");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_version_clientdb -> id;
fv_version_clientdb -> clientdb_version;
fv_version_clientdb -> clientdb_date;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement385()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE
    fv_activity
SET 
    activitystatustype_id = 30
WHERE
    activitystatustype_id = 59
    AND NOT EXISTS ( SELECT
                        0 AS debrief_statusdt
                     FROM
                        fv_debrief_status ds
                        INNER JOIN fv_activity a1
                            ON a1.external_id = ds.external_id
                               AND a1.sub_id = ds.sub_id
                               AND a1.id = fv_activity.id
                     WHERE
                        ds.activitystatustype_id = 59 )
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitystatustype_id;
fv_activity -> activitystatustype_id;
subgraph select {
fv_debrief_status -> ds;
fv_activity -> a1;
a1 -> external_id;
ds -> external_id;
a1 -> sub_id;
ds -> sub_id;
a1 -> id;
fv_activity -> id;
ds -> activitystatustype_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr719()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CASE WHEN COALESCE(isafmeldbonvoorklantverplicht, 0) = 1 THEN 1 ELSE 0 END AS isafmeldbonvoorklantverplicht,
        CASE WHEN COALESCE(isafmeldbonvoorklantverplicht, 0) = 2 THEN 1 ELSE 0 END AS isafmeldbonvoorklantoptie,
        CASE COALESCE(isantidaterentoegestaan, 1) WHEN 0 THEN 1 ELSE 0 END AS isantidaterenniettoegestaan,
        COALESCE(isequipmentscannenverplicht, 0) AS isequipmentscannenverplicht,
        CASE WHEN COALESCE(ishandtekeningverplicht, 0) = 1 THEN 1 ELSE 0 END AS ishandtekeningverplicht,
        CASE WHEN COALESCE(ishandtekeningverplicht, 0) = 2 THEN 1 ELSE 0 END AS ishandtekeningoptie,
        COALESCE(isnlsfbcodeverplicht, 0) AS isnlsfbcodeverplicht,
        COALESCE(isurenspecificatieverplicht, 0) AS isurenspecificatieverplicht
FROM    fv_activity
WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement386Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  l1.emailto
FROM    fv_emaillist l1
WHERE   l1.id IN ( SELECT   MIN(id)
                   FROM     fv_emaillist l2
                   WHERE    l1.activity_id = l2.activity_id
                            AND l1.emailto = l2.emailto )
        AND activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
l1 -> emailto;
fv_emaillist -> l1;
l1 -> id;
fv_emaillist -> l2;
l1 -> activity_id;
l2 -> activity_id;
l1 -> emailto;
l2 -> emailto;
}
fv_emaillist -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr720()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT       'Ordernr: ' + COALESCE(fv_activity.serviceordernumber,'') + '
' + 'Werkbon: ' + COALESCE(convert(nvarchar,fv_activity.sub_id),'') + '
' + 'Datum: ' + CONVERT(nvarchar,getdate(),105) + '

' + 'Omschrijving: 
' + COALESCE (fv_activity.description, '') AS samenvatting
FROM         fv_activity
where fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> sub_id;
fv_activity -> description;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr721()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT      fv_debrief.notes
FROM         fv_debrief 
where fv_debrief.activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> notes;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr723()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    GETDATE() AS nu,
    DATEADD(day, 1, GETDATE()) AS morgen,
    '1900-01-01 08:00' AS acht_uur,
    '0' AS def,
    NEWID() AS new_act_id,
    CONVERT(NVARCHAR(4000),fv_debrief.notes)
FROM    fv_debrief
WHERE    fv_debrief.activity_id = '$flow.activity_id$'
UNION
SELECT    GETDATE() AS nu,
    DATEADD(day, 1, GETDATE()) AS morgen,
    '1900-01-01 08:00' AS acht_uur,
    '0' AS def,
    NEWID() AS new_act_id,
    NULL
FROM fv_engineer
WHERE id=$app.userid$ AND NOT EXISTS(SELECT * FROM    fv_debrief
WHERE    fv_debrief.activity_id = '$flow.activity_id$')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> notes;
fv_debrief -> activity_id;
fv_engineer -> id;
app -> userid;
fv_debrief -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr738()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select  fv_medewerker.description from fv_debrief inner join fv_medewerker on fv_debrief.vervolg_medewerker_id = fv_medewerker.id where fv_debrief.activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_medewerker -> description;
fv_debrief -> vervolg_medewerker_id;
fv_medewerker -> id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement387Component0()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    fv_cancelreason.id,
    fv_cancelreason.description
FROM    fv_cancelreason
WHERE    fv_cancelreason.isactive = 1
ORDER BY fv_cancelreason.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_cancelreason -> id;
fv_cancelreason -> description;
fv_cancelreason -> isactive;
fv_cancelreason -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement388()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT e.id FROM fv_debrief d
INNER JOIN fv_medewerker m ON d.vervolg_medewerker_id = m.id
INNER JOIN fv_engineer e ON m.external_id = e.external_id
WHERE    d.activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
e -> id;
fv_debrief -> d;
fv_medewerker -> m;
d -> vervolg_medewerker_id;
m -> id;
fv_engineer -> e;
m -> external_id;
e -> external_id;
d -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement389()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief 
SET restduur=($sub.txtUren$*60)+$sub.lcMinuten$,
send_email = null
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> restduur;
sub -> txtUren;
sub -> lcMinuten;
fv_debrief -> send_email;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement390()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -4, '$flow.NewStatusdt$'), 0, 150, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement391()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -3, '$flow.NewStatusdt$'), 0, 120, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement392()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET    activitystatustype_id = 120,
    maxstatusdt = DATEADD(second, -3, '$flow.NewStatusdt$')
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitystatustype_id;
fv_activity -> maxstatusdt;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement393()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, herpland_door_naam, nlsfb_id)
SELECT    '$flow.NewActivity_id$', '$flow.NewStatusdt$', 30, external_id, sub_id, $flow.herplan_naar_engineer_id$, '$flow.datum$',
    DATEADD(minute, DATEDIFF(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, $flow.tijd$, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    CASE WHEN LEN('$flow.opmerking2$') > 999 THEN SUBSTRING('$flow.opmerking2$', 0, 999) ELSE '$flow.opmerking2$' END, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, '$app.username$', nlsfb_id
FROM    fv_activity
WHERE    id = '$flow.activity_id$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activity -> id;
fv_activity -> maxstatusdt;
fv_activity -> activitystatustype_id;
fv_activity -> external_id;
fv_activity -> sub_id;
fv_activity -> engineer_id;
fv_activity -> planstartdt;
fv_activity -> planenddt;
fv_activity -> capability_id;
fv_activity -> causecode_id;
fv_activity -> changedt;
fv_activity -> city;
fv_activity -> zip;
fv_activity -> street;
fv_activity -> housenumber;
fv_activity -> housenumbertext;
fv_activity -> community;
fv_activity -> contact;
fv_activity -> contact_id;
fv_activity -> contract_id;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_activity -> country;
fv_activity -> criteriumstartdt;
fv_activity -> criteriumenddt;
fv_activity -> customer_id;
fv_activity -> customer_main_id;
fv_activity -> customerexternal_id;
fv_activity -> description;
fv_activity -> email;
fv_activity -> equipmentname;
fv_activity -> fax;
fv_activity -> functieplaatsnaam;
fv_activity -> historie_tekst;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_activity -> meldkamernummer;
fv_activity -> ministoringsboek;
fv_activity -> mobilephone;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> normtijd;
fv_activity -> opdrachtnummer;
fv_activity -> ordersoort_id;
fv_activity -> organisation_id;
fv_activity -> phone;
fv_activity -> serviceorder_id;
fv_activity -> aangemaakt_door_naam;
fv_activity -> activitytype_id;
fv_activity -> planner_id;
fv_activity -> planner_name;
fv_activity -> priority_id;
fv_activity -> problemcode_id;
fv_activity -> productgroep_id;
fv_activity -> region_id;
fv_activity -> seen_by_eng;
fv_activity -> serviceobject_id;
fv_activity -> serviceordernumber;
fv_activity -> solutioncode_id;
fv_activity -> state;
fv_activity -> taken;
fv_activity -> verantwoordelijk;
fv_activity -> samenvatting;
fv_activity -> notes;
fv_activity -> onderwerp;
fv_activity -> isafmeldbonvoorklantverplicht;
fv_activity -> isantidaterentoegestaan;
fv_activity -> isequipmentscannenverplicht;
fv_activity -> ishandtekeningverplicht;
fv_activity -> isnlsfbcodeverplicht;
fv_activity -> isurenspecificatieverplicht;
fv_activity -> herpland_door_naam;
fv_activity -> nlsfb_id;
}
subgraph select {
flow -> herplan_naar_engineer_id;
flow -> tijd;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement394()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $flow.herplan_naar_engineer_id$, DATEADD(second, -2, '$flow.NewStatusdt$'), 0, 30, '$flow.NewActivity_id$'
FROM fv_engineer
WHERE  id = $flow.herplan_naar_engineer_id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
flow -> herplan_naar_engineer_id;
fv_engineer -> id;
flow -> herplan_naar_engineer_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement395()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
SELECT    NEWID(), $flow.herplan_naar_engineer_id$, '$flow.NewStatusdt$', 0, 152, '$flow.NewActivity_id$', '$flow.opmerking$',
    CASE WHEN '$flow.reden$'='' THEN null ELSE '$flow.reden$' END
FROM fv_engineer
WHERE  id = $flow.herplan_naar_engineer_id$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
fv_activitystatus -> cancelnotes;
fv_activitystatus -> cancelreason_id;
}
subgraph select {
flow -> herplan_naar_engineer_id;
fv_engineer -> id;
flow -> herplan_naar_engineer_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement396()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE WHEN COUNT(QUANTITY)=0 THEN '0' else '1' END as materiaalingevoerd from fv_materialmutation where activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialmutation -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr730()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select external_id, 'fv' as password from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr731()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT sub_id FROM fv_activity WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr732()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select COALESCE(bestel_autorisatie,0) as bestel_autorisatie, COALESCE(ontvangst_autorisatie,0) as ontvangst_autorisatie from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr733()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(fv_activity.serviceordernumber,'') as sonr
FROM fv_activity 
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> serviceordernumber;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement397()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM fv_tmp_werkbonmateriaal
WHERE EXISTS (SELECT * FROM fv_activity WHERE fv_activity.sub_id = fv_tmp_werkbonmateriaal.WerkbonId
AND fv_activity.id = '$flow.activity_id$')");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_activity -> sub_id;
fv_tmp_werkbonmateriaal -> WerkbonId;
fv_activity -> id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement398Component4178()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  fv_tmp_werkbonmateriaal.id,
        fv_tmp_werkbonmateriaal.external_id,
        WerkbonId,
        Fabrikant,
        Leverancier,
        Aantal,
        Artikelnummer,
        COALESCE(Artikelnummer, '') + '/' + COALESCE(omschrijving, '') + '/'
        + COALESCE(leverancier, '') AS Omschrijving,
        '' AS empty,
        0 AS is_mutated
FROM    fv_tmp_werkbonmateriaal
        INNER JOIN fv_activity ON fv_activity.sub_id = fv_tmp_werkbonmateriaal.WerkbonId
WHERE NOT EXISTS (SELECT * FROM fv_materialmutation WHERE fv_activity.id = fv_materialmutation.activity_id
AND fv_materialmutation.wbm_id = fv_tmp_werkbonmateriaal.external_id)
AND fv_activity.id = '$flow.activity_id$'
UNION
SELECT  fv_tmp_werkbonmateriaal.id,
        fv_tmp_werkbonmateriaal.external_id,
        WerkbonId,
        Fabrikant,
        Leverancier,
        Aantal,
        Artikelnummer,
        COALESCE(Artikelnummer, '') + '/' + COALESCE(omschrijving, '') + '/'
        + COALESCE(leverancier, '') AS Omschrijving,
        '' AS empty,
        1
FROM    fv_tmp_werkbonmateriaal
        INNER JOIN fv_activity ON fv_activity.sub_id = fv_tmp_werkbonmateriaal.WerkbonId
WHERE EXISTS (SELECT * FROM fv_materialmutation WHERE fv_activity.id = fv_materialmutation.activity_id
AND fv_materialmutation.wbm_id = fv_tmp_werkbonmateriaal.external_id)
AND fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_tmp_werkbonmateriaal -> id;
fv_tmp_werkbonmateriaal -> external_id;
fv_activity -> sub_id;
fv_tmp_werkbonmateriaal -> WerkbonId;
fv_activity -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> wbm_id;
fv_tmp_werkbonmateriaal -> external_id;
}
fv_activity -> id;
fv_tmp_werkbonmateriaal -> id;
fv_tmp_werkbonmateriaal -> external_id;
fv_activity -> sub_id;
fv_tmp_werkbonmateriaal -> WerkbonId;
fv_activity -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> wbm_id;
fv_tmp_werkbonmateriaal -> external_id;
}
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement399Component4187()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT     coalesce(bestelnr,'') + '/' + coalesce(description,'') + '/' + coalesce(supplier_name,'') as omsch, quantity, type, id,'' as empty
FROM         fv_materialmutation
WHERE     TYPE IN ('D','O','A') and activity_id = '$flow.activity_id$'
AND material_id IS NULL
UNION
SELECT     coalesce(fv_material.bestelnr,'') + '/' + coalesce(fv_materialmutation.description,'') + '/' + coalesce(fv_supplier.description,'') AS omsch, fv_materialmutation.quantity, type, fv_materialmutation.id,'' as empty
FROM         fv_materialmutation INNER JOIN
                      fv_material ON fv_materialmutation.material_id = fv_material.id LEFT OUTER JOIN
                      fv_supplier ON fv_material.supplier_id = fv_supplier.id
WHERE     (fv_materialmutation.type = 'A') and  activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_materialmutation -> TYPE;
fv_materialmutation -> activity_id;
fv_materialmutation -> material_id;
fv_material -> bestelnr;
fv_materialmutation -> description;
fv_supplier -> description;
fv_materialmutation -> quantity;
fv_materialmutation -> id;
fv_materialmutation -> material_id;
fv_material -> id;
fv_material -> supplier_id;
fv_supplier -> id;
fv_materialmutation -> type;
fv_materialmutation -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement400()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_materialmutation (id,activity_id,mutationdt,radiostatus_id,type,supplier_name, wbm_id, quantity, bestelnr, description, purchaseorderpositie) select '$flow.mat_id$','$flow.activity_id$',getdate(),-1,'A', Leverancier, external_id,     Aantal, Artikelnummer, Omschrijving, PurchaseOrder from fv_tmp_werkbonmateriaal where id = '$flow.prog_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_materialmutation -> id;
fv_materialmutation -> activity_id;
fv_materialmutation -> mutationdt;
fv_materialmutation -> radiostatus_id;
fv_materialmutation -> type;
fv_materialmutation -> supplier_name;
fv_materialmutation -> wbm_id;
fv_materialmutation -> quantity;
fv_materialmutation -> bestelnr;
fv_materialmutation -> description;
fv_materialmutation -> purchaseorderpositie;
}
subgraph select {
fv_tmp_werkbonmateriaal -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement401()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from fv_materialmutation where id = '$flow.mat_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
fv_materialmutation -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement402()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DROP TABLE fv_tmp_bestelling");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement403()
        {
            var statement = MacroScope.Factory.CreateStatement(@"CREATE TABLE fv_tmp_bestelling(balie int NULL , huisnummer nvarchar(50) NULL , id uniqueidentifier ROWGUIDCOL CONSTRAINT PK_fv_tmp_bestelling PRIMARY KEY , land nvarchar(50) NULL , leveranciernummer nvarchar(50) NULL , naam nvarchar(50) NULL , naam2 nvarchar(50) NULL , onderaanneming int NULL , plaats nvarchar(50) NULL , postcode nvarchar(50) NULL , sonummer nvarchar(50) NULL , straat nvarchar(50) NULL , werkbon int NULL )");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement404()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_bestellingregel");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement405()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_tmp_bestelling (id,sonummer,werkbon,straat,naam,naam2,huisnummer,postcode,plaats,land) select '$flow.bestel_id$',serviceordernumber,sub_id,street,name,name_2,housenumber,zip,city,'NL' from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_tmp_bestelling -> id;
fv_tmp_bestelling -> sonummer;
fv_tmp_bestelling -> werkbon;
fv_tmp_bestelling -> straat;
fv_tmp_bestelling -> naam;
fv_tmp_bestelling -> naam2;
fv_tmp_bestelling -> huisnummer;
fv_tmp_bestelling -> postcode;
fv_tmp_bestelling -> plaats;
fv_tmp_bestelling -> land;
}
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement406()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement407()
        {
            var statement = MacroScope.Factory.CreateStatement(@"Delete from fv_tmp_purchaseorderline");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr734()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT id AS deb_photo_id, 
    notes AS deb_photo_notes
FROM fv_debrief_photo
WHERE id = '$flow.photoid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_photo -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr736()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief_photo SET radiostatus_id = 0 
WHERE activity_id = '$flow.activity_id$'
AND radiostatus_id = -1 AND isactive = 1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief_photo -> radiostatus_id;
fv_debrief_photo -> activity_id;
fv_debrief_photo -> radiostatus_id;
fv_debrief_photo -> isactive;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement408Component4194()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT
    fv_debrief_photo.id,
    COALESCE(filename, '') AS filename,
    COALESCE(fv_param_mobile.paramvalue, '\Program Files\FVDNet\Media\') + COALESCE(path, '') AS filepath,
    fv_debrief_photo.notes AS photo_remark,
    COALESCE(fv_debrief_photo.radiostatus_id,-1) AS radiostatus_id
FROM
    fv_debrief_photo
    LEFT OUTER JOIN fv_param_mobile
        ON fv_param_mobile.description = 'Mobile Photo Path'
WHERE 
    activity_id = '$flow.activity_id$'
    AND isactive = 1


");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_photo -> id;
fv_param_mobile -> paramvalue;
fv_debrief_photo -> notes;
fv_debrief_photo -> radiostatus_id;
fv_param_mobile -> description;
fv_debrief_photo -> activity_id;
fv_debrief_photo -> isactive;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement409()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief_photo SET isactive = 0, radiostatus_id = -1 WHERE id = '$flow.photoid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief_photo -> isactive;
fv_debrief_photo -> radiostatus_id;
fv_debrief_photo -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement410()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief_photo SET notes = '$sub.txtPhotoRemark$', radiostatus_id = -1 WHERE id = '$flow.photoid$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief_photo -> notes;
fv_debrief_photo -> radiostatus_id;
fv_debrief_photo -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement411()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_debrief
SET    vervolg_medewerker_id = $sub.grdZoekMDW.id$
WHERE    activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> vervolg_medewerker_id;
sub -> grdZoekMDW;
grdZoekMDW -> id;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement412Component4240()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    m.id,
    m.external_id,
    m.description
FROM    fv_medewerker m
INNER JOIN fv_engineer e ON m.external_id = e.external_id
WHERE    m.isactive = 1 AND e.isactive = 1
    AND m.description LIKE '$sub.txtZoek$' + '%'
    AND '$flow.zoek$' = '1'
ORDER BY m.description");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
m -> id;
m -> external_id;
m -> description;
fv_medewerker -> m;
fv_engineer -> e;
m -> external_id;
e -> external_id;
m -> isactive;
e -> isactive;
m -> description;
m -> description;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement413()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS IsFunctieHersteld FROM fv_debrief_status
WHERE activity_id IN ( SELECT a.id FROM fv_activity a
INNER JOIN fv_activity b ON
a.external_id = b.external_id
AND a.sub_id = b.sub_id
WHERE b.id = '$flow.activity_id$')
AND activitystatustype_id = 59");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> activity_id;
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
b -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement414()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT   planner_id
  FROM    fv_activity
  WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr739()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    getdate() as nu,
    fv_activity.id
FROM    fv_activity
WHERE    fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr740()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    COALESCE(ontvangst_autorisatie, 0) AS ontvangst_autorisatie
FROM    fv_engineer
WHERE    id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr741()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT    GETDATE() AS nu,
    DATEADD(minute, 1, GETDATE()) AS morgen,
    '1900-01-01 08:00' AS acht_uur,
    '0' AS def,
    NEWID() AS new_act_id,
    CONVERT(NVARCHAR(4000),fv_debrief.notes)
FROM    fv_debrief
WHERE    fv_debrief.activity_id = '$flow.activity_id$'
UNION
SELECT    GETDATE() AS nu,
    DATEADD(minute, 1, GETDATE()) AS morgen,
    '1900-01-01 08:00' AS acht_uur,
    '0' AS def,
    NEWID() AS new_act_id,
    NULL
FROM fv_engineer
WHERE id=$app.userid$ AND NOT EXISTS(SELECT * FROM    fv_debrief
WHERE    fv_debrief.activity_id = '$flow.activity_id$')
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> notes;
fv_debrief -> activity_id;
fv_engineer -> id;
app -> userid;
fv_debrief -> activity_id;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement415()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -4, '$flow.NewStatusdt$'), 0, 150, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement416()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -3, '$flow.NewStatusdt$'), 0, 120, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement417()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET    activitystatustype_id = 120,
    maxstatusdt = DATEADD(second, -3, '$flow.NewStatusdt$')
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitystatustype_id;
fv_activity -> maxstatusdt;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement418()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, herpland_door_naam, nlsfb_id)
SELECT    '$flow.NewActivity_id$', '$flow.NewStatusdt$', $flow.new_st$, external_id, sub_id, engineer_id, '$flow.datum$',
    DATEADD(minute, DATEDIFF(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, $flow.tijd$, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    CASE WHEN LEN('$flow.opmerking2$') > 999 THEN SUBSTRING('$flow.opmerking2$', 0, 999) ELSE '$flow.opmerking2$' END, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, '$app.username$', nlsfb_id
FROM    fv_activity
WHERE    id = '$flow.activity_id$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activity -> id;
fv_activity -> maxstatusdt;
fv_activity -> activitystatustype_id;
fv_activity -> external_id;
fv_activity -> sub_id;
fv_activity -> engineer_id;
fv_activity -> planstartdt;
fv_activity -> planenddt;
fv_activity -> capability_id;
fv_activity -> causecode_id;
fv_activity -> changedt;
fv_activity -> city;
fv_activity -> zip;
fv_activity -> street;
fv_activity -> housenumber;
fv_activity -> housenumbertext;
fv_activity -> community;
fv_activity -> contact;
fv_activity -> contact_id;
fv_activity -> contract_id;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_activity -> country;
fv_activity -> criteriumstartdt;
fv_activity -> criteriumenddt;
fv_activity -> customer_id;
fv_activity -> customer_main_id;
fv_activity -> customerexternal_id;
fv_activity -> description;
fv_activity -> email;
fv_activity -> equipmentname;
fv_activity -> fax;
fv_activity -> functieplaatsnaam;
fv_activity -> historie_tekst;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_activity -> meldkamernummer;
fv_activity -> ministoringsboek;
fv_activity -> mobilephone;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> normtijd;
fv_activity -> opdrachtnummer;
fv_activity -> ordersoort_id;
fv_activity -> organisation_id;
fv_activity -> phone;
fv_activity -> serviceorder_id;
fv_activity -> aangemaakt_door_naam;
fv_activity -> activitytype_id;
fv_activity -> planner_id;
fv_activity -> planner_name;
fv_activity -> priority_id;
fv_activity -> problemcode_id;
fv_activity -> productgroep_id;
fv_activity -> region_id;
fv_activity -> seen_by_eng;
fv_activity -> serviceobject_id;
fv_activity -> serviceordernumber;
fv_activity -> solutioncode_id;
fv_activity -> state;
fv_activity -> taken;
fv_activity -> verantwoordelijk;
fv_activity -> samenvatting;
fv_activity -> notes;
fv_activity -> onderwerp;
fv_activity -> isafmeldbonvoorklantverplicht;
fv_activity -> isantidaterentoegestaan;
fv_activity -> isequipmentscannenverplicht;
fv_activity -> ishandtekeningverplicht;
fv_activity -> isnlsfbcodeverplicht;
fv_activity -> isurenspecificatieverplicht;
fv_activity -> herpland_door_naam;
fv_activity -> nlsfb_id;
}
subgraph select {
flow -> new_st;
flow -> tijd;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement419()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -2, '$flow.NewStatusdt$'), 0, 30, '$flow.NewActivity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement420()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
SELECT    NEWID(), $app.userid$, '$flow.NewStatusdt$', 0, $flow.new_st$, '$flow.NewActivity_id$', '$flow.opmerking$',
    CASE WHEN '$flow.reden$'='' THEN null ELSE '$flow.reden$' END
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
fv_activitystatus -> cancelnotes;
fv_activitystatus -> cancelreason_id;
}
subgraph select {
app -> userid;
flow -> new_st;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement421()
        {
            var statement = MacroScope.Factory.CreateStatement(@"INSERT INTO fv_debrief_photo (id, activity_id, description, filename, radiostatus_id, isactive, path)
SELECT NEWID(), '$flow.NewActivity_id$', description, filename, 2, isactive, path FROM fv_debrief_photo WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_debrief_photo -> id;
fv_debrief_photo -> activity_id;
fv_debrief_photo -> description;
fv_debrief_photo -> filename;
fv_debrief_photo -> radiostatus_id;
fv_debrief_photo -> isactive;
fv_debrief_photo -> path;
}
subgraph select {
fv_debrief_photo -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement422()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_emaillist SET activity_id = '$flow.NewActivity_id$' WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_emaillist -> activity_id;
fv_emaillist -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement423()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM   fv_debrief_status
WHERE         EXISTS (SELECT * FROM fv_activity a WHERE a.external_id = fv_debrief_status.external_id
                                    AND a.sub_id = fv_debrief_status.sub_id
                                    AND a.id = '$flow.activity_id$')
AND activitystatustype_id = 50 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_activity -> a;
a -> external_id;
fv_debrief_status -> external_id;
a -> sub_id;
fv_debrief_status -> sub_id;
a -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement424()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE  fv_debrief_status SET activity_id = '$flow.NewActivity_id$', activitystatustype_id = $flow.new_st$
WHERE         EXISTS (SELECT * FROM fv_activity a WHERE a.external_id = fv_debrief_status.external_id
                                    AND a.sub_id = fv_debrief_status.sub_id
                                    AND a.id = '$flow.activity_id$')
AND activitystatustype_id = 59 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief_status -> activity_id;
fv_debrief_status -> activitystatustype_id;
flow -> new_st;
subgraph select {
fv_activity -> a;
a -> external_id;
fv_debrief_status -> external_id;
a -> sub_id;
fv_debrief_status -> sub_id;
a -> id;
}
fv_activity -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr742()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select getdate() as nu, id, 0 as def from fv_activity where id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestListQuerylstCheck6()
        {
            var statement = MacroScope.Factory.CreateStatement(@"(select 1,'U moet een geldige reden ingeven.',1 as sortorder from fv_activity a where a.id = '$flow.activity_id$' and '$sub.tb_reden$' IN ('', '0', 'NULL')) UNION (select 1, 'klaar', 9 as sortorder from fv_engineer where id = '$app.UserID$') order by sortorder");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> a;
a -> id;
fv_engineer -> id;
fv_engineer -> sortorder;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement425()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE fv_debrief 
SET restduur=($sub.txtUren$*60)+$sub.lcMinuten$,
send_email = null
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> restduur;
sub -> txtUren;
sub -> lcMinuten;
fv_debrief -> send_email;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement426()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM   fv_debrief_status
WHERE         EXISTS (SELECT * FROM fv_activity a WHERE a.external_id = fv_debrief_status.external_id
                                    AND a.sub_id = fv_debrief_status.sub_id
                                    AND a.id = '$flow.activity_id$')
AND activitystatustype_id = 50 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_activity -> a;
a -> external_id;
fv_debrief_status -> external_id;
a -> sub_id;
fv_debrief_status -> sub_id;
a -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement427()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE  fv_debrief_status SET activitystatustype_id = 157, radiostatus_id = 0
WHERE         EXISTS (SELECT * FROM fv_activity a WHERE a.external_id = fv_debrief_status.external_id
                                    AND a.sub_id = fv_debrief_status.sub_id
                                    AND a.id = '$flow.activity_id$')
AND activitystatustype_id = 59 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief_status -> activitystatustype_id;
fv_debrief_status -> radiostatus_id;
subgraph select {
fv_activity -> a;
a -> external_id;
fv_debrief_status -> external_id;
a -> sub_id;
fv_debrief_status -> sub_id;
a -> id;
}
fv_activity -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement428()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CASE WHEN opdrachtnummer IS NULL THEN 1
             ELSE 0
        END AS IsOpdrachtNummerLeeg
FROM    fv_activity
WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr743()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(fv_debrief.signaturedt, getdate()) AS nu, fv_debrief.signature, 1 AS def, fv_debrief.opdrachtnummer, fv_debrief.name_signature, COALESCE(fv_debrief.email, fv_contact.email) AS email, fv_debrief.send_specificatie
FROM fv_activity
INNER JOIN fv_debrief ON fv_activity.id = fv_debrief.activity_id
LEFT OUTER JOIN fv_contact ON fv_activity.contact_id = fv_contact.id
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> signaturedt;
fv_debrief -> signature;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> email;
fv_contact -> email;
fv_debrief -> send_specificatie;
fv_activity -> id;
fv_debrief -> activity_id;
fv_activity -> contact_id;
fv_contact -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement429()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE fv_debrief
SET    email = '$form.txtEmail$'
    ,send_email = 1
    ,send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END
    ,opdrachtnummer = '$form.txtOpdrachtnr$'
    ,name_signature = '$form.txtParaafNaam$'
    ,signaturedt = SUBSTRING('$form.datSig$',1,11) + SUBSTRING('$form.timeSig$',12,8)
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> signaturedt;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement430()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE fv_debrief
SET    email = '$form.txtEmail$'
    ,send_email = 1
    ,send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END
    ,opdrachtnummer = '$form.txtOpdrachtnr$'
    ,name_signature = '$form.txtParaafNaam$'
    ,signaturedt = SUBSTRING('$form.datSig$',1,11) + SUBSTRING('$form.timeSig$',12,8)
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> signaturedt;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement431()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -4, '$flow.NewStatusdt$'), 0, 150, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement432()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -3, '$flow.NewStatusdt$'), 0, 120, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement433()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET    activitystatustype_id = 120,
    maxstatusdt = DATEADD(second, -3, '$flow.NewStatusdt$')
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitystatustype_id;
fv_activity -> maxstatusdt;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement434()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id)
SELECT    '$flow.NewActivity_id$', '$flow.NewStatusdt$', 159, external_id, sub_id, $flow.herplan_naar_engineer_id$, '$flow.datum$',
    DATEADD(minute, DATEDIFF(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, $flow.tijd$, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    CASE WHEN LEN('$flow.opmerking2$') > 999 THEN SUBSTRING('$flow.opmerking2$', 0, 999) ELSE '$flow.opmerking2$' END, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id
FROM    fv_activity
WHERE    id = '$flow.activity_id$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activity -> id;
fv_activity -> maxstatusdt;
fv_activity -> activitystatustype_id;
fv_activity -> external_id;
fv_activity -> sub_id;
fv_activity -> engineer_id;
fv_activity -> planstartdt;
fv_activity -> planenddt;
fv_activity -> capability_id;
fv_activity -> causecode_id;
fv_activity -> changedt;
fv_activity -> city;
fv_activity -> zip;
fv_activity -> street;
fv_activity -> housenumber;
fv_activity -> housenumbertext;
fv_activity -> community;
fv_activity -> contact;
fv_activity -> contact_id;
fv_activity -> contract_id;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_activity -> country;
fv_activity -> criteriumstartdt;
fv_activity -> criteriumenddt;
fv_activity -> customer_id;
fv_activity -> customer_main_id;
fv_activity -> customerexternal_id;
fv_activity -> description;
fv_activity -> email;
fv_activity -> equipmentname;
fv_activity -> fax;
fv_activity -> functieplaatsnaam;
fv_activity -> historie_tekst;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_activity -> meldkamernummer;
fv_activity -> ministoringsboek;
fv_activity -> mobilephone;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> normtijd;
fv_activity -> opdrachtnummer;
fv_activity -> ordersoort_id;
fv_activity -> organisation_id;
fv_activity -> phone;
fv_activity -> serviceorder_id;
fv_activity -> aangemaakt_door_naam;
fv_activity -> activitytype_id;
fv_activity -> planner_id;
fv_activity -> planner_name;
fv_activity -> priority_id;
fv_activity -> problemcode_id;
fv_activity -> productgroep_id;
fv_activity -> region_id;
fv_activity -> seen_by_eng;
fv_activity -> serviceobject_id;
fv_activity -> serviceordernumber;
fv_activity -> solutioncode_id;
fv_activity -> state;
fv_activity -> taken;
fv_activity -> verantwoordelijk;
fv_activity -> samenvatting;
fv_activity -> notes;
fv_activity -> onderwerp;
fv_activity -> isafmeldbonvoorklantverplicht;
fv_activity -> isantidaterentoegestaan;
fv_activity -> isequipmentscannenverplicht;
fv_activity -> ishandtekeningverplicht;
fv_activity -> isnlsfbcodeverplicht;
fv_activity -> isurenspecificatieverplicht;
fv_activity -> nlsfb_id;
}
subgraph select {
flow -> herplan_naar_engineer_id;
flow -> tijd;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement435()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $flow.herplan_naar_engineer_id$, DATEADD(second, -2, '$flow.NewStatusdt$'), 0, 30, '$flow.NewActivity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
flow -> herplan_naar_engineer_id;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement436()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
SELECT    NEWID(), $flow.herplan_naar_engineer_id$, '$flow.NewStatusdt$', 0, 159, '$flow.NewActivity_id$', '$flow.opmerking$',
    CASE WHEN '$flow.reden$'='' THEN null ELSE '$flow.reden$' END
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
fv_activitystatus -> cancelnotes;
fv_activitystatus -> cancelreason_id;
}
subgraph select {
flow -> herplan_naar_engineer_id;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement437()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  CASE WHEN opdrachtnummer IS NULL THEN 1
             ELSE 0
        END AS IsOpdrachtNummerLeeg
FROM    fv_activity
WHERE id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatementQueryNr744()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COALESCE(fv_debrief.signaturedt, getdate()) AS nu, fv_debrief.signature, 1 AS def, fv_debrief.opdrachtnummer, fv_debrief.name_signature, COALESCE(fv_debrief.email, fv_contact.email) AS email, fv_debrief.send_specificatie
FROM fv_activity
INNER JOIN fv_debrief ON fv_activity.id = fv_debrief.activity_id
LEFT OUTER JOIN fv_contact ON fv_activity.contact_id = fv_contact.id
WHERE fv_activity.id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> signaturedt;
fv_debrief -> signature;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> email;
fv_contact -> email;
fv_debrief -> send_specificatie;
fv_activity -> id;
fv_debrief -> activity_id;
fv_activity -> contact_id;
fv_contact -> id;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement438()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE fv_debrief
SET    email = '$form.txtEmail$'
    ,send_email = 1
    ,send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END
    ,opdrachtnummer = '$form.txtOpdrachtnr$'
    ,name_signature = '$form.txtParaafNaam$'
    ,signaturedt = SUBSTRING('$form.datSig$',1,11) + SUBSTRING('$form.timeSig$',12,8)
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> signaturedt;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement439()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE fv_debrief
SET    email = '$form.txtEmail$'
    ,send_email = 1
    ,send_specificatie = CASE WHEN '$form.chSpec$' = 'true' THEN 1 ELSE 0 END
    ,opdrachtnummer = '$form.txtOpdrachtnr$'
    ,name_signature = '$form.txtParaafNaam$'
    ,verholpen = 0
    ,verholpendt = '$flow.verholpendt$'
    ,signaturedt = SUBSTRING('$form.datSig$',1,11) + SUBSTRING('$form.timeSig$',12,8)
WHERE activity_id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> email;
fv_debrief -> send_email;
fv_debrief -> send_specificatie;
fv_debrief -> opdrachtnummer;
fv_debrief -> name_signature;
fv_debrief -> verholpen;
fv_debrief -> verholpendt;
fv_debrief -> signaturedt;
fv_debrief -> activity_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement440()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -4, '$flow.NewStatusdt$'), 0, 150, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement441()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -3, '$flow.NewStatusdt$'), 0, 120, '$flow.activity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement442()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
UPDATE    fv_activity
SET    activitystatustype_id = 120,
    maxstatusdt = DATEADD(second, -3, '$flow.NewStatusdt$')
WHERE    id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_activity -> activitystatustype_id;
fv_activity -> maxstatusdt;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement443()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activity (id, maxstatusdt, activitystatustype_id, external_id, sub_id, engineer_id, planstartdt, planenddt,
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, normtijd, opdrachtnummer, ordersoort_id, organisation_id, phone, serviceorder_id,
    aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting, notes, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id)
SELECT    '$flow.NewActivity_id$', '$flow.NewStatusdt$', 157, external_id, sub_id, engineer_id, '$flow.datum$',
    DATEADD(minute, DATEDIFF(minute, planstartdt, planenddt), '$flow.datum$'),
    capability_id, causecode_id, changedt, city, zip, street, housenumber, housenumbertext, community, contact, contact_id, contract_id,
    contactpersoon, contactpersoon_phone, country, criteriumstartdt, criteriumenddt, customer_id, customer_main_id, customerexternal_id,
    description, email, equipmentname, fax, functieplaatsnaam, historie_tekst, melddatum, melder, melder_phone, meldkamernummer, 
    ministoringsboek, mobilephone, name, name_2, $flow.tijd$, opdrachtnummer, ordersoort_id, organisation_id, phone,
    serviceorder_id, aangemaakt_door_naam, activitytype_id, planner_id, planner_name, priority_id, problemcode_id, productgroep_id, region_id,
    seen_by_eng, serviceobject_id, serviceordernumber, solutioncode_id, state, taken, verantwoordelijk, samenvatting,
    CASE WHEN LEN('$flow.opmerking2$') > 999 THEN SUBSTRING('$flow.opmerking2$', 0, 999) ELSE '$flow.opmerking2$' END, onderwerp,
    isafmeldbonvoorklantverplicht, isantidaterentoegestaan, isequipmentscannenverplicht, ishandtekeningverplicht, isnlsfbcodeverplicht,
    isurenspecificatieverplicht, nlsfb_id
FROM    fv_activity
WHERE    id = '$flow.activity_id$' ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activity -> id;
fv_activity -> maxstatusdt;
fv_activity -> activitystatustype_id;
fv_activity -> external_id;
fv_activity -> sub_id;
fv_activity -> engineer_id;
fv_activity -> planstartdt;
fv_activity -> planenddt;
fv_activity -> capability_id;
fv_activity -> causecode_id;
fv_activity -> changedt;
fv_activity -> city;
fv_activity -> zip;
fv_activity -> street;
fv_activity -> housenumber;
fv_activity -> housenumbertext;
fv_activity -> community;
fv_activity -> contact;
fv_activity -> contact_id;
fv_activity -> contract_id;
fv_activity -> contactpersoon;
fv_activity -> contactpersoon_phone;
fv_activity -> country;
fv_activity -> criteriumstartdt;
fv_activity -> criteriumenddt;
fv_activity -> customer_id;
fv_activity -> customer_main_id;
fv_activity -> customerexternal_id;
fv_activity -> description;
fv_activity -> email;
fv_activity -> equipmentname;
fv_activity -> fax;
fv_activity -> functieplaatsnaam;
fv_activity -> historie_tekst;
fv_activity -> melddatum;
fv_activity -> melder;
fv_activity -> melder_phone;
fv_activity -> meldkamernummer;
fv_activity -> ministoringsboek;
fv_activity -> mobilephone;
fv_activity -> name;
fv_activity -> name_2;
fv_activity -> normtijd;
fv_activity -> opdrachtnummer;
fv_activity -> ordersoort_id;
fv_activity -> organisation_id;
fv_activity -> phone;
fv_activity -> serviceorder_id;
fv_activity -> aangemaakt_door_naam;
fv_activity -> activitytype_id;
fv_activity -> planner_id;
fv_activity -> planner_name;
fv_activity -> priority_id;
fv_activity -> problemcode_id;
fv_activity -> productgroep_id;
fv_activity -> region_id;
fv_activity -> seen_by_eng;
fv_activity -> serviceobject_id;
fv_activity -> serviceordernumber;
fv_activity -> solutioncode_id;
fv_activity -> state;
fv_activity -> taken;
fv_activity -> verantwoordelijk;
fv_activity -> samenvatting;
fv_activity -> notes;
fv_activity -> onderwerp;
fv_activity -> isafmeldbonvoorklantverplicht;
fv_activity -> isantidaterentoegestaan;
fv_activity -> isequipmentscannenverplicht;
fv_activity -> ishandtekeningverplicht;
fv_activity -> isnlsfbcodeverplicht;
fv_activity -> isurenspecificatieverplicht;
fv_activity -> nlsfb_id;
}
subgraph select {
flow -> tijd;
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement444()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id)
SELECT    NEWID(), $app.userid$, DATEADD(second, -2, '$flow.NewStatusdt$'), 0, 30, '$flow.NewActivity_id$'
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement445()
        {
            var statement = MacroScope.Factory.CreateStatement(@"
INSERT INTO fv_activitystatus (id, engineer_id, statusdt, radiostatus_id, activitystatustype_id, activity_id, cancelnotes, cancelreason_id)
SELECT    NEWID(), $app.userid$, '$flow.NewStatusdt$', 0, 157, '$flow.NewActivity_id$', '$flow.opmerking$',
    CASE WHEN '$flow.reden$'='' THEN null ELSE '$flow.reden$' END
FROM fv_engineer
WHERE  id = $App.UserID$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_activitystatus -> id;
fv_activitystatus -> engineer_id;
fv_activitystatus -> statusdt;
fv_activitystatus -> radiostatus_id;
fv_activitystatus -> activitystatustype_id;
fv_activitystatus -> activity_id;
fv_activitystatus -> cancelnotes;
fv_activitystatus -> cancelreason_id;
}
subgraph select {
app -> userid;
fv_engineer -> id;
App -> UserID;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement446()
        {
            var statement = MacroScope.Factory.CreateStatement(@"DELETE FROM   fv_debrief_status
WHERE         EXISTS (SELECT * FROM fv_activity a WHERE a.external_id = fv_debrief_status.external_id
                                    AND a.sub_id = fv_debrief_status.sub_id
                                    AND a.id = '$flow.activity_id$')
AND activitystatustype_id = 50 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_activity -> a;
a -> external_id;
fv_debrief_status -> external_id;
a -> sub_id;
fv_debrief_status -> sub_id;
a -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement447()
        {
            var statement = MacroScope.Factory.CreateStatement(@"UPDATE  fv_debrief_status SET activity_id = '$flow.NewActivity_id$', activitystatustype_id = 157
WHERE         EXISTS (SELECT * FROM fv_activity a WHERE a.external_id = fv_debrief_status.external_id
                                    AND a.sub_id = fv_debrief_status.sub_id
                                    AND a.id = '$flow.activity_id$')
AND activitystatustype_id = 59 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief_status -> activity_id;
fv_debrief_status -> activitystatustype_id;
subgraph select {
fv_activity -> a;
a -> external_id;
fv_debrief_status -> external_id;
a -> sub_id;
fv_debrief_status -> sub_id;
a -> id;
}
fv_activity -> activitystatustype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement448()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement449()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement450()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement451()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement452()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '$flow.activity_id$' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
fv_debrief -> vervolgactie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement453()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> labour_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement454()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE WHEN '$flow.next$' = 'Gewerkte uren detail' THEN 1 ELSE 0 END
FROM fv_engineer
WHERE id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement455()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'T' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement456()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement457()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement458()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement459()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'B' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement460()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'GO' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement461()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement462()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement463()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement464()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '$flow.activity_id$' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
fv_debrief -> vervolgactie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement465()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> labour_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement466()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and activitytype_id = 2 and '$flow.screen$' = 'R'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
fv_activity -> activitytype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement467()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and '$flow.screen$' = 'R'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement468()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> labour_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement469()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_activity where id = '$flow.activity_id$' and COALESCE(serviceordernumber,'')=''");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
fv_activity -> serviceordernumber;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement470()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'U' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement471()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'E' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement472()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'M' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement473()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'T' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement474()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement475()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and activitytype_id = 2 and '$flow.screen$' = 'A'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
fv_activity -> activitytype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement476()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and '$flow.screen$' = 'A'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement477()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement478()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement479()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'F' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement480()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement481()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'B' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement482()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement483()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement484()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement485()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'F' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement486()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement487()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement488()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'U' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement489()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'E' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement490()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'M' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement491()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'T' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement492()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement493()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and activitytype_id = 2 and '$flow.screen$' = 'A'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
fv_activity -> activitytype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement494()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and '$flow.screen$' = 'A'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement495()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'T' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement496()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement497()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement498()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement499()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'B' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement500()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'GO' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement501()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE WHEN '$flow.next$' = 'Gewerkte uren detail' THEN 1 ELSE 0 END
FROM fv_engineer
WHERE id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement502()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement503()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '$flow.activity_id$' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
fv_debrief -> vervolgactie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement504()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> labour_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement505()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement506()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement507()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and activitytype_id = 2 and '$flow.screen$' = 'R'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
fv_activity -> activitytype_id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement508()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and '$flow.screen$' = 'R'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement509()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> labour_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement510()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement511()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement512()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement513()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '$flow.activity_id$' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
fv_debrief -> vervolgactie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement514()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_labour_detail where labour_id in (select id from fv_labour where activity_id = '$flow.activity_id$' and labourstatus_id = 2 and enddt is null)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_labour_detail -> labour_id;
fv_labour -> activity_id;
fv_labour -> labourstatus_id;
fv_labour -> enddt;
}
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement515()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement516()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement517()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'F' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement518()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement519()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'B' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement520()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement521()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement522()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement523()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'F' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement524()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement525()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement526()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'U' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement527()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'E' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement528()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'M' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement529()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'T' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement530()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement531()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and '$flow.screen$' = 'A'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement532()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(engineer_id)  from fv_activity where id = '$flow.activity_id$' and '$flow.screen$' = 'F'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement533()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT CASE WHEN '$flow.next$' = 'Gewerkte uren detail' THEN 1 ELSE 0 END
FROM fv_engineer
WHERE id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement534()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'T' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement535()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement536()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$ ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement537()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement538()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'B' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement539()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'GO' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement540()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement541()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(*) from fv_debrief where activity_id = '$flow.activity_id$' and vervolgactie=1");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief -> activity_id;
fv_debrief -> vervolgactie;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement542()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(ishandtekeningverplicht, 0) AS ishandtekeningverplicht
FROM    fv_activity
WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement543()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(isafmeldbonvoorklantverplicht, 0) AS isafmeldbonvoorklantverplicht
FROM    fv_activity
WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement544()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT $form.cbVervolg$+0");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
form -> cbVervolg;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement545()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement546()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(ishandtekeningverplicht, 0) AS ishandtekeningverplicht
FROM    fv_activity
WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement547()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(isafmeldbonvoorklantverplicht, 0) AS isafmeldbonvoorklantverplicht
FROM    fv_activity
WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement548()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement549()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement550()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement551()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement552()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'F' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement553()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement554()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'B' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement555()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement556()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement557()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement558()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'F' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement559()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement560()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement561()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement562()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'P' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement563()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement564()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT  COALESCE(isafmeldbonvoorklantverplicht, 0) AS isafmeldbonvoorklantverplicht
FROM    fv_activity
WHERE   id = '$flow.activity_id$'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement565()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT activitystatustype_id FROM fv_activity WHERE id = '$flow.activity_id$'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_activity -> id;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement566()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'R' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement567()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'B' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement568()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'O' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement569()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement570()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement571()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'F' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement572()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement573()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'D' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement574()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select CASE when '$flow.screen$' = 'A' THEN 1 ELSE 0 END from fv_engineer where id = $app.userid$");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_engineer -> id;
app -> userid;
}
}
",dot.graphviz());
        }
[TestMethod]
        public void TestSelectStatement575()
        {
            var statement = MacroScope.Factory.CreateStatement(@"SELECT COUNT(0) AS AANTAL FROM fv_version_clientdb WHERE clientdb_date >= '2012-5-22'
");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_version_clientdb -> clientdb_date;
}
}
",dot.graphviz());
        }
        /*[TestMethod]
        public void TestMethod1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"insert into fv_labour (id, engineer_id, labourstatus_id, startdt, rostartdt, verifydt, radiostatus_id, is_modified) select newid(), 4, 1, getdate(), '02/20/2012 18:55:00', '02/20/2012 18:55:00', 0, 0
from fv_engineer where id = 4
and not exists (select id from fv_labour where labourstatus_id = 1 and engineer_id = 4)");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph insert {
fv_labour -> id;
fv_labour -> engineer_id;
fv_labour -> labourstatus_id;
fv_labour -> startdt;
fv_labour -> rostartdt;
fv_labour -> verifydt;
fv_labour -> radiostatus_id;
fv_labour -> is_modified;
}
subgraph select {
fv_engineer -> id;
subgraph subselect {
fv_labour -> id;
fv_labour -> labourstatus_id;
fv_labour -> engineer_id;
}
}
}
", dot.graphviz());
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
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph update {
fv_debrief -> voldaan_contant;
fv_debrief -> voldaan_pin;
fv_debrief -> voldaan_totaal;
fv_debrief -> verifydt;
fv_debrief -> activity_id;
}
}
", dot.graphviz());
        }

        [TestMethod]
        public void TestSelectStatement358()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as aantal
from information_schema.columns
where table_name = 'fv_debrief_status'
and column_name = 'rostatusdt'");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
information_schema.columns -> table_name;
table_name -> fv_debrief_status;
information_schema.columns -> column_name;
column_name -> rostatusdt;
}
}
", dot.graphviz());
        }

        [TestMethod]
        public void TestSelectStatement446()
        {
            var statement = MacroScope.Factory.CreateStatement(@"delete from   fv_debrief_status
where         exists (select * from fv_activity a where a.external_id = fv_debrief_status.external_id
                                    and a.sub_id = fv_debrief_status.sub_id
                                    and a.id = '00000000-0000-0000-0000-000000000000')
and activitystatustype_id = 50 ");
            statement.Traverse(MacroScope.Factory.CreateTailor(MacroScope.Factory.SqlServerCEProvider));
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph delete {
subgraph select {
fv_activity -> a;
a -> external_id;
fv_debrief_status -> external_id;
a -> sub_id;
fv_debrief_status -> sub_id;
a -> id;
}
fv_debrief_status -> activitystatustype_id;
}
}
", dot.graphviz());
        }
        [TestMethod]
        public void TestSelectStatement1()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as isfunctiehersteld from fv_debrief_status d
where d.activity_id in ( select a.id from fv_activity a
inner join fv_activity b on
a.external_id = b.external_id
and a.sub_id = b.sub_id
where b.id = '00000000-0000-0000-0000-000000000000')
and d.activitystatustype_id = 59");
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> d;
d -> activity_id;
subgraph subselect {
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
a -> id;
b -> id;
}
d -> activitystatustype_id;
}
}
", dot.graphviz());
        }

        [TestMethod]
        public void TestSelectStatementSmokeTest()
        {
            var statement = MacroScope.Factory.CreateStatement(@"select count(0) as isfunctiehersteld from fv_debrief_status d
where d.activity_id in ( select a.id from fv_activity a
inner join fv_activity b on
a.external_id = b.external_id
and a.sub_id = b.sub_id
where b.id = '00000000-0000-0000-0000-000000000000')
and d.activitystatustype_id = 59");
            var dot = new Dot();
            statement.Traverse(dot);
            Assert.AreEqual(@"digraph dbObjects {
subgraph select {
fv_debrief_status -> d;
d -> activity_id;
subgraph subselect {
a -> id;
fv_activity -> a;
fv_activity -> b;
a -> external_id;
b -> external_id;
a -> sub_id;
b -> sub_id;
a -> id;
b -> id;
}
d -> activitystatustype_id;
}
}
", dot.graphviz());
        }*/
    }


}
