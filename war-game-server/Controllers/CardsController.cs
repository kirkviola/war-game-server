using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using war_game_server.Models;

namespace war_game_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly WarDbContext _context;

        public CardsController(WarDbContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }


        // PUT: api/Cards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("shuffle/{id}")]
        public async Task<IActionResult> ShuffleDeck(int id)
        {
            var deck = await _context.Cards.ToListAsync();

            var rand = new Random();
            var sequence = new List<int>();
            var num = 0;

            while (sequence.Count < deck.Count)
            {

                do
                {
                    num = rand.Next(1, deck.Count + 1);

                } while (sequence.Contains(num));
                {
                    sequence.Add(num);
                }

            }
            for (var i = 0; i < deck.Count; i++)
            {
                    deck[i].Position = sequence[i];
            }

            // Deal the cards
            var comp = await _context.Players.SingleOrDefaultAsync(x => x.Name == "Computer");
            var playerIdx = 0;
            var compIdx = 0;

            // deck.Sort();
            // Will need to decrease i for indexing due to divide by zero error avoidance
            for (var i = 1; i <= deck.Count; i++)
            {
               
            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("play/{id}")]
        public async Task<IActionResult> PlayHand(int id)
        {
            var playerCard = await _context.Cards.SingleOrDefaultAsync(x => x.Position == 1);
            var compCard = await _context.Cards.SingleOrDefaultAsync(x => x.Position == 1);
            var player = await _context.Players.SingleOrDefaultAsync(x => x.Id == id);
            var comp = await _context.Players.SingleOrDefaultAsync(x => x.Name == "Computer");


            if (playerCard.Value > compCard.Value)
            {

            }
        }

        // POST: api/Cards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    }
}
