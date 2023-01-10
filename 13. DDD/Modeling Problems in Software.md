# Modeling Problems in Software


## Breaking up the veterinary office domain

- Planning Ahead to Learn About the Domain
- Goals for Learning About the Domain
  - Understand client’s business
  - Identify processes beyond project scope
  - Look for subdomains we should include
  - Look for subdomains we can ignore
- Conversation with a Domain Expert: Exploring the Domain and Its Subdomains
  - Learning about the Complete Domain
    - **Patient scheduling**
    - **Owner and pet data management**
    - Billing (External?)
    - **Surgery scheduling**
    - **Office visit data collection**
    - Sales and Inventory
    - Lab testing (schedule, results, bill)
    - Prescriptions
    - Staff scheduling
    - CMS (External?)
  - Some of the Identified Subdomains
    - Staff
    - Accounting
    - Client and patient records
    - Visit records
    - Appointment scheduling
    - Sales
- Conversation with a Domain Expert: Exploring the Scheduling Subdomain
  - Continued Deep Collaboration with Domain Experts
  - Notes from Our Conversation
    - Clients (people) schedule appointments for patients (pets)
    - Appointments may be either office visits or surgeries
    - Office visits may be an exam requiring a doctor, or a tech visit
    - Office visits depend on exam room availability
    - Surgeries depend on O/R and recovery space availability, and can involve different kinds of procedures
    - Different appointment types and procedures require different staff

## The importance of the domain experts



## A play! (Discovering the domain )



## Core elements of a domain model



## Subdomains and bounded contexts



## That ubiquitous term: ubiquitous language