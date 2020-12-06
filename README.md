# xml-parser

This is an API solution that has two endpoints to parse xml messages and return the json content for that xml.


## Clean Architecture pattern is used to build this solution along with the following technologies :
 * .Net Core 5
 * CQRS with MediatR
 * API inputs validated using FluentValidator
 * Domain - Dto mapping using AutoMapper


## This solution solves the following problem :

### Scenario
A client has a new requirement to import data from text received via email.
The data will either be:
* Embedded as ‘islands’ of XML-like content
* Marked up using XML style opening and closing tags


### The following text illustrates this:
`Hi Yvaine,
Please create an expense claim for the below. Relevant details are marked up as requested…
<expense>
<cost_centre>DEV002</cost_centre>
<total>1024.01</total>
<payment_method>personal card</payment_method>
</expense>`

`From: Ivan Castle Sent: Friday, 16 February 2018 10:32 AM
To: Antoine Lloyd <Antoine.Lloyd@example.com>
Subject: test
Hi Antoine,
Please create a reservation at the <vendor>Viaduct Steakhouse</vendor> our
<description>development team’s project end celebration dinner</description> on <date>Tuesday
27 April 2017</date>. We expect to arrive around 7.15pm. Approximately 12 people but I’ll
confirm exact numbers closer to the day.
Regards,
Ivan`

### Write a REST service that:
* Accepts a block of text
* Extracts the relevant data
* Calculate the GST and total excluding GST based on the extracted <total> (it includes GST)
* Makes the extracted and calculated data available to the service’s client
 
### Failure Conditions
The following failure conditions should be detected and made available to the client:
* Opening tags that have no corresponding closing tag. In this case the whole message should be rejected.
* Missing <total>. In this case the whole message should be rejected.
* Missing <cost_centre>. In this case the ‘cost centre’ field in the output should be defaulted to ‘UNKNOWN’.
