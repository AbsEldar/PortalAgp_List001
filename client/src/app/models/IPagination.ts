import { IUser } from "./IUser";

export interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IUser[];

}
