import { NgModule } from '@angular/core';
import { SharedModule } from './shared/shared.module';

import { LayoutComponent } from './layout.component';
import { EmptyLayoutModule } from './empty/empty.module';
import { CenteredLayoutModule } from './horizontal/centered/centered.module';
import { EnterpriseLayoutModule } from './horizontal/enterprise/enterprise.module';
import { MaterialLayoutModule } from './horizontal/material/material.module';
import { ModernLayoutModule } from './horizontal/modern/modern.module';
import { ClassicLayoutModule } from './vertical/classic/classic.module';
import { ClassyLayoutModule } from './vertical/classy/classy.module';
import { CompactLayoutModule } from './vertical/compact/compact.module';
import { DenseLayoutModule } from './vertical/dense/dense.module';
import { FuturisticLayoutModule } from './vertical/futuristic/futuristic.module';
import { ThinLayoutModule } from './vertical/thin/thin.module';

const layoutModules = [
	// Empty
	EmptyLayoutModule,

	// Horizontal navigation
	CenteredLayoutModule,
	EnterpriseLayoutModule,
	MaterialLayoutModule,
	ModernLayoutModule,

	// Vertical navigation
	ClassicLayoutModule,
	ClassyLayoutModule,
	CompactLayoutModule,
	DenseLayoutModule,
	FuturisticLayoutModule,
	ThinLayoutModule
];

@NgModule({
	declarations: [
		LayoutComponent
	],
	imports: [
		SharedModule,
		...layoutModules
	],
	exports: [
		LayoutComponent,
		...layoutModules
	]
})
export class LayoutModule {
}
