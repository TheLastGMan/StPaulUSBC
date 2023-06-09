
INSERT INTO [STPUSBC_Role] ([RowGuid], [Name])
	VALUES
	('12d976d0-a05d-46e7-8498-3b139445b4b1', 'LinkEditor'),--
	('12d976d0-a05d-46e7-8498-3b139445b4b2', 'UserAdmin'),
	('12d976d0-a05d-46e7-8498-3b139445b4b3', 'ContentEditor'),--
	('12d976d0-a05d-46e7-8498-3b139445b4b4', 'HallOFame'),
	('12d976d0-a05d-46e7-8498-3b139445b4b5', 'Honor'),
	('12d976d0-a05d-46e7-8498-3b139445b4b6', 'Board'),
	('12d976d0-a05d-46e7-8498-3b139445b4b7', 'Award'),
	('12d976d0-a05d-46e7-8498-3b139445b4b8', 'Tournament'),
	('12d976d0-a05d-46e7-8498-3b139445b4b9', 'Localizer'),
	('12d976d0-a05d-46e7-8498-3b139445b4c0', 'ScoreLoader')
GO

INSERT INTO [STPUSBC_User] ([FirstName], [LastName], 
						[Username], [Password], 
						[active], [login_count], [created_utc], [last_login_utc])
	VALUES 
		('Default', 'Admin', 'admin', '49ikn+55xsvlRfTieP/wFA==', 1, 0, '1/1/2013', '1/1/2013')
GO

INSERT INTO [STPUSBC_UserRole] ([UserId], [RoleId])
	VALUES 
		(1, 1),
		(1, 2),
		(1, 3),
		(1, 4),
		(1, 5),
		(1, 6),
		(1, 7),
		(1, 8),
		(1, 9),
		(1, 10)
GO

INSERT INTO [STPUSBC_HomeLink] ([DisplayText], [View], [Controller], [Visible], [Order])
	VALUES
	('Home','Index','Home', 1, 1),
	('Tournaments','Index','Tournament', 1, 2),
	('Honor Scores','Index','HonorScore', 1, 3),
	('Hall of Fame','Index','HallOfFame', 1, 4),
	('Board of Directors','Index','Board', 1, 5),
	('Award Form', 'Index', 'Award', 1, 6),
	('Site Map', 'Index', 'SiteMap', 1, 7),
	('Season Averages', 'Index', 'SeasonAverage', 1, 8),
	('RSS Feeds', 'Index', 'RSS', 0, 9)
GO

--Insert Widgets for the pages
INSERT INTO [STPUSBC_Topic] ([seo], [content], [active], 
							[createdutc], [updatedutc], [TopicTypeId])
	VALUES
	('home_index', 'Home Page Info', 1, '1/1/2012', '1/1/2012', 1),
	('tournament_index', 'tournament write up', 1, '1/1/2012', '1/1/2012', 1),
	('honorscore_index', 'honor score write up', 1, '1/1/2012', '1/1/2012', 1),
	('honorscore_scoreviewgame', 'Honor Score Game WriteUp', 1, '1/1/2012', '1/1/2012', 1),
	('honorscore_scoreviewseries', 'Honor Score Series WriteUp', 1, '1/1/2012', '1/1/2012', 1),
	('halloffame_index', 'Hall of Fame WriteUp', 1, '1/1/2012', '1/1/2012', 1),
	('board_index', 'Board WriteUp (links, etc.)', 1, '1/1/2012', '1/1/2012', 1),
	('account_login', 'Account Info here', 1, '1/1/2012', '1/1/2012', 1),
	('award_index', 'Award Info Here', 1, '1/1/2012', '1/1/2012', 1),
	('award_info_header','award header', 1, '1/1/2012', '1/1/2012', 1),
	('award_info_footer','award footer', 1, '1/1/2012', '1/1/2012', 1),
	('award_awardformsuccess','Thank You', 1, '1/1/2012', '1/1/2012', 1)
GO

DELETE FROM [STPUSBC_Localization]
INSERT INTO [STPUSBC_Localization] ([Key], [Value])
	VALUES
