import { getAxios } from "../http-client/generic-api-calls";
import { EndPoints } from "../http-client/api-config";
import type { StationModel } from "../models/station";

export async function getStations(): Promise<StationModel[]> {
  const response = await getAxios<StationModel[]>(`${EndPoints.v1Stations}`);
  return response.data;
}
