import {MovieModel, TvModel} from "../../pages/feed";

export class PaginationModel {
  public dates: Object = {};
  public page: number = 0;
  public results: Array<MovieModel | TvModel> = [];
  public total_pages: number = 0;
  public total_results: number = 0;
}
