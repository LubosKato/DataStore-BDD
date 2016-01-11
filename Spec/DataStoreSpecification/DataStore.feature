Feature: DataStore
•	List Data
	o	Ascend Snapshots
	o	Custom Snashots
•	Create Snapshot
•	Upload Custom Data
•	Download Data


@Get_List_of_Ascend_Snapshots
Scenario: There are Ascend Snapshots in system
	Given There are Ascend Snapshots in system
	When I retrieve all Ascend Snapshots for my Team
	Then I get all Ascend Snapshots for my Team

@Get_List_of_Custom_Snapshots
Scenario: There are Custom Snapshots in system
	Given There are Custom Snapshots in system
	When I retrieve all Custom Snapshots for my Team
	Then I get all Custom Snapshots for my Team
