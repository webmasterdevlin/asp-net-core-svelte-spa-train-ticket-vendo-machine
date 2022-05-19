<script lang="ts">
    import {letters} from "../utils/station.ts";

    export let handleOnSubmit;
    export let nextSuggestedLetters: string[] = [];
</script>

   <div class="form-container">
       {#each letters as letter}
           <form on:submit|preventDefault={handleOnSubmit(letter)}>
              <button class:suggested-button={nextSuggestedLetters.includes(letter)}
                      type="submit">{letter === " " ? "space" : letter}
              </button>
           </form>
       {/each}
   </div>

<style>
    .form-container {
        width: 100%;
        display: flex;
        flex-direction: row;
        gap: 1rem;
        justify-content: flex-start;
        flex-wrap: wrap;
        align-items: center
    }
    .suggested-button {
        color: white;
        background-color: green;
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
