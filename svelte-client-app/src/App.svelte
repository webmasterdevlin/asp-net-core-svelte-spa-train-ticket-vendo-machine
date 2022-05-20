<script lang="ts">
  import { onMount } from "svelte"
  import type {StationModel} from "./models/station";
  import SearchForm from "./components/SearchForm.svelte";
  import {getStations} from "./services/stationService";
  import {get, store} from "./utils/cache";

  const key = "stations";

  let search = '';
  let nextSuggestedLetters: string[] = [];
  let stations: StationModel[] = [];

  onMount(async () => {
    try {
      const data = await getStations();
      store(key, data);
    } catch (e) {
      alert("Please check your internet connection");
    }
  });

  const onSearch = (searchName: string) => {
    const cachedStations = get<StationModel[]>(key);
    let extractedLetters: string[] = [];

    search += searchName;
    stations = cachedStations.filter(station => station.name.toLowerCase().includes(search.toLowerCase()));

    stations.forEach(s => {
      const modifiedName = s.name.slice(search.length);
      const suggestedLetter = modifiedName.charAt(0);
      extractedLetters.push(suggestedLetter.toLowerCase());
    });

    nextSuggestedLetters = [...new Set(extractedLetters)];
  }

  const onReset = () => {
    search = '';
    nextSuggestedLetters = [];
    stations = [];
  }

</script>

<main>
  <div style="margin-bottom: 2rem">
    <h1>Train Ticket Machine</h1>
  </div>
  <SearchForm handleOnSubmit={onSearch} nextSuggestedLetters={nextSuggestedLetters} />
  <div style="margin-bottom: 2rem">
    <h2>You are looking for: {search.toUpperCase()}</h2>
  </div>
  <div style="margin-bottom: 2rem">
    <button on:click={onReset}>RESET</button>
  </div>
  <div>
    <h2>Stations</h2>
    {#if stations.length > 0}
      <ul>
        {#each stations as station}
          <li data-cy="station">{station.name}</li>
        {/each}
      </ul>
      {:else}
      <p data-cy="no-stations">No stations found</p>
      <p>You can reset the search to start again</p>
    {/if}
  </div>
</main>

<style>
  :root {
    font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen,
      Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
  }

  main {
    text-align: center;
    padding: 1em;
    margin: 0 auto;
  }

  h1 {
    color: #ff3e00;
    text-transform: uppercase;
    font-size: 4rem;
    font-weight: 100;
    line-height: 1.1;
    margin: 2rem auto;
    max-width: 14rem;
  }

  ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
  }

  p {
    max-width: 14rem;
    margin: 1rem auto;
    line-height: 1.35;
  }

  @media (min-width: 480px) {
    h1 {
      max-width: none;
    }

    p {
      max-width: none;
    }
  }

  button {
    font-family: inherit;
    font-size: inherit;
    padding: 1em;
    color: #ff3e00;
    background-color: rgba(255, 62, 0, 0.1);
    border-radius: 2em;
    border: 2px solid rgba(255, 62, 0, 0);
    outline: none;
    width: 100px;
    font-variant-numeric: tabular-nums;
    cursor: pointer;
  }

  button:focus {
    border: 2px solid #ff3e00;
  }

  button:active {
    background-color: rgba(255, 62, 0, 0.2);
  }

</style>
