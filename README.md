RdfstoreNet
=========

RdfstoreNet is a .NET library for interacting with the Rdfstore API developed and maintained by Open Physiology. Rdfstore API is a metadata wrapper based on templates serving as a messenger between SPARQL endpoint and end-user, obviating the need to learn complicated SPARQL syntax. The RdfstoreNet library is mainly comprised of "endpoint" and "model" classes. Each endpoint class aligns itself with a subject in the Rdfstore API (e.g. templates, triples, etc.), while model classes are strongly-typed representations of the data flow to and from these endpoints. Each endpoint implements one or more operations that affect the associated models (retrieval, creation, deletion). For the sake of flexibility, these operations are available in synchronous and asynchronous flavors.

### Dependencies:
* [RestSharp](http://restsharp.org/)
* [Moq](http://code.google.com/p/moq/)

For full documentation of the Open Physiology Rdfstore API, visit http://open-physiology.org/rdfstore/doc.html <br>
The Open Physiology Rdfstore API is open source as well https://github.com/open-physiology/rdfstore

## Examples
### Create triple using the triple endpoint
```csharp
var triple = new TripleModel()
{
    Subject = "http://virtualskeleton.ch/api/objects/1",
    Predicate = "http://virtualskeleton.ch/ont/predicates/has_anatomical_region",
    Object = "http://purl.obolibrary.org/obo/FMA_11089"
};
var tripleEndpoint = new TripleEndpoint(accessManager);
tripleEndpoint.CreateTriple(triple);
```

### Create triple using the template endpoint
```csharp
string templateName = "Insert_Triple_(Fuseki)";
var triple = new TripleModel()
{
    Subject = "http://virtualskeleton.ch/api/objects/1",
    Predicate = "http://virtualskeleton.ch/ont/predicates/has_anatomical_region",
    Object = "http://purl.obolibrary.org/obo/FMA_11089"
};
var templateEndpoint = new TemplateEndpoint(accessManager);
templateEndpoint.CallTemplate(templateName, triple.Subject, triple.Predicate, triple.Object);
```

### Get resources
```csharp
string templateName = "Get_Resources";
var templateEndpoint = new TemplateEndpoint(accessManager);
var response = templateEndpoint.CallTemplate(templateName);
```