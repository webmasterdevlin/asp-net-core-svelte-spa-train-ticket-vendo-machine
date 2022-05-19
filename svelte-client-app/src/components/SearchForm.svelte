<script lang="ts">
    export let handleOnSubmit;
    export let search = "";
    export let letters = [];
    export let nextValidLetters = [];

</script>

   <div style="width: 100%;display: flex; flex-direction: row; gap: 1rem; justify-content: flex-start; flex-wrap: wrap; align-items: center ">
       {#each letters as letter}
           <form on:submit|preventDefault={handleOnSubmit(letter)}>
              <button class:possible={nextValidLetters.includes(letter)} type="submit">{letter}</button>
           </form>
       {/each}
   </div>

<style>
    .possible {
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
