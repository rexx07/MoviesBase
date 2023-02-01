import {AuthModel} from "../../pages/auth";

export class UserModel {
  id!: string;
  name!: string;
  email!: string;
  auth!: AuthModel;
}
