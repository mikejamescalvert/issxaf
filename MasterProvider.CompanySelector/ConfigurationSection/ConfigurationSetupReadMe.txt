Add the following to "configuration.configSections":

    <section name="multiCompanySettings" type="MultiCompanyERP.Module.MultiCompanySettings, MultiCompanyERP.Module" />

Add the following after the "configuration.configSections" section, adding the names of the appropriate connection strings:

  <multiCompanySettings>
    <multiCompanyInfo>
      <add eRPConnectionStringName="" companyConnectionStringName="" />
    </multiCompanyInfo>
  </multiCompanySettings>

---
The application uses the ERP connection string name to find the connection to the ERP database and it uses the company connection string name to find the connection to the company-specific application databases. 

In both cases, the application replaces the initial catalog, depending on the company selected.