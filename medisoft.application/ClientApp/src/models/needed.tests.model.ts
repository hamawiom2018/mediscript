import { Test } from "./bard.report.model";

export interface NeededTestModel {
    testsNeeds: Test[];
    success: boolean;
    message: string;
}