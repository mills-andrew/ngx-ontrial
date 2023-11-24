import { AccountsMockApi } from "./apps/accounts/api";
import { ChatMockApi } from "./apps/chat/api";
import { FileManagerMockApi } from "./apps/file-manager/api";
import { TasksMockApi } from "./apps/tasks/api";
import { NotesMockApi } from "./apps/notes/api";
import { ScrumboardMockApi } from "./apps/scrumboard/api";

import { AuthMockApi } from "./common/auth/api";
import { NavigationMockApi } from "./common/navigation/api";

import { IconsMockApi } from "./ui/icons/api";
import { ProjectMockApi } from "./dashboards/project/api";
import { AnalyticsMockApi } from "./dashboards/analytics/api";
import { FinanceMockApi } from "./dashboards/finance/api";
import { HelpCenterMockApi } from "./apps/help-center/api";
import { NotificationsMockApi } from "./common/notifications/api";
import { ECommerceInventoryMockApi } from "./apps/ecommerce/inventory/api";

export const mockApiServices = [
	ProjectMockApi,
	AnalyticsMockApi,
	FinanceMockApi,
	AccountsMockApi,
	AuthMockApi,
	FileManagerMockApi,
	IconsMockApi,
	NavigationMockApi,
	ChatMockApi,
	TasksMockApi,
	NotesMockApi,
	ScrumboardMockApi,
	HelpCenterMockApi,
	NotificationsMockApi,
	ECommerceInventoryMockApi
];
