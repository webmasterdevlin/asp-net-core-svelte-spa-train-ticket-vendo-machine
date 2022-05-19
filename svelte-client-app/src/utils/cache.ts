/* simple localStorage usage */

export const store = (key: string, value: any) => {
  window.localStorage.setItem(key, JSON.stringify(value));
};

export const get = <T = any>(key: string) => {
  const value: string | null = window.localStorage.getItem(key);

  if (!value) return null;

  return JSON.parse(value) as T;
};
