# NodusOperandi
For want of a better name, NodusOperandi is an open-source control system intended to integrate and operate networks
comprising devices from differing manufacturers to make them interoperable and function together with ease.

## To-Do list
[X] Core NancyFx code
[ ] Dashboard (sort of done)
[ ] Implement SQLite database storage
[ ] Implement EF6 and replace SQLite with it (Need to work out runtime issues w/ SQLite and EF6 first, though)
[ ] List active devices / IPs on the network
[ ] Multiple user support
[ ] Module permissions
[ ] Plugin hooks
[ ] Shared to-do list as a plugin module (with an option to require a PIN to view it)
[ ] IFTTT API integration and similar
[ ] Sensor input triggers (eg, sensor value < X, power usage > X, movement detected here, door open there, etc)
[ ] Security audit panel (do a scan of all network devices to see what's running what)

### Panel tables
[ ] Consolidate table rendering code into one place
[ ] Implement plugin API / delegates on table renderer to allow plugins to register action buttons (eg, the toggle outlet buttons for the Ubiquiti mFi hardware)