('Account.ProfileView.FirstName', 'First Name'),
('Account.ProfileView.LastName', 'Last Name'),
('Account.ProfileView.UserName', 'Username'),
('Account.ProfileView.LastLogin', 'Last Login'),
('Account.ProfileView.Created', 'Created'),
('Account.ProfileView.Active', 'Active'),
('Account.RoleInfo.RoleTitle', 'Role'),
('Account.RoleInfo.StatusTitle', 'Status'),
('Account.LogIn.Title', 'Log In'),
('Account.LogIn.UserName', 'Username'),
('Account.LogIn.Password', 'Password'),
('Account.LogIn.LogInSubmit', 'Log In'),
('Account.Profile.Info', 'Info'),
('Account.Profile.Access', 'Access'),
('Account.Manage.Title', 'Manage Users'),
('Account.Manage.NameTitle', 'Name'),
('Account.Manage.UserNameTitle', 'UserName'),
('Account.Manage.LockUnlockTitle', ''),
('Account.Manage.ActivationTitle', ''),
('Account.Manage.LastLoginTitle', 'Last Login'),
('Account.Manage.EditTitle', ''),
('Account.Manage.EditSubmit', 'Edit'),
('Account.Manage.LockUnlock.Lock', 'Lock'),
('Account.Manage.LockUnlock.UnLock', 'UnLock'),
('Account.Manage.Activation.Activate', 'Activate'),
('Account.Manage.Activation.DeActivate', 'DeActivate'),
('Account.Edit.Title', 'Edit {0}'),
('Account.Edit.Profile', 'Profile'),
('Account.Edit.Roles', 'Role Mappings'),
('Account.Edit.UpdateSubmit', 'Update'),
('Account.Edit.CancelSubmit', 'Cancel'),
('Account.Edit.FirstName', 'First Name'),
('Account.Edit.LastName', 'Last Name'),
('Account.Edit.Username', 'UserName'),
('Account.Edit.password', 'Password'),
('Account.Edit.active', 'Active'),
('Account.Create.Title', 'Create Profile'),
('Account.Create.Profile', 'Profile'),
('Account.Create.Roles', 'Role Mappings'),
('Account.Create.UpdateSubmit', 'Update'),
('Account.Create.CancelSubmit', 'Cancel'),
('Account.Create.FirstName', 'First Name'),
('Account.Create.LastName', 'Last Name'),
('Account.Create.Username', 'UserName'),
('Account.Create.password', 'Password'),
('Account.Create.active', 'Active'),
('Account.Manage.Create', 'Create'),
('Account.ProfileView.Password', 'Password'),
('Account.ProfileView.Password.Submit', 'Update'),
('Account.LogIn.UserName.Error', 'Username is Required'),
('Account.LogIn.PassWord.Error', 'Password is Required'),
('Account.LogIn.UserName.Invalid', 'Username must be at least 5 characters'),
('Account.Login.Password.Invalid', 'Password must be at least 5 characters'),
('Award.Index.Center', 'Center'),
('Award.Index.League', 'League'),
('Award.Index.BowlerName', 'Bowler Name'),
('Award.Index.USBCID', 'USBC ID'),
('Award.Index.DateBowled', 'Date Bowled'),
('Award.Index.BowlerType', 'Bowler Type'),
('Award.Index.Game1', 'Gm 1'),
('Award.Index.Game2', 'Gm 2'),
('Award.Index.Game3', 'Gm 3'),
('Award.Index.Series', 'Series'),
('Award.Index.Achievement', 'Achievements'),
('Award.Index.LocalAchievement', 'Local Awards'),
('Award.Index.AwardChoice', 'Award Choice'),
('Award.Index.Title', 'Award Form'),
('Award.Index.BowlerAverage', 'Average'),
('Award.Index.BowlerGames', 'Games'),
('Award.Index.SecretaryName', 'Secretary Name'),
('Award.Index.SecretaryEmail', 'Secretary Email'),
('Award.Index.SecretaryPin', 'Secretary Pin'),
('Award.Index.SecretaryPhone', 'Secretary Phone'),
('Award.Index.SaveSubmit', 'Submit'),
('Award.Index.ResetSubmit', 'Clear'),
('Award.AwardHeader.Award', 'Awards'),
('Award.AwardHeader.AwardType', 'Types'),
('Award.AwardHeader.AwardOption', 'Options'),
('Award.AwardHeader.AwardOptionType', 'Option Types'),
('Award.Manage.Title', 'Award Forms'),
('Award.AwardType.DescriptionTitle', 'Description'),
('Award.AwardType.UpdateTitle', ''),
('Award.AwardType.UpdateSubmit', 'Update'),
('Award.AwardType.Title', 'Award Type'),
('Award.AwardDivision.DescriptionTitle', 'Description'),
('Award.AwardDivision.UpdateTitle', ''),
('Award.AwardDivision.UpdateSubmit', 'Update'),
('Award.AwardDivision.Title', 'Award Type'),
('Award.AwardOption.Title', 'Manage Achievements'),
('Award.AwardOption.AwardTitle', 'Award'),
('Award.AwardOption.DivisionTitle', 'Division'),
('Award.AwardOption.TypeTitle', 'Type'),
('Award.AwardOption.AverageTitle', '<= Average'),
('Award.AwardOption.VisibleTitle', 'Show'),
('Award.AwardOption.UpdateTitle', ''),
('Award.AwardOption.UpdateSubmit', 'Update'),
('Award.AwardOption.CreateSubmit', 'Save'),
('Award.AwardOption.DeleteTitle', ''),
('Award.AwardOption.DeleteSubmit', 'Delete'),
('Award.AwardOption.Delete.Exists', 'Option Has Awards'),
('Award.Index.USBCAward.Submit', 'Add USBC Award'),
('Award.Index.LocalAward.Submit', 'Add Local Award'),
('Award.Manage.BowlerNameTitle', 'Bowler'),
('Award.Manage.USBCIDTitle', 'USBC ID'),
('Award.Manage.SecretaryName', 'Secretary'),
('Award.Manage.SecretaryPin', 'PIN'),
('Award.Manage.AddedUTCTitle', 'Added'),
('Award.Manage.PrintTitle', ''),
('Award.AwardModel.Center.Error', 'Center has to be less than 64 characters'),
('Award.AwardModel.League.Error', 'League has to be less than 64 characters'),
('Award.AwardModel.BowlerName.Error', 'Bowler Name has to be less than 64 characters'),
('Award.AwardModel.USBCID.Error', 'USBC ID has to be less than 32 characters'),
('Award.AwardModel.USBCID.Invalid', 'Invalid USBC ID'),
('Award.AwardModel.BowlerAverage.Error', 'Average Must be between 0 and 300'),
('Award.AwardModel.BowlerGames.Error', 'Games Must be between 1 and 255'),
('Award.AwardModel.Game1.Error', 'Game 1 Must be between 0 and 300'),
('Award.AwardModel.Game2.Error', 'Game 2 Must be between 0 and 300'),
('Award.AwardModel.Game3.Error', 'Game 3 Must be between 0 and 300'),
('Award.AwardModel.Series.Error', 'Series Must be between 1 and 900'),
('Award.AwardModel.SecretaryPin.Error', 'PIN has to be less than 32 characters'),
('Award.AwardModel.SecretaryName.Error', 'Secretary Name has to be less than 64 characters'),
('Award.AwardModel.SecretaryPhone.Invalid', 'Invalid Phone Number'),
('Award.AwardModel.SecretaryEmail.Invalid', 'Secretary Email has to be less than 128 characters'),
('Award.AwardModel.DateBowled.Error', 'Please Enter a Valid Date'),
('Award.Index.LoadAwardSubmit', 'Load Valid Awards'),
('Award.PrintAward.Title', '{BowlerName}s Awards For {DateBowled}'),
('Award.Index.AwardCount.Error', 'Please Select at least 1 award'),
('Award.AwardForm.SecretaryName.Placeholder', 'Name'),
('Award.AwardForm.SecretaryEmail.Placeholder', 'Email'),
('Award.AwardForm.SecretaryPin.Placeholder', 'PIN'),
('Award.AwardForm.SecretaryPhone.Placeholder', '123-456-7890'),
('Award.AwardForm.Center.Placeholder', 'Bowling Center'),
('Award.AwardForm.League.Placeholder', 'League'),
('Award.AwardForm.BowlerName.Placeholder', 'Bowlers Name'),
('Award.AwardForm.USBCID.Placeholder', '3-14159'),
('Award.Manage.ArchiveTitle', ''),
('Award.Manage.ArchiveSubmit', 'Archive'),
('Award.Manage.Print', 'Print'),
('Board.BoardHeader.BoardMember', 'Members'),
('Board.BoardHeader.BoardPosition', 'Positions'),
('Board.Create.Title', 'Create Board Member'),
('Board.Create.FirstName', 'First Name'),
('Board.Create.LastName', 'Last Name'),
('Board.Create.BoardPosition', 'Position'),
('Board.Create.Visible', 'Show'),
('Board.Create.TermStart', 'Term Start'),
('Board.Create.TermEnd', 'Term End'),
('Board.Create.Create', 'Save'),
('Board.Create.Cancel', 'Cancel'),
('Board.Delete.ConfirmText', 'Are You Sure?'),
('Board.Delete.Yes', 'Yes'),
('Board.Delete.No', 'No'),
('Board.Edit.Title', 'Edit Board Member'),
('Board.Edit.FirstName', 'First Name'),
('Board.Edit.LastName', 'Last Name'),
('Board.Edit.BoardPosition', 'Position'),
('Board.Edit.Visible', 'Show'),
('Board.Edit.TermStart', 'Term Start'),
('Board.Edit.TermEnd', 'Term End'),
('Board.Edit.Edit', 'Update'),
('Board.Edit.Cancel', 'Cancel'),
('Board.Index.Title', 'Board of Directors'),
('Board.Index.Name', 'Name'),
('Board.Index.Term', 'Term'),
('Board.Index.NoData', 'No Board Members Found'),
('Board.Manage.Title', 'Manage Board Members'),
('Board.Manage.NameTitle', 'Name'),
('Board.Manage.BoardPositionTitle', 'Position'),
('Board.Manage.TermStartTitle', 'Term Start'),
('Board.Manage.TermEndTitle', 'Term End'),
('Board.Manage.AddedTitle', 'Added'),
('Board.Manage.EditTitle', ''),
('Board.Manage.UpdateTitle', ''),
('Board.Manage.DeleteTitle', ''),
('Board.Manage.Visible.True', 'Hide'),
('Board.Manage.Visible.False', 'Show'),
('Board.Manage.EditSubmit', 'Edit'),
('Board.Manage.DeleteSubmit', 'Delete'),
('Board.ManagePosition.Title', 'Manage Board Positions'),
('Board.ManagePosition.DescriptionTitle', 'Title'),
('Board.ManagePosition.UpdateTitle', ''),
('Board.ManagePosition.VisibleTitle', 'Show'),
('Board.ManagePosition.OrderTitle', 'Move'),
('Board.ManagePosition.DeleteTitle', ''),
('Board.ManagePosition.CreateSubmit', 'Create'),
('Board.ManagePosition.ResetSubmit', 'Clear'),
('Board.ManagePosition.UpdateSubmit', 'Update'),
('Board.ManagePosition.DeleteSubmit', 'Delete'),
('Board.ManagePosition.Delete.Active', 'Position Has Members'),
('Board.ManagePosition.Move.Up', 'Up'),
('Board.ManagePosition.Move.Down', 'Down'),
('Board.ManagePosition.Visible.True', 'Hide'),
('Board.ManagePosition.Visible.False', 'Show'),
('Board.Manage.CreateSubmit', 'Create'),
('Board.Manage.FirstName.Required', 'First Name must be less than 64 characters'),
('Board.Manage.LastName.Required', 'Last Name must be less than 64 characters'),
('Board.History.TermStart.Invalid', 'Starting Term invalid'),
('Board.History.TermEnd.Invalid', 'Ending Term invalid'),
('Board.Position.Description.Required', 'Description must be less than 64 characters'),
('Board.Manage.FirstName.Placeholder', 'First Name'),
('Board.Manage.LastName.Placeholder', 'Last Name'),
('Board.Position.Description.Placeholder', ''),
('Board.BoardHistory.UpdateDeleteTitle', ''),
('Board.BoardHistory.UpdateSubmit', 'Update'),
('Board.BoardHistory.DeleteSubmit', 'Delete'),
('Board.BoardHistory.CreateSubmit', 'Create'),
('Board.BoardHistory.BoardPosition', ''),
('Board.BoardHistory.TermStart', 'Starting Term'),
('Board.BoardHistory.TermEnd', 'Ending Term'),
('Common.AdminLinks.Title', 'Admin'),
('Common.ExtLink.Title', 'Link'),
('Common.Links.Title', 'Navigation'),
('Common.LastUpdated.Text', 'Last Updated'),
('HallOfFame.HOFHeader.HallOfFame', 'Halll Of Fame'),
('HallOfFame.HOFHeader.RecognitionType', 'Recognition Type'),
('HallOfFame.Create.Title', 'Create Hall of Famer'),
('HallOfFame.Create.FirstName', 'First Name'),
('HallOfFame.Create.LastName', 'Last Name'),
('HallOfFame.Create.RecognitionType', 'Recognition'),
('HallOfFame.Create.USBCID', 'USBC ID'),
('HallOfFame.Create.Deceased', 'Deceased'),
('HallOfFame.Create.Display', 'Show'),
('HallOfFame.Create.Achieved', 'Achieved'),
('HallOfFame.Create.ProfileImage', 'Picture'),
('HallOfFame.Create.WriteUpTitle', 'Write Up'),
('HallOfFame.Create.CreateSubmit', 'Save'),
('HallOfFame.Create.CancelSubmit', 'Cancel'),
('HallOfFame.Delete.ConfirmText', 'Are You Sure?'),
('HallOfFame.Delete.Delete.Yes', 'Yes'),
('HallOfFame.Delete.Delete.No', 'No'),
('HallOfFame.Edit.Title', 'Edit {0}'),
('HallOfFame.Edit.FirstName', 'First Name'),
('HallOfFame.Edit.LastName', 'Last Name'),
('HallOfFame.Edit.RecognitionType', 'Recognition'),
('HallOfFame.Edit.USBCID', 'USBC ID'),
('HallOfFame.Edit.Deceased', 'Deceased'),
('HallOfFame.Edit.Display', 'Show'),
('HallOfFame.Edit.Achieved', 'Achieved'),
('HallOfFame.Edit.ProfileImage', 'Picture'),
('HallOfFame.Edit.ProfileImage.Info', 'Images will be scaled down to a height of 200px'),
('HallOfFame.Edit.WriteUpTitle', 'Write Up'),
('HallOfFame.Edit.SaveSubmit', 'Save'),
('HallOfFame.Edit.CancelSubmit', 'Cancel'),
('HallOfFame.Index.Title', 'Hall Of Fame'),
('HallOfFame.Index.NameTitle', 'Name'),
('HallOfFame.Index.AchievedTitle', 'Achieved'),
('HallOfFame.Index.RecognitionTitle', 'Recognition'),
('HallOfFame.Manage.Title', 'Manage Hall Of Fame'),
('HallOfFame.Manage.NameTitle', 'Name'),
('HallOfFame.Manage.DeceasedTitle', 'Deceased'),
('HallOfFame.Manage.AchievedTitle', 'Achieved'),
('HallOfFame.Manage.RecognitionTitle', 'Recognition'),
('HallOfFame.Manage.VisibleTitle', ''),
('HallOfFame.Manage.Visible.Yes', 'Hide'),
('HallOfFame.Manage.Visible.No', 'Show'),
('HallOfFame.Manage.EditTitle', ''),
('HallOfFame.Manage.EditSubmit', 'Edit'),
('HallOfFame.Manage.DeleteTitle', ''),
('HallOfFame.Manage.DeleteSubmit', 'Delete'),
('HallOfFame.ManageType.Title', 'Manage Type'),
('HallOfFame.ManageType.DescriptionTitle', 'Description'),
('HallOfFame.ManageType.DisplayTitle', 'Show'),
('HallOfFame.ManageType.UpdateTitle', ''),
('HallOfFame.ManageType.SaveSubmit', 'Save'),
('HallOfFame.ManageType.ResetSubmit', 'Reset'),
('HallOfFame.ManageType.UpdateTitle', ''),
('HallOfFame.ManageType.UpdateSubmit', 'Update'),
('HallOfFame.ManageType.VisibleTitle', ''),
('HallOfFame.ManageType.Visible.Yes', 'Hide'),
('HallOfFame.ManageType.Visible.No', 'Show'),
('HallOfFame.ManageType.DeleteTitle', ''),
('HallOfFame.ManageType.DeleteSubmit', 'Delete'),
('HallOfFame.Profile.NotFound', 'Hall of Fame Profile Not Found'),
('HallOfFame.Profile.Deceased', '(Deceased)'),
('HallOfFame.Manage.CreateSubmit', 'Create'),
('HallOfFame.ManageType.ClearSubmit', 'Reset'),
('HonorScore.ManageHeader.Score', 'Scores'),
('HonorScore.ManageHeader.Category', 'Categories'),
('HonorScore.ManageHeader.Type', 'Types'),
('HonorScore.ScoreHeader.AllSubmit', 'All'),
('HonorScore.DeleteView.ConfirmText', 'Are You Sure?'),
('HonorScore.DeleteView.Delete.Yes', 'Yes'),
('HonorScore.DeleteView.Delete.No', 'No'),
('HonorScore.HonorCreate.Title', 'Create Honor Score'),
('HonorScore.HonorCreate.FirstName', 'First Name'),
('HonorScore.HonorCreate.LastName', 'Last Name'),
('HonorScore.HonorCreate.HonorType', 'Type'),
('HonorScore.HonorCreate.HonorCategory', 'Category'),
('HonorScore.HonorCreate.Game1', 'Game 1'),
('HonorScore.HonorCreate.Game2', 'Game 2'),
('HonorScore.HonorCreate.Game3', 'Game 3'),
('HonorScore.HonorCreate.Series', 'Series'),
('HonorScore.HonorCreate.Achieved', 'Achieved'),
('HonorScore.HonorCreate.SaveSubmit', 'Save'),
('HonorScore.HonorCreate.CancelSubmit', 'Cancel'),
('HonorScore.HonorEdit.Title', 'Edit Honor Score ({0})'),
('HonorScore.HonorEdit.FirstName', 'First Name'),
('HonorScore.HonorEdit.LastName', 'Last Name'),
('HonorScore.HonorEdit.HonorType', 'Type'),
('HonorScore.HonorEdit.HonorCategory', 'Category'),
('HonorScore.HonorEdit.Game1', 'Game 1'),
('HonorScore.HonorEdit.Game2', 'Game 2'),
('HonorScore.HonorEdit.Game3', 'Game 3'),
('HonorScore.HonorEdit.Series', 'Series'),
('HonorScore.HonorEdit.Achieved', 'Achieved'),
('HonorScore.HonorEdit.Added', 'Added'),
('HonorScore.HonorEdit.SaveSubmit', 'Save'),
('HonorScore.HonorEdit.CancelSubmit', 'Cancel'),
('HonorScore.Index.Title', 'Honor Scores'),
('HonorScore.Index.NoHonorCategory', 'No Honor Category Found'),
('HonorScore.Index.NoHonorScores', 'No Honor Types Found'),
('HonorScore.Manage.Title', 'Manage Honor Scores'),
('HonorScore.Manage.CreateSubmit', 'Create'),
('HonorScore.Manage.HonorTypeTitle', 'Type'),
('HonorScore.Manage.HonorCategoryTitle', 'Category'),
('HonorScore.Manage.NameTitle', 'Name'),
('HonorScore.Manage.AchievedTitle', ''),
('HonorScore.Manage.EditTitle', ''),
('HonorScore.Manage.DeleteTitle', ''),
('HonorScore.Manage.EditSubmit', 'Edit'),
('HonorScore.Manage.DeleteSubmit', 'Delete'),
('HonorScore.Manage.NoData', 'No Honor Scores Found'),
('HonorScore.ManageCategory.Title', 'Manage Honor Categories'),
('HonorScore.ManageCategory.DescriptionTitle', 'Description'),
('HonorScore.ManageCategory.SEOTitle', 'Short URL'),
('HonorScore.ManageCategory.Info', 'If the {Short Url} field ends with an "S", it will display the [Series View] which contains the 3 game along with the series info plus the [Game view] info.<br/>otherwise, it will display the [Game View] that only contains their name and achievement date.'),
('HonorScore.ManageCategory.SaveTitle', ''),
('HonorScore.ManageCategory.OrderTitle', 'Move'),
('HonorScore.ManageCategory.DeleteTitle', ''),
('HonorScore.ManageCategory.SaveSubmit', 'Save'),
('HonorScore.ManageCategory.ResetSubmit', 'Clear'),
('HonorScore.ManageCategory.UpdateSubmit', 'Update'),
('HonorScore.ManageCategory.Move.Up', 'Up'),
('HonorScore.ManageCategory.Move.Down', 'Down'),
('HonorScore.ManageType.Title', 'Manage Honor Types'),
('HonorScore.ManageType.Info', '<ul><li>Short URL must be unique</li><li>An Honor Type will be DeActivated (red background color) if there are scores left under the Type</li><li>When No scores are left for the Type, it can be deleted</li></ul>'),
('HonorScore.ManageType.DescriptionTitle', 'Description'),
('HonorScore.ManageType.SEOTitle', 'Short URL'),
('HonorScore.ManageType.AddedTitle', 'Added'),
('HonorScore.ManageType.SaveSubmit', 'Save'),
('HonorScore.ManageType.ResetSubmit', 'Clear'),
('HonorScore.ManageType.SaveTitle', ''),
('HonorScore.ManageType.DeleteTitle', ''),
('HonorScore.ManageType.UpdateSubmit', 'Update'),
('HonorScore.ScoreViewGame.Title', '{0}'),
('HonorScore.ScoreViewGame.NameTitle', 'Name'),
('HonorScore.ScoreViewGame.AchievedTitle', 'Achieved'),
('HonorScore.ScoreViewGame.NoData', 'No Honor Scores Found'),
('HonorScore.ScoreViewSeries.Title', '{0}'),
('HonorScore.ScoreViewSeries.NameTitle', 'Name'),
('HonorScore.ScoreViewSeries.AchievedTitle', 'Achieved'),
('HonorScore.ScoreViewSeries.SeriesTitle', 'Series'),
('HonorScore.ScoreViewSeries.GameTitle', 'Game Scores'),
('HonorScore.ScoreViewSeries.NoData', 'No Honor Scores Found'),
('HonorScore.ScoreHeader.HonorType', 'Honor Type'),
('HonorScore.ScoreHeader.HonorCategory', 'Honor Category'),
('Localization.Manage.Title', 'Localization'),
('Localization.Manage.SearchFieldTitle', 'Search Field'),
('Localization.Manage.SearchTypeTitle', 'Search Type'),
('Localization.Manage.SearchForTitle', 'Search For'),
('Localization.Manage.SearchTitle', 'Search'),
('Localization.Manage.SearchSubmit', 'Search'),
('Localization.Manage.KeyTitle', 'Key'),
('Localization.Manage.ValueTitle', 'Value'),
('Localization.Manage.UpdateTitle', ''),
('Localization.Manage.UpdateSubmit', 'Update'),
('Localization.Manage.NoData', 'No Data Found'),
('ManageLink.Links.Title', 'Manage Links'),
('ManageLink.Links.NameTitle', 'Name'),
('ManageLink.Links.UrlTitle', 'Url'),
('ManageLink.Links.VisibleTitle', 'Show'),
('ManageLink.Links.CreateTitle', ''),
('ManageLink.Links.OrderTitle', 'Move'),
('ManageLink.Links.DeleteTitle', ''),
('ManageLink.Links.CreateSubmit', 'Create'),
('ManageLink.Links.ResetSubmit', 'Clear'),
('ManageLink.Links.UpdateSubmit', 'Update'),
('ManageLink.Links.Order.Up', 'Up'),
('ManageLink.Links.Order.Down', 'Down'),
('ManageLink.Links.DeleteSubmit', 'Delete'),
('ManageLink.Navigation.Title', 'Navigation'),
('ManageLink.Navigation.DisplayTitle', 'Display'),
('ManageLink.Navigation.VisibleTitle', 'Show'),
('ManageLink.Navigation.UpdateTitle', ''),
('ManageLink.Navigation.OrderTitle', 'Move'),
('ManageLink.Navigation.UpdateSubmit', 'Update'),
('ManageLink.Navigation.Order.Up', 'Up'),
('ManageLink.Navigation.Order.Down', 'Down'),
('Search.SearchBar.SearchPlaceholder', 'Search'),
('Search.SearchBar.SearchSubmit', 'Search'),
('Searcher.Search.BoardFormat', '{0} - {1} to {2}'),
('Searcher.Index.Title', 'Search'),
('Shared.Footer.VersionText', 'Version'),
('Shared.Footer.Version', '0.0.1e'),
('Shared.Header.Line1', 'St. Paul Accociation'),
('Shared.Header.Line2', 'Test Site'),
('SiteMap.Index.Title', 'SiteMap'),
('SiteMap.Index.NavigationTitle', 'Menu'),
('SiteMap.Index.LinkTitle', 'Links'),
('SiteMap.Index.Pages', 'Pages'),
('SiteMap.Index.HallOfFame', 'Hall Of Fame'),
('SiteMap.Index.HonorScore', 'Honor Scores'),
('SiteMap.Index.Tournament', 'Tournaments'),
('Topic.ManageHeaderLinks.Widget', 'Widget'),
('Topic.ManageHeaderLinks.Topic', 'Topic'),
('Topic.ManageHeaderLinks.Page', 'Page'),
('Topic.ManageHeaderLinks.CreateSubmit', 'Create Content'),
('Topic.Create.Title', 'Create Contents'),
('Topic.Create.Info.Page', 'Page - Displayed under Pages section on left hand side of page'),
('Topic.Create.Info.Topic', 'Topic - Like Page but not displayed on lend hand side of page'),
('Topic.Create.Info.Url', 'Content can be reached by creating a link to http://{host}/page/[Name-of-Content]'),
('Topic.Create.SEO', 'Name'),
('Topic.Create.Type', 'Type'),
('Topic.Create.Active', 'Active'),
('Topic.Create.SaveSubmit', 'Save'),
('Topic.Create.CancelSubmit', 'Cancel'),
('Topic.Create.Content', 'Content'),
('Topic.Delete.ConfirmText', 'Are You Sure?'),
('Topic.Delete.Delete.Yes', 'Yes'),
('Topic.Delete.Delete.No', 'No'),
('Topic.Edit.SaveSubmit', 'Save'),
('Topic.Edit.CancelSubmit', 'Cancel'),
('Topic.Edit.Title', '{seo}'),
('Topic.Edit.LinkText', 'This {topic} can be reached by creating a link to'),
('Topic.Edit.Link', 'http://{0}/page/{1}'),
('Topic.Links.Title', 'Pages'),
('Topic.Manage.Title', 'Content Editor'),
('Topic.Manage.Info.Page', 'Page - Displayed under Pages section on left hand side of page (accessed with http://{host}/page/[Name-of-Content])'),
('Topic.Manage.Info.Topic', 'Topic - Like Page but not displayed on left hand side of page (accessed with http://{host}/page/[Name-of-Content])'),
('Topic.Manage.TopicTypeTitle', 'Type'),
('Topic.Manage.NameTitle', 'Name'),
('Topic.Manage.UpdatedTitle', 'Updated'),
('Topic.Manage.EditTitle', ''),
('Topic.Manage.DeleteTitle', ''),
('Topic.Manage.EditSubmit', 'Edit'),
('Topic.Manage.DeleteSubmit', 'Delete'),
('Topic.Manage.NoData', 'No Data Found'),
('Topic.Manage.Title', 'Content Editor'),
('Tournament.Create.Title', 'Create Tournament'),
('Tournament.Create.EventName', 'Event Name'),
('Tournament.Create.EventUrl', 'Event Url'),
('Tournament.Create.TournamentClassification', 'Type'),
('Tournament.Create.Center', 'Center'),
('Tournament.Create.Contact', 'Contact'),
('Tournament.Create.ContactEmail', 'Contact Email'),
('Tournament.Create.StartDate', 'Start Date'),
('Tournament.Create.EndDate', 'End Date'),
('Tournament.Create.RegistrationClose', 'Registration Close'),
('Tournament.Create.CreateSubmit', 'Create'),
('Tournament.Create.Cancel', 'Cancel'),
('Tournament.Index.Title', 'Tournaments'),
('Tournament.Index.TournamentClassificationTitle', 'Type'),
('Tournament.Index.EventTitle', 'Event'),
('Tournament.Index.ContactTitle', 'Contact'),
('Tournament.Index.CenterTitle', 'Center'),
('Tournament.Index.DateTitle', 'Date'),
('Tournament.Index.NoData', 'No Tournaments Found'),
('Tournament.Manage.Title', 'Manage Tournaments'),
('Tournament.Manage.TournamentClassificationTitle', 'Type'),
('Tournament.Manage.EventTitle', 'Event'),
('Tournament.Manage.CenterTitle', 'Center'),
('Tournament.Manage.ContactTitle', 'Contact'),
('Tournament.Manage.DateTitle', 'Dates'),
('Tournament.Manage.EditTitle', ''),
('Tournament.Manage.DeleteTitle', ''),
('Tournament.Manage.DateSeparator', 'to'),
('Tournament.Manage.EditSubmit', 'Edit'),
('Tournament.Manage.DeleteSubmit', 'Delete'),
('Tournament.Edit.Title', 'Edit Tournament'),
('Tournament.Edit.EventName', 'Event Name'),
('Tournament.Edit.EventUrl', 'Event Url'),
('Tournament.Edit.TournamentClassification', 'Type'),
('Tournament.Edit.Center', 'Center'),
('Tournament.Edit.Contact', 'Contact'),
('Tournament.Edit.ContactEmail', 'Contact Email'),
('Tournament.Edit.StartDate', 'Start Date'),
('Tournament.Edit.EndDate', 'End Date'),
('Tournament.Edit.RegistrationClose', 'Registration Close'),
('Tournament.Edit.EditSubmit', 'Update'),
('Tournament.Edit.Cancel', 'Cancel'),
('Tournament.Manage.CreateSubmit', 'Create'),
('RSS.Feed.Board.Title', 'Board'),
('RSS.Feed.Board.Description', 'Board Members'),
('RSS.Board.BoardFormat', '{0} - {1} to {2}'),
('RSS.Index.HallOfFame.Title', 'Hall Of Fame'),
('RSS.Index.Tournament.Title', 'Tournament'),
('RSS.Index.Board.Title', 'Board'),
('RSS.Feed.HallOfFame.Title', 'Hall Of Fame'),
('RSS.Feed.HallOfFame.Description', 'Hall Of Fame'),
('RSS.Feed.Honor.Title', 'Honor Scores'),
('RSS.Feed.Honor.Description', 'Honor Scores'),
('RSS.Feed.Tournament.Title', 'Tournament'),
('RSS.Feed.Tournament.Description', 'Tournaments'),
('RSS.Index.Title', 'RSS Feeds'),
('Award.AwardSummary.Print', 'Printer Friendly'),
('SiteMap.Index.Board', 'Board'),
('Award.PrintAward.ID', 'Report ID'),
('Award.PrintAward.DateBowled', 'Date Bowled'),
('Award.PrintAward.AwardType', 'Type'),
('Award.PrintAward.BowlerName', 'Name'),
('Award.PrintAward.USBCID', 'USBC ID'),
('Award.PrintAward.Center', 'Center'),
('Award.PrintAward.League', 'League'),
('Award.PrintAward.BowlerAverage', 'Average'),
('Award.PrintAward.BowlerGames', 'Games'),
('Award.PrintAward.Game1', 'Game 1'),
('Award.PrintAward.Game2', 'Game 2'),
('Award.PrintAward.Game3', 'Game 3'),
('Award.PrintAward.Series', 'Series'),
('Award.PrintAward.USBCAward', 'USBC Award(s)'),
('Award.PrintAward.LocalAward', 'Local Award(s)'),
('Award.PrintAward.LocalAwardChoice', 'Local Award Choice'),
('Award.PrintAward.SecretaryAreaTitle', 'Secretary Info'),
('Award.PrintAward.SecretaryName', 'Name'),
('Award.PrintAward.SecretaryPin', 'PIN'),
('Award.PrintAward.SecretaryPhone', 'Phone'),
('Award.PrintAward.SecretaryEmail', 'Email'),
('Award.PrintAward.Title', 'Awards for {BowlerName}'),
('Account.Create.FirstName.Invalid', 'First Name must be less than 64 characters'),
('Account.Create.LastName.Invalid', 'Last Name must be less than 64 characters'),
('Account.Create.Username.Invalid', 'Username must be between 5 and 64 characters'),
('Account.Create.Password.Invalid', 'Password is Required'),
('Account.Create.ConfirmPassword.Invalid', 'Passwords Must Match'),
('Account.LogIn.Failed', 'SignIn Failed, Please Try Again Later�'),
('Account.LogIn.InvalidPassword', 'Invalid Username and/or Password'),
('Account.LogIn.InvalidUsername', 'Invalid Username and/or Password'),
('Account.LogIn.LockedOut', 'Account Locked Out'),
('Account.LogIn.ErrorDefault', 'Please Fill Out The Required Fields'),
('Searcher.Search.Division.HallOfFame', 'Hall Of Fame'),
('Searcher.Search.Division.Tournament', 'Tournament'),
('SeasonAverage.Index.Title','Season Averages'),
('SeasonAverage.Index.SearchText','Search'),
('SeasonAverage.Index.SearchSubmit','Search'),
('SeasonAverage.Index.SearchResultTitle','Season Average Results For ({0})'),
('SeasonAverage.Index.NoSearchResult','No Season Averages Found'),
('SeasonAverage.Index.SearchResult.Season','Season'),
('SeasonAverage.Index.SearchResult.GamesTitle','Games'),
('SeasonAverage.Index.SearchResult.AverageTitle','Average'),
('SeasonAverage.Index.SearchResult.LeagueTitle','League ID'),
('SeasonAverage.Manage.Title','Season Average Management'),
('SeasonAverage.Manage.Season','Season'),
('SeasonAverage.Manage.UploadChoice','Upload Choice'),
('SeasonAverage.Manage.File','Average File'),
('SeasonAverage.Manage.UploadChoice.Purge','Delete Existing Data First'),
('SeasonAverage.Manage.UploadChoice.Append','Keep Exsiting Data'),
('SeasonAverage.Manage.UploadResult.Success','Season Averages Uploaded'),
('SeasonAverage.Manage.UploadResult.Fail','Failure Parsing File'),
('SeasonAverage.Manage.Submit', 'Upload Averages'),
('SeasonAverage.Index.SearchCount', 'Showing {0} of {1}')
GO